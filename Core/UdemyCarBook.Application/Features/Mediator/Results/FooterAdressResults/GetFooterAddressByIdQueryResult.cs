using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.FooterAdressResults
{
    public class GetFooterAddressByIdQueryResult
    {
       public int FooterAddressID { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
} 