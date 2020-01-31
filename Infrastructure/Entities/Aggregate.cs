using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class Aggregate
    {
        public static Aggregate Reconstruct()
        {
            return new Aggregate();
        }
        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }
        public int CurrentVersion { get; set; }
        public Guid LastestEventId { get; set; }
    }
}
