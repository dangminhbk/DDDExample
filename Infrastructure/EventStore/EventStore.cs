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
        private List<Event<EventData, EventAggregate>> _store { get; set; }

        public Task<List<IEvent<EventAggregate>>> EntityHistory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IEvent<EventAggregate>>> History()
        {
            throw new NotImplementedException();
        }

        public Task<EventAggregate> Project(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Push(IEvent<EventAggregate> @event)
        {
            throw new NotImplementedException();
        }
    }
}
