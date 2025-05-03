using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.CarPricingRepository;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery,
    List<GetCarPricingQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarsPricingWithCars();
            return values.Select(x=> new GetCarPricingQueryResult
            {
                  Amount = x.Amount,
                  Brand =x.Car.Brand.Name,
                   CarPricingId = x.CarPricingID,
                   CoverImageUrl = x.Car.CoverImageUrl,
                   Model =x.Car.Model,
                   CarId = x.CarID
            }).ToList();
        }
    }
}