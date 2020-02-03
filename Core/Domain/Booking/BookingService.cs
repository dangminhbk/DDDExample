using Core.Domain.Booking.Dto;
using Core.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EventStore;
using Core.Constants;

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
                Version = 0
            };
            await _eventStore.Push(bookingCreated);
            return true;
        }

        public async Task<bool> UpdateBooking(BookingUpdateDto input) 
        {
            var currentVersion = await _eventStore.GetCurrentVersion(input.AggregateId);
            if (currentVersion == EventConstants.NOT_VALID_VERSION)
            {
                return false;
            }

            // TODO check if booking was canceled or done
            var BookingUpdated = new BookingUpdated
            {
                AggregateId = input.AggregateId,
                Data = new BookingUpdatedData
                {
                    ArriveDate = input.ArriveDate,
                    RoomName = input.RoomName
                },
                DateAdded = DateTime.Now,
                Version = currentVersion++
            };
            await _eventStore.Push(BookingUpdated);
            return true;
        }
    }
}
