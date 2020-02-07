using Core.Command;
using Core.Command.Booking;
using Core.Domain.Booking;
using Core.Domain.Booking.Dto;
using Core.Entities;
using Core.Entities.Booking;
using Core.Event;
using Core.Handlers.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers
{
    public class BookingCommandHandler : 
        IRequestHandler<CreateBookingCommand, ResponseBase>,
        IRequestHandler<UpdateBookingCommand, ResponseBase>,
        IRequestHandler<CancelBookingCommand, ResponseBase>,
        IRequestHandler<DoneBookingCommand, ResponseBase>
    {
        private readonly IBookingService _bookingService;
        public BookingCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        public async Task<ResponseBase> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var input = new BookingCreateInput
            {
                ArriveDate = request.ArriveDate,
                CustomerName = request.CustomerName,
                RoomName = request.RoomName
            };

            var result = await _bookingService.CreateBooking(input);
            return result ? ResponseBase.Success : ResponseBase.Fail;
        }

        public async Task<ResponseBase> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var input = new BookingUpdateInput
            {
                AggregateId = request.AggregateId,
                ArriveDate = request.ArriveDate,
                RoomName = request.RoomName
            };

            var result = await _bookingService.UpdateBooking(input);
            return result ? ResponseBase.Success : ResponseBase.Fail;
        }

        public async Task<ResponseBase> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookingService.CancelBooking(request.AggregateId);
            return result ? ResponseBase.Success : ResponseBase.Fail;
        }

        public async Task<ResponseBase> Handle(DoneBookingCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookingService.DoneBooking(request.AggregateId);
            return result ? ResponseBase.Success : ResponseBase.Fail;
        }
    }
}
