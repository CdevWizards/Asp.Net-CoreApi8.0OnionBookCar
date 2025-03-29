using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuhorCount();
        int GetBlogCount();
        int GetBrandCount();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForWeekly();
        decimal GetAvgRentPriceForMonthly();

        int GetCarCountByTransmissonIsAuto();
        string BrandNameByMaxCar();
        string BlogTitleByMaxBlogComment();
        int GetCarCountByKmSmallerThen1000();
        int GetCarCountByFuelGasolineorDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();
        
    }
}