using Core.Entities;
using Core.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.EventStore
{
    interface IEventStore<T> where T : Aggregate
    {
        Task Push(IEvent<T> @event);
        Task<List<IEvent<T>>> History();
        Task<List<IEvent<T>>>EntityHistory(Guid id);
        Task<T> Project(Guid id);
    }
}
