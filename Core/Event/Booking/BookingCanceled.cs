using Core.Entities.Booking;
using Core.Enums;
using Infrastructure.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Event
{
    public class BookingCanceled : Event<Booking>
    {
    }
}
