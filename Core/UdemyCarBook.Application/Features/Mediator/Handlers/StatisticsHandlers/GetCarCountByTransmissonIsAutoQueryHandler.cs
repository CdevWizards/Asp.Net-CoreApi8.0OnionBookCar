using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByTransmissonIsAutoQueryHandler: IRequestHandler<GetCarCountByTransmissonIsAutoQuery, GetCarCountByTransmissonIsAutoQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByTransmissonIsAutoQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByTransmissonIsAutoQueryResult> Handle(GetCarCountByTransmissonIsAutoQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByTransmissonIsAuto();
            return new GetCarCountByTransmissonIsAutoQueryResult
            {
                 CarCountByTransmissonIsAuto = value
            };
        }
    }
}