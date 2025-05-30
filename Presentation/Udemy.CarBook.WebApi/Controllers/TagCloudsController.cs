using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagCloudsController : ControllerBase
     {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagCloudsList()
        {
            var values =await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagClouds
        (CreateTagCloudsCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Bulutu Başarıyla Eklendi...");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagClouds(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTagClouds(int id)
        {
            await _mediator.Send(new RemoveTagCloudsCommand(id));
            return Ok("Etiket Bulutu Başarıyla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTagClouds(UpdateTagCloudsCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Bulutu Başarıyla Güncellendi.");
            
        }
        [HttpGet("GetTagCloudByBlogId")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
             var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(values);
        }
    }
}