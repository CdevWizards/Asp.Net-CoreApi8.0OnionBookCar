using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _creatCarCommandHandler;
        private readonly  GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLast5CarWithBrandQueryHandler _getLastCar5WithBrandQueryHandler;
        

        public CarsController(CreateCarCommandHandler createCarCommandHandler,
        GetCarByIdQueryHandler getCarByIdQueryHandler,GetCarQueryHandler getCarQueryHandler,
        UpdateCarCommandHandler updateCarCommandHandler,RemoveCarCommandHandler removeCarCommandHandler,
        GetCarWithBrandQueryHandler getCarWithBrandQueryHandler,
        GetLast5CarWithBrandQueryHandler getLast5CarWithBrandQueryHandler)
        {
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _creatCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLastCar5WithBrandQueryHandler = getLast5CarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(
                new GetCarByIdQuery(id));
                return Ok(value);
        }
         [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
           await _creatCarCommandHandler.Handle(command);
           return Ok("Bilgi Eklendi");
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar (int id)
        {
           await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
           return Ok("Bilgi Silindi");
        } [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
           await _updateCarCommandHandler.Handle(command);
           return Ok("Bilgi Güncellendi");
        }
        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            var values = _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}