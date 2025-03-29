using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAdressResults;
using UdemyCarBook.Application.Features.Mediator.Results;

namespace UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
    {

    }
}