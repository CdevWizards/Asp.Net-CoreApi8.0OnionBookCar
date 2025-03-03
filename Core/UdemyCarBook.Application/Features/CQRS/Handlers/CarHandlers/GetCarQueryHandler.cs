using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Result.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
          private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car>repository)
        {
            _repository = repository;
        }


        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetCarQueryResult
            {
               CarID = x.CarID,
               BrandID = x.BrandID,
               Model = x.Model,
               CoverImageUrl = x.CoverImageUrl,
               Km = x.Km,
               Transmission = x.Transmission,
               Seat = x. Seat,
               Luggage = x.Luggage,
               Fuel = x.Fuel,
               BigImageUrl = x.BigImageUrl
            }).ToList();
            
        }
    }
}