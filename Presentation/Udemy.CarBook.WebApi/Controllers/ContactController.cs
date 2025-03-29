using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly CreateContactCommandHandler _creatContactCommandHandler;
        private readonly  GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;


        public ContactController(CreateContactCommandHandler createContactCommandHandler,
        GetContactByIdQueryHandler getContactByIdQueryHandler,GetContactQueryHandler getContactQueryHandler,
        UpdateContactCommandHandler updateContactCommandHandler,RemoveContactCommandHandler removeContactCommandHandler)
        {
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _creatContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(
                new GetContactByIdQuery(id));
                return Ok(value);
        }
         [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
           await _creatContactCommandHandler.Handle(command);
           return Ok("İletişim Eklendi");
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact (int id)
        {
           await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
           return Ok("İletişim Silindi");
        } [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
           await _updateContactCommandHandler.Handle(command);
           return Ok("İletişim Güncellendi");
        }
    }
}