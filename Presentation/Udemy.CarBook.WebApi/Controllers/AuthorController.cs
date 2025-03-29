using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var values =await _mediator.Send(new GetAuthorQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor
        (CreateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yazar Bilgisi Eklendi...");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var values = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Yazar Bilgisi Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yazar Bilgisi Güncellendi.");
            
        }
    }
}