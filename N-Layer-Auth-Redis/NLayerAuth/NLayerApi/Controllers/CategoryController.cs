using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayerCore.DTOs;
using NLayerCore.Models;
using NLayerCore.Services;

namespace NLayerApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService<Category,CategoryDto> _categoryService;
        public CategoryController(ICategoryService<Category, CategoryDto> categoryService)
        {
            _categoryService = categoryService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return ActionResultInstance(response);
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            return ActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var response = await _categoryService.AddAsync(categoryDto);
            return ActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
        {
            var response = await _categoryService.Update(categoryDto,id);
            return ActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.Remove(id);
            return ActionResultInstance(response);
        }
    }
}
