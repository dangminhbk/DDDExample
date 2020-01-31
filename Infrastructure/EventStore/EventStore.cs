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
        private List<IEvent<EventAggregate>> _store { get; set; }
        public EventStore()
        {
            _store = new List<IEvent<EventAggregate>>();
        }

        public async Task<List<IEvent<EventAggregate>>> EntityHistory(Guid id)
        {
            return _store
                    .Where(e => e.AggregateId == id)
                    .OrderBy(s => s.Version)
                    .ThenBy(s => s.DateAdded)
                    .ToList();
        }

        public async Task<List<IEvent<EventAggregate>>> History()
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

        public async Task Push(IEvent<EventAggregate> @event)
        {
            _store.Add(@event);
            await Task.CompletedTask;
        }
    }
}
