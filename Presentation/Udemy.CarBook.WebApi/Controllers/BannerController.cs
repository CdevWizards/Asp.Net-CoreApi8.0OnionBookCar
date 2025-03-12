using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BannerQueries;
namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _creatBannerCommandHandler;
        private readonly  GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;


        public BannerController(CreateBannerCommandHandler createBannerCommandHandler,
        GetBannerByIdQueryHandler getBannerByIdQueryHandler,GetBannerQueryHandler getBannerQueryHandler,
        UpdateBannerCommandHandler updateBannerCommandHandler,RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _creatBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handle(
                new GetBannerByIdQuery(id));
                return Ok(value);
        }
         [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
           await _creatBannerCommandHandler.Handle(command);
           return Ok("Bilgi Eklendi");
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBanner (int id)
        {
           await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
           return Ok("Bilgi Silindi");
        } [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommands command)
        {
           await _updateBannerCommandHandler.Handle(command);
           return Ok("Bilgi Güncellendi");
        }
    }
}