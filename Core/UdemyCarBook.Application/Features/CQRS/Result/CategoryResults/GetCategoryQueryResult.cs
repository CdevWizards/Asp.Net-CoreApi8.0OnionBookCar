using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Result.CategoryResults
{
    public class GetCategoryQueryResult
    {
         public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}