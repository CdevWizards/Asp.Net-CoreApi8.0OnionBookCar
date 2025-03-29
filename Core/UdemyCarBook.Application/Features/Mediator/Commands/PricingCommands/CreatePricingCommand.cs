using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands
{
    public class CreatePricingCommand :IRequest
    {
       //  public int PricingID { get; set; }
        public string Name { get; set; }  
    }
}