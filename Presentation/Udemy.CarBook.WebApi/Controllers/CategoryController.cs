using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;
namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _creatCategoryCommandHandler;
        private readonly  GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;


        public CategoryController(CreateCategoryCommandHandler createCategoryCommandHandler,
        GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,GetCategoryQueryHandler getCategoryQueryHandler,
        UpdateCategoryCommandHandler updateCategoryCommandHandler,RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _creatCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(
                new GetCategoryByIdQuery(id));
                return Ok(value);
        }
         [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
           await _creatCategoryCommandHandler.Handle(command);
           return Ok("Kategori Eklendi");
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory (int id)
        {
           await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
           return Ok("Kategori Silindi");
        } [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
           await _updateCategoryCommandHandler.Handle(command);
           return Ok("Kategori Güncellendi");
        }
    }
}