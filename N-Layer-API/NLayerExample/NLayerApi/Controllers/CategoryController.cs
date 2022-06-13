using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerService;
using NLayerService.Dtos;

namespace NLayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAll();
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetById(id);
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var response = await _categoryService.Create(categoryDto);
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
        {
            var response = await _categoryService.Update(id, categoryDto);
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var response = _categoryService.Delete(id);
            return new ObjectResult(response) { StatusCode = response.Status };
        }
    }
}
