using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Event
{
    public abstract class Event<EventData, EventAggregate> : IEvent<EventAggregate>
        where EventData : Event.EventData
        where EventAggregate : Entities.Aggregate
    {
        public abstract Task Project(EventAggregate aggregate);

        public Guid AggregateId { get; set; }
        public DateTime DateAdded { get; set; }
        public int Version { get; set; }
        public EventData Data { get; set; }
    }
}
