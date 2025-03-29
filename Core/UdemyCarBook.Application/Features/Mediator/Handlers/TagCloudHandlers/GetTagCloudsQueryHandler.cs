using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudsResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.TagCloudss.Mediator.Handlers.TagCloudsHandlers
{
    public class GetTagCloudsQueryHandler : IRequestHandler<GetTagCloudQuery,
     List<GetTagCloudsQueryResult>>
     {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudsQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudsQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetTagCloudsQueryResult
            {
                   TagCloudId = x.TagCloudId,
                 Title = x.Title,
                  BlogId =x.BlogId
            }).ToList();
        }
    }
}