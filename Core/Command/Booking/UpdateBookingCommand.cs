using Core.Handlers.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Command.Booking
{
    public class UpdateBookingCommand : IRequest<ResponseBase>
    {
        public Guid AggregateId { get; set; }
        public DateTime ArriveDate { get; set; }
        public string RoomName { get; set; }
    }
}
