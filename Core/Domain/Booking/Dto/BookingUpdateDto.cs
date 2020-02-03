using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Booking.Dto
{
    public class BookingUpdateDto
    {
        public Guid AggregateId { get; set; }
        public DateTime ArriveDate { get; set; }
        public string RoomName { get; set; }
    }
}
