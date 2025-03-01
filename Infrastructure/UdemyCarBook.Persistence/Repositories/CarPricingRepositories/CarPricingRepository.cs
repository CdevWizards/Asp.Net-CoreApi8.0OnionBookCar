using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.CarPricingRepository;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<object>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public List<CarPricing> GetCarsPricingWithCars()
        {
            var values=_context.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand)
            .Include(x=> x.Pricing).ToList();
            return values;
        }
    }
}