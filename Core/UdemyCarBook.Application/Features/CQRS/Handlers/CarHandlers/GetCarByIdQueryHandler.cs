using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Result.AboutResults;
using UdemyCarBook.Application.Features.CQRS.Result.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
           private readonly IRepository<Car> _repository;
        
        public  GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                CarID = values.CarID,
               BrandID = values.BrandID,
               Model = values.Model,
               CoverImageUrl = values.CoverImageUrl,
               Km = values.Km,
               Transmission = values.Transmission,
               Seat = values. Seat,
               Luggage = values.Luggage,
               Fuel = values.Fuel,
               BigImageUrl = values.BigImageUrl
            };
        }
    }
}