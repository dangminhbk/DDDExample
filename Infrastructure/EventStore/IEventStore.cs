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
        Task Push(IEvent<EventAggregate> @event);
        Task<List<IEvent<EventAggregate>>> History();
        Task<List<IEvent<EventAggregate>>>EntityHistory(Guid id);
        Task<EventAggregate> Project(Guid id);
        Task<int> GetCurrentVersion(Guid id);
        Task<int> GenerateVersion(Guid id);
    }
}
