using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;


namespace UdemyCarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
       List<Car>GetCarsWithBrands();
       List<Car>GetLast5CarsWithBrands();
       int GetCarCount();
       
    }
}