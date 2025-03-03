using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler :
    IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>

    {
        private readonly IBlogRepository _repository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogByAuthorId(request.Id);
            return values.Select( x=> new GetBlogByAuthorIdQueryResult
            {
                 AuthorDescription = x.Author.Description,
                 AuthorID =x.AuthorID,
                 BlogID = x.BlogID,
                // CategoryID = x.CategoryID,
                 //CoverImageUrl = x.CoverImageUrl,
                 //CreatedDate = x.CreatedDate,
                 //Title = x.Title,
                 AuthorName = x.Author.Name,
                 AuthorImageUrl = x.Author.ImageUrl,
                 //Description =x.Description,
            }).ToList();
        }
    }
}