using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudsCommand>

    {
        private readonly IRepository<TagCloud> _repository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTagCloudsCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TagCloud 
            {
                 BlogId = request.BlogId,
                  Title = request.Title
            });
        }
    }
}