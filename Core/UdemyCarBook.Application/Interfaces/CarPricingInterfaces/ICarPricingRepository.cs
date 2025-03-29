using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarPricingRepository
{
    public interface ICarPricingRepository
    {
        Task<IEnumerable<object>> GetAllAsync();
        List<CarPricing> GetCarsPricingWithCars(); 
    }
}