using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Event
{
    public interface IEvent<T> where T: Aggregate
    {
        Task Project(T aggregate);
    }
}
