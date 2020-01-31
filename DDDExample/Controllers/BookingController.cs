using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Command;
using Core.Handlers.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Dto;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task CreateBooking(CreateBookingInput input)
        {
            var request = new CreateBookingCommand {
                ArriveDate = input.ArriveDate,
                CustomerName = input.CustomerName,
                RoomName = input.RoomName        
            };

            await _mediator.Send<ResponseBase>(request);
        }

        public async Task HistoryBooking() 
        {
        }
    }
}