using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results;

namespace UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery :IRequest<List<GetFeatureQueryResult>>
    {
        
    }
}