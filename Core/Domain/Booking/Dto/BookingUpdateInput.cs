using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Booking.Dto
{
    public class BookingUpdateInput
    {
        public Guid AggregateId { get; set; }
        public DateTime ArriveDate { get; set; }
        public string RoomName { get; set; }
    }
}
