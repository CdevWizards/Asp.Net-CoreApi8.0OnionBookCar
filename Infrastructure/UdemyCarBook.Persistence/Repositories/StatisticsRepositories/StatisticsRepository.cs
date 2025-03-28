using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string BlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public string BrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }

        public int GetAuthorCount()
        {
            var value=_context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //SELECT Avg(Amount) FROM carpricings where PricingID=(SELECT PricingID FROM Pricings Where Name='Günlük')
            int id = _context.Pricings.Where(y=>y.Name =="Günlük").Select(z=>z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w=>w.PricingID == id).Average(x=> x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
              //SELECT Avg(Amount) FROM carpricings where PricingID=(SELECT PricingID FROM Pricings Where Name='Günlük')
            int id = _context.Pricings.Where(y=>y.Name =="Aylık").Select(z=>z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w=>w.PricingID == id).Average(x=> x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
              //SELECT Avg(Amount) FROM carpricings where PricingID=(SELECT PricingID FROM Pricings Where Name='Günlük')
            int id = _context.Pricings.Where(y=>y.Name =="Haftalık").Select(z=>z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w=>w.PricingID == id).Average(x=> x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }

        public int GetCarCount()
        {
            var values = _context.Cars.Count();
            return values;
        }

        public int GetCarCountByFuelElectric()
        {
             var value = _context.Cars.Where(x=> x.Fuel == "Elektrik").Count();
            return value; 
        }

        public int GetCarCountByFuelGasolineorDiesel()
        {
            var value = _context.Cars.Where(x=> x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value; 
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x=>x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissonIsAuto() 
        {
           var value=_context.Cars.Where(x=>x.Transmission =="Otomatik").Count();
           return value;
        }

        public int GetLocationCount()
        {
            var value=_context.Locations.Count();
            return value;
        }
    }
}