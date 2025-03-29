using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler:IRequestHandler<UpdateBlogCommand>

    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }


        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BlogID);
            values.BlogID = request.BlogID;
            values.AuthorID = request.AuthorID;
            values.CategoryID = request.CategoryID;
            values.CoverImageUrl = request.CoverImageUrl;
            values.CreatedDate = request.CreatedDate;
            await _repository.UpdateAsync(values);
            
        }
    }
}