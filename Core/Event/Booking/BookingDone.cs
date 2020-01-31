using Core.Entities.Booking;
using Infrastructure.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Event
{
    public class BookingDone : Event<BookingDoneData,Booking>
    {
        public override async Task Project(Booking aggregate)
        {
            aggregate.DoneDate = Data.DoneDate;
            aggregate.Status = Enums.BookingStatus.Done;
            await Task.CompletedTask;
        }
    }
    public class BookingDoneData : EventData
    {
        public DateTime DoneDate { get; set; }

    }
}
