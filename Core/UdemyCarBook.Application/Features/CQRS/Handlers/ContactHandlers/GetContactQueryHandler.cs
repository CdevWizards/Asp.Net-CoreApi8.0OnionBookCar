using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Result.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact>repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetContactQueryResult
            {
                  ContactID = x.ContactID,
                  Name = x.Name,
                  Email = x.Email,
                  Subject = x.Subject,
                  Message = x.Message,
                  SendDate = x.SendDate
            }).ToList();
        }
    }
}