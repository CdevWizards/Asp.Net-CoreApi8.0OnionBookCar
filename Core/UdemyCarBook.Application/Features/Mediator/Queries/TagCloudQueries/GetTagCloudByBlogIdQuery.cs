using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudsResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery: IRequest<List<GetTagCloudByBlogIdQueryResult>>
    {
        public GetTagCloudByBlogIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}