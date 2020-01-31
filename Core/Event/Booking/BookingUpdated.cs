using Core.Entities.Booking;
using Infrastructure.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Event
{
    public class BookingUpdated : Event<BookingUpdatedData, Booking>
    {
        public override async Task Project(Booking aggregate)
        {
            aggregate.ArriveDate = Data.ArriveDate;
            aggregate.RoomName = Data.RoomName;
            aggregate.Status = Enums.BookingStatus.Updated;
            await Task.CompletedTask;
       }
    }

    public class BookingUpdatedData : EventData
    {
        public string RoomName { get; set; }
        public DateTime ArriveDate { get; set; }
    }
}
