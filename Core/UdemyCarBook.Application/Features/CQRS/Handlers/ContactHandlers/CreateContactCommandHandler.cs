using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
   {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle (CreateContactCommand command)
        {
            await _repository.CreateAsync(new Contact
            {
                 Name = command.Name,
                 Email = command.Email,
                 Subject = command.Subject,
                 Message = command.Message,
                 SendDate = command.SendDate
            });
        }
    }
}