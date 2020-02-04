using Infrastructure.Entities;
using Infrastructure.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventStore
{
    public class EventStore<EventAggregate> : IEventStore<EventAggregate>
        where EventAggregate : Entities.Aggregate
    {
        private List<Event<EventAggregate>> _store { get; set; }
        public EventStore()
        {
            _store = new List<Event<EventAggregate>>();
        }

        public async Task<List<Event<EventAggregate>>> EntityHistory(Guid id)
        {
            return _store
                    .Where(e => e.AggregateId == id)
                    .OrderBy(s => s.Version)
                    .ThenBy(s => s.DateAdded)
                    .ToList();
        }

        public async Task<List<Event<EventAggregate>>> History()
        {
            return _store
                    .OrderBy(s => s.Version)
                    .ThenBy(s => s.DateAdded)
                    .ToList();
        }

        public async Task<EventAggregate> Project(Guid id)
        {
            EventAggregate aggregate = (EventAggregate) Aggregate.Reconstruct();
            var history = _store
                    .Where(e => e.AggregateId == id)
                    .OrderBy(s => s.Version)
                    .ThenBy(s => s.DateAdded);
            foreach (var item in history)
            {
                await item.Project(aggregate);
            }
            return aggregate;
        }

        public async Task Push(Event<EventAggregate> @event)
        {
            _store.Add(@event);
            await Task.CompletedTask;
        }

        public async Task<int> GetCurrentVersion(Guid id)
        {
            var lastest = _store.Where(s=>s.AggregateId == id).OrderByDescending(s=>s.Version).FirstOrDefault();
            return lastest==null ? -1 : lastest.Version;
        }

        public async Task<int> GenerateVersion(Guid id)
        {
            var currentVersion = await this.GetCurrentVersion(id);
            return currentVersion + 1;
        }
    }
}
