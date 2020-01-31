using Core.Entities.Booking;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Event
{
    public class BookingCanceled : Event<BookingCanceledData>, IEvent<Booking>
    {
        public async Task Project(Booking aggregate)
        {
            aggregate.CanceledDate = Data.CanceledDate;
            aggregate.Status = BookingStatus.Canceled;
            await Task.CompletedTask;
        }
    }

    public class BookingCanceledData : EventData
    {
        public DateTime CanceledDate { get; set; }
    }
}
