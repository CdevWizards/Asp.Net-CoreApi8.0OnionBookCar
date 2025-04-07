using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
         public int BlogCount { get; set; }
          public int BrandCount { get; set; }
          public decimal avgPriceForDaily { get; set; }
           public decimal avgPriceForWeekly { get; set; }
           public decimal avgPriceForMonthly { get; set; }
           public int carCountByTransmissonIsAuto { get; set; }

        
    }
}