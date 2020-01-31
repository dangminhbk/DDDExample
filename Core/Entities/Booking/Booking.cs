using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Booking
{
    public class Booking : Aggregate
    {
        public string CustomerName { get; set; }
        public string RoomName { get; set; }
        public DateTime ArriveDate { get; set; }
        public DateTime CanceledDate { get; set; }
        public DateTime DoneDate { get; set; }
        public BookingStatus Status { get; set; }
    }
}
