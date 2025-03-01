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
    public class UpdateTagCloudsCommandHandler : IRequestHandler<UpdateTagCloudsCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudsCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudsCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudId);
            value.TagCloudId = request.TagCloudId;
            value.BlogId = request.BlogId;
            value.Title = request.Title;
            await _repository.UpdateAsync(value);
        }
    }
}