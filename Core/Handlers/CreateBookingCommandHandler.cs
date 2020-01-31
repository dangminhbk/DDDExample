using Core.Command;
using Core.Domain.Booking;
using Core.Domain.Booking.Dto;
using Core.Entities;
using Core.Entities.Booking;
using Core.Event;
using Core.EventStore;
using Core.Handlers.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, ResponseBase>
    {
        private readonly IBookingService _bookingService;
        public CreateBookingCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public async Task<ResponseBase> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var input = new BookingCreateDto
            {
                ArriveDate = request.ArriveDate,
                CustomerName = request.CustomerName,
                RoomName = request.RoomName
            };

            var result = await _bookingService.CreateBooking(input);
            return result ? ResponseBase.Success : ResponseBase.Fail;
        }
    }
}
