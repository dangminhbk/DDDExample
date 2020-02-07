using Infrastructure.Entities;
using Infrastructure.Event;
using Infrastructure.EventStore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Mongo
{
    public class MongoStore<T> : IEventStore<T>
        where T : Aggregate
    {
        private readonly IMongoClient _mongoClient;
        private readonly IConfiguration _configuration;
        public MongoStore(IMongoClient mongoClient, IConfiguration configuration)
        {
            _mongoClient = mongoClient;
            _configuration = configuration;
        }
        public async Task<List<Event<T>>> EntityHistory(Guid id)
        {
            var history = (await Collections.FindAsync(s=>s.AggregateId == id)).ToList();
            return history;
        }

        public async Task<int> GenerateVersion(Guid id)
        {
            return await GetCurrentVersion(id) + 1;
        }

        public async Task<int> GetCurrentVersion(Guid id)
        {
            var last = Collections.Find(s => s.AggregateId == id).SortByDescending(s => s.Version).FirstOrDefault();
            return last == null ? -1 : last.Version;
        }

        public async Task<List<Event<T>>> History()
        {
            var history = (await Collections.FindAsync(s => true)).ToList();
            return history;
        }

        public async Task<T> Project(Guid id)
        {
            T aggregate = (T)Aggregate.Reconstruct();
            var history = (await this.EntityHistory(id)).OrderBy(s=> s.Version);

            foreach (var item in history)
            {
                await item.Project(aggregate);
            }
            return aggregate;
        }

        public async Task Push(Event<T> @event)
        {
            Collections.InsertOneAsync((Event<T>)@event);
        }

        protected IMongoCollection<Event<T>> Collections
        {
            get
            {
                return _mongoClient.GetDatabase("EventStore").GetCollection<Event<T>>(typeof(T).Name);
            }
        }
    }
}
