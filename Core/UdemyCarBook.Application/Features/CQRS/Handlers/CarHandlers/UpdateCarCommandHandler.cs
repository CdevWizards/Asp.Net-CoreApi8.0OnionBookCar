using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
            private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
         var values = await _repository.GetByIdAsync(command.CarID);
         values.BrandID = command.BrandID;
         values.CarID =command.CarID;
         values.Model = command.Model;
         values.CoverImageUrl = command.CoverImageUrl;
         values.Km = command.Km;
         values.Transmission = command.Transmission;
         values.Seat = command.Seat;
         values.Luggage = command.Luggage;
          values.Fuel = command.Fuel;
          values.BigImageUrl = command.BigImageUrl;
          await _repository.UpdateAsync(values);
          
        }
    }
}