﻿using Core.Handlers.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Command.Booking
{
    public class CancelBookingCommand : IRequest<ResponseBase>
    {
        public Guid AggregateId { get; set; }
    }
}
