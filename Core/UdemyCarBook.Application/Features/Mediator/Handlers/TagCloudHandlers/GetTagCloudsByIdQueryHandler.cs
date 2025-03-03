using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudsResults;
using UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudsHandlers;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudsHandlers
{
    public class GetTagCloudsByIdQueryHandler :
    IRequestHandler<GetTagCloudByIdQuery, GetTagCloudsByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudsByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudsByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudsByIdQueryResult
            {
                 TagCloudId = values.TagCloudId,
                 BlogId = values.BlogId,
                  Title = values.Title
                  
            };
        }
    }
}