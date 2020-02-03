using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Event
{
    public interface IEvent<EventAggregate> where EventAggregate: Aggregate
    {
        Task Project(EventAggregate aggregate);
        Guid AggregateId { get; set; }

        DateTime DateAdded { get; set; }
        int Version { get; set; }
        
    }
}
