using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Result.AboutResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;


namespace UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _reposityory;

        public GetAboutQueryHandler(IRepository<About> reposityory)
        {
            _reposityory = reposityory;
        }
        public async Task<List<GetAboutQueryResult>>  Handle()
        {
            var values = await _reposityory.GetAllAsync();
            return values.Select(x=>new GetAboutQueryResult()
            { 
               AboutID = x.AboutID,
                Title = x.Title,
                 Description = x.Description,
                   ImageUrl = x.ImageUrl,
            }).ToList();
        }
    }
}