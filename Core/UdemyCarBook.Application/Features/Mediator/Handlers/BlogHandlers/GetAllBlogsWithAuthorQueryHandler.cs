using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
namespace UdemyCarBook.Application.AllBlogsWithAuthors.Mediator.Handlers.AllBlogsWithAuthorHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler 
    : IRequestHandler<GetAllBlogsWithAuthorQuery,
     List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetAllBlogsWithAuthors();
           return values.Select(x => new GetAllBlogsWithAuthorQueryResult
           {
    AuthorName = x.Author.Name,
    Title = x.Title,
    Description =x.Description,
    AuthorID = x.AuthorID,
    CategoryID = x.CategoryID,
    CoverImageUrl = x.CoverImageUrl,
    CreatedDate = x.CreatedDate,
    BlogID = x.BlogID,
    AuthorDescription = x.Author.Description,
    AuthorImageUrl = x.Author.ImageUrl
}).ToList();


        }
    }
}