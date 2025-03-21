using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQuery
    {
        public GetContactByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}