using Core.Handlers.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Command
{
    public class CreateBookingCommand : IRequest<ResponseBase>
    {
        public string CustomerName { get; set; }
        public string RoomName { get; set; }
        public DateTime ArriveDate { get; set; }
    }
}
