using Core.Domain.Booking.Dto;
using Core.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EventStore;
using Core.Constants;
using Core.Data;
using Infrastructure.Event;

namespace Core.Domain.Booking
{
    public class BookingService : IBookingService
    {
        private readonly IEventStore<Entities.Booking.Booking> _eventStore;
        private readonly HotelDBContext _readSideContext;
        public BookingService(IEventStore<Entities.Booking.Booking> eventStore, HotelDBContext readSideContext)
        {
            _eventStore = eventStore;
            _readSideContext = readSideContext;
        }
        public async Task<bool> CreateBooking(BookingCreateInput input)
        {
            var AggregateId = new Guid();
            var bookingCreated = new BookingCreated
            {
                AggregateId = AggregateId,
                DateAdded = DateTime.Now,
                Version = 0,
                Data = await BuildCreateBookingEventData()
            };
            await _eventStore.Push(bookingCreated);
            return true;
        }

        public async Task<bool> UpdateBooking(BookingUpdateInput input) 
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
                DateAdded = DateTime.Now,
                Version = currentVersion++,
                Data = await BuildCreateBookingEventData()
            };
            await _eventStore.Push(BookingUpdated);
            return true;
        }

        public async Task<Entities.Booking.Booking> Get (Guid id) 
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Booking.Booking> Trusted_Get(Guid id)
        {
            throw new NotImplementedException();
        }

        private async Task<EventData> BuildCreateBookingEventData()
        {
            throw new NotImplementedException();
        }

        private async Task<EventData> BuildUpdateBookingEventData()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelBooking(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoneBooking(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entities.Booking.Booking>> ListBooking()
        {
            throw new NotImplementedException();
        }
    }
}
