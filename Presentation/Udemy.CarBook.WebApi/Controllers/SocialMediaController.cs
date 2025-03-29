using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialMediaController : ControllerBase
    
    {
        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values =await _mediator.Send(new GetSocialMediaQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia
        (CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal Medya Başarıyla Eklendi...");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var values = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("SSosyal Medya Başarıyla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal Medya Başarıyla Güncellendi.");
            
        }
    }
}