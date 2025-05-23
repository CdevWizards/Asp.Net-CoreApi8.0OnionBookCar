using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;

using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery,
     GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                 BlogID=values.BlogID,
                 AuthorID =values.AuthorID,
                  CategoryID = values.CategoryID,
                   CoverImageUrl = values.CoverImageUrl,
                    CreatedDate = values.CreatedDate,
                    Description = values.Description,
                     Title = values.Title
            };
        }
    }
}