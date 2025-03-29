using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingQuery:IRequest<List<GetCarPricingQueryResult>>
    {
        
    }
}