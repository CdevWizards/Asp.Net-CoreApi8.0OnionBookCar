using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}