using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class RemoveTagCloudsCommand :IRequest
    {
        public int Id { get; set; }

        public RemoveTagCloudsCommand(int id)
        {
            Id = id;
        }
    }
}