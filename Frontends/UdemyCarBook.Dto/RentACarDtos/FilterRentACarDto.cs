using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.RentACarDtos
{
    public class FilterRentACarDto
    {
        public int locationID { get; set; }
        public bool available { get; set; }
    }
}