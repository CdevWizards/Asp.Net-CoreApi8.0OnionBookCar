using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;

namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation
        (CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok(" Rezervasyon Başarıyla Eklendi...");
        }
    }
}