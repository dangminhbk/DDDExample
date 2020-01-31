using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Event
{
    public class Event<T> where T : EventData
    {
        public Guid AggregateId { get; set; }
        public DateTime DateAdded { get; set; }
        public int Version { get; set; } = 1;
        public T Data { get; set; }
    }
}
