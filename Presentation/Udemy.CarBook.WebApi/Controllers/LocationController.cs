using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values =await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation
        (CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Bilgisi Eklendi...");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var values = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Alt Adres Bilgisi Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Bilgisi Güncellendi.");
            
        }
    }
}