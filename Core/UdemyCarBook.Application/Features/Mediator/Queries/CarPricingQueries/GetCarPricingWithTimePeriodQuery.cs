using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithTimePeriodQuery : IRequest<List<GetCarPricingWithTimePeriodQueryResult>>
    {
        public string Model { get; set; }
        public decimal DailyAmount { get; set; }
         public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}