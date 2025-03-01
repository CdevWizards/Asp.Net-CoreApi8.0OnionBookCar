using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class CreateTagCloudsCommand :IRequest
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}