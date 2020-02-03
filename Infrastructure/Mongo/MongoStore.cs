using Infrastructure.Entities;
using Infrastructure.Event;
using Infrastructure.EventStore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public Task<List<IEvent<T>>> EntityHistory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GenerateVersion(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCurrentVersion(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IEvent<T>>> History()
        {
            throw new NotImplementedException();
        }

        public Task<T> Project(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Push(IEvent<T> @event)
        {
            throw new NotImplementedException();
        }

        protected IMongoCollection<T> Collections
        {
            get
            {
                return _mongoClient.GetDatabase(_configuration.GetConnectionString("Mongo")).GetCollection<T>(nameof(T));
            }
        }
    }
}
