using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using Microsoft.EntityFrameworkCore;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
     private readonly  CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }


        public List<Car> GetCarsWithBrands()
        {
            var values =_context.Cars.Include(x=> x.Brand).ToList();
            return values;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).
            OrderByDescending
            (x=> x.CarID).Take(5).ToList();
            return values;
        }

    }
}