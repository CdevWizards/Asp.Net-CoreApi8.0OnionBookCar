using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands
{
    public class RemovePricingCommand : IRequest
    {
        public RemovePricingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}