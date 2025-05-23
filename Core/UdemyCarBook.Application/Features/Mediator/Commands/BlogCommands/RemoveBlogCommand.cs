using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand:IRequest
    { 
        public RemoveBlogCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}