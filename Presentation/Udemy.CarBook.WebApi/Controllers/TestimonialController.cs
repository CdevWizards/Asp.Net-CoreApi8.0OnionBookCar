using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialController : ControllerBase
    
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values =await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial
        (CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok(" TestimonialBaşarıyla Eklendi...");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok(" TestimonialBaşarıyla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok(" Testimonial Başarıyla Güncellendi.");
            
        }
    }
}