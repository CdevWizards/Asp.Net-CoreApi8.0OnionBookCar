using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithTimePeriodQueryResult
    {
        public string Model { get; set; }
        public decimal DailyAmount { get; set; }
         public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}