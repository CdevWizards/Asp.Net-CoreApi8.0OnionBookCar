using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommand :IRequest
    {
        public int Id { get; set; }

        public RemoveServiceCommand(int id)
        {
            Id = id;
        }
    }
}