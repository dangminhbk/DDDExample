using Core.Entities.Booking;
using Infrastructure.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Event
{
    public class BookingUpdated : Event<Booking>
    {
    }
}
