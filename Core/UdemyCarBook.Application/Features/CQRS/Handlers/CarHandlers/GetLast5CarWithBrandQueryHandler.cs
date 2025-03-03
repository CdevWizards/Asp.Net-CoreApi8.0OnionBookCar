using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Result.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarWithBrandQueryHandler
    {
          private readonly ICarRepository _repository;

        public GetLast5CarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public  List<GetCarWithBrandQueryResult>Handle()
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x=> new GetCarWithBrandQueryResult
            {
               CarID = x.CarID,
            BrandName = x.Brand.Name,
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