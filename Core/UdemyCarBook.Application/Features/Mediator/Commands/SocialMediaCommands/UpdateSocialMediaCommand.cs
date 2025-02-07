using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class UpdateSocialMediaCommand :IRequest
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Icon { get; set; } 
    }
}