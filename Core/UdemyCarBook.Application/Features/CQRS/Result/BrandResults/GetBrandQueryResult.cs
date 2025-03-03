using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Result.BrandResults
{
    public class GetBrandQueryResult
    {
         public int BrandID { get; set; }
        public string Name { get; set; }
    }
}