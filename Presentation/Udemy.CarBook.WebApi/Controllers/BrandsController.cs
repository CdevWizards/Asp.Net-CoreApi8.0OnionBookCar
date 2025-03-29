using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _creatBrandCommandHandler;
        private readonly  GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;


        public BrandController(CreateBrandCommandHandler createBrandCommandHandler,
        GetBrandByIdQueryHandler getBrandByIdQueryHandler,GetBrandQueryHandler getBrandQueryHandler,
        UpdateBrandCommandHandler updateBrandCommandHandler,RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _creatBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _getBrandByIdQueryHandler.Handle(
                new GetBrandByIdQuery(id));
                return Ok(value);
        }
         [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
           await _creatBrandCommandHandler.Handle(command);
           return Ok("Bilgi Eklendi");
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand (int id)
        {
           await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
           return Ok("Bilgi Silindi");
        } [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
           await _updateBrandCommandHandler.Handle(command);
           return Ok("Bilgi Güncellendi");
        }
    }
}