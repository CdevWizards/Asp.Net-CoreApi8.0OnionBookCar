using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudsHandlers
{
    public class RemoveTagCloudsCommandHandler : IRequestHandler<RemoveTagCloudsCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public RemoveTagCloudsCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTagCloudsCommand request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.Id);
           await _repository.RemoveAsync(value);
        }
    }
}