using Core.Domain.Booking.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Booking
{
    public interface IBookingService
    {
        Task<bool> CreateBooking(BookingCreateDto input);
        Task<bool> UpdateBooking(BookingUpdateDto input);
    }
}
