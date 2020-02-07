using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Booking.Dto
{
    public class BookingCreateInput
    {
        public string CustomerName { get; set; }
        public string RoomName { get; set; }
        public DateTime ArriveDate { get; set; }
    }
}
