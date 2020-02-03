using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Event
{
    public abstract class EventData
    {
        public List<Change> Changes { get; set; }
    }

    public class Change
    {
        public string PropertyName { get; set; }
        public dynamic Value { get; set; }
        public string Type { get; set; }
    }
}
