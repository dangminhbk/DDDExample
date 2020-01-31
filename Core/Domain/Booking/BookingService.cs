using Core.Domain.Booking.Dto;
using Core.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EventStore;

namespace Core.Domain.Booking
{
    public class BookingService : IBookingService
    {
        private readonly IEventStore<Entities.Booking.Booking> _eventStore;
        public BookingService(IEventStore<Entities.Booking.Booking> eventStore)
        {
            _eventStore = eventStore;
        }
        public async Task<bool> CreateBooking(BookingCreateDto input)
        {
            var AggregateId = new Guid();
            var bookingCreated = new BookingCreated
            {
                Data = new BookingCreatedData
                {
                    ArriveDate = input.ArriveDate,
                    CustomerName = input.CustomerName,
                    RoomName = input.RoomName
                },
                AggregateId = AggregateId,
                DateAdded = DateTime.Now,
                Version = 1
            };
            await _eventStore.Push(bookingCreated);
            return true;
        }
    }
}
