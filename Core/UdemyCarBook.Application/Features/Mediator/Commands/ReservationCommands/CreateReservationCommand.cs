using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands
{
    public class CreateReservationCommand : IRequest
    {
        //public int ReservationID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int? PickUpLocationID { get; set; }
        public int? DropOffLocationID { get; set; }
        public int Phone { get; set; }
        public int CarID { get; set; }
        //public string PickUpLocationID { get; set; }
        public int Age { get; set; }
        public string DriverLicenceYear { get; set; }
        public string Description { get; set; }
        
        // public Location PickUpLocation { get; set; } 
        // public Location DropOffLocation { get; set; }
    }
}