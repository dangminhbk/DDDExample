using Core.Entities.Booking;
using Infrastructure.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Event
{
    public class BookingCreated : Event<BookingCreatedData, Booking>
    {
        public override async Task Project(Booking aggregate)
        {
            aggregate.ArriveDate = Data.ArriveDate;
            aggregate.CustomerName = Data.CustomerName;
            aggregate.ArriveDate = Data.ArriveDate;
            aggregate.Status = Enums.BookingStatus.Created;
            await Task.CompletedTask;
        }
    }

    public class BookingCreatedData : EventData
    {
        public string CustomerName { get; set; }
        public string RoomName { get; set; }
        public DateTime ArriveDate { get; set; }
    }
}
