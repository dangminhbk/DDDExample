using Infrastructure.Entities;
using Infrastructure.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.EventStore
{
    public interface IEventStore<EventAggregate>
        where EventAggregate : Entities.Aggregate
    {
        Task Push(Event<EventAggregate> @event);
        Task<List<Event<EventAggregate>>> History();
        Task<List<Event<EventAggregate>>>EntityHistory(Guid id);
        Task<EventAggregate> Project(Guid id);
        Task<int> GetCurrentVersion(Guid id);
        Task<int> GenerateVersion(Guid id);
    }
}
