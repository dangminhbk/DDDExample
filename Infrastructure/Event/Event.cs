using Infrastructure.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Event
{
    public abstract class Event<EventAggregate> : IEvent<EventAggregate>
        where EventAggregate : Entities.Aggregate
    {
        public async Task Project(EventAggregate aggregate)
        {
            foreach (var item in Data.Changes)
            {
                aggregate.Set(item.PropertyName,(object)item.Value);
            }
        }

        public Guid AggregateId { get; set; }
        public DateTime DateAdded { get; set; }
        public int Version { get; set; }
        public EventData Data { get; set; }
    }
}
