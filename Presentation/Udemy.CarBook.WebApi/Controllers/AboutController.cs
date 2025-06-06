using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AboutController : ControllerBase
    {
        private readonly CreatAboutCommandHandler _creatAboutCommandHandler;
        private readonly  GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

        public AboutController(CreatAboutCommandHandler creatAboutCommandHandler,
        GetAboutByIdQueryHandler getAboutByIdQueryHandler,GetAboutQueryHandler getAboutQueryHandler,UpdateAboutCommandHandler updateAboutCommandHandler,
        RemoveAboutCommandHandler removeAboutCommandHandler)
        {
            _creatAboutCommandHandler = creatAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _creatAboutCommandHandler.Handle(command);
            return Ok("Hakkında Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımda Bilgisi Silindi."); 
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);

            return Ok("Hakkımda Bilgisi Güncellendi."); 
        }
         
    } 
}