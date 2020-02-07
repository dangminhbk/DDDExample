using Core.Handlers.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Command.Booking
{
    public class DoneBookingCommand : IRequest<ResponseBase>
    {
        public Guid AggregateId { get; set; }
    }
}
