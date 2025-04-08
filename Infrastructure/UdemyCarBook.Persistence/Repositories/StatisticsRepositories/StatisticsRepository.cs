using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public string GetBlogTitleByMaxBlogComment()
        {
            //SELECT  BlogID,Count(*) as 'Sayi' From comments group by BlogID order by Sayi desc Limit 1;
            var values = _context.Comments.GroupBy(x => x.BlogID).
                             Select(y => new
                             {
                                 BlogID = y.Key,
                                 Count = y.Count()
                                 
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefault();
            return blogName;
        }

        public string GetBrandNameByMaxCar()
        {
            //Select Top(1) BrandId,Count(*) as 'ToplamArac' From Cars Group By Brands.Name  order By ToplamArac Desc
          
            var values = _context.Cars.GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                                 
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Cars.Where(x => x.BrandID == values.BrandID).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandName;
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
            // SELECT * FROM udemycarbookdb.carpricings Where PricingID=(SELECT PricingID FROM pricings Where Name="Günlük") and Amount=(SELECT max(Amount) From carpricings Where PricingID=3)
             int PricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == 3).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            // SELECT * FROM udemycarbookdb.carpricings Where PricingID=(SELECT PricingID FROM pricings Where Name="Günlük") and Amount=(SELECT max(Amount) From carpricings Where PricingID=3)
             int PricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == 3).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
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