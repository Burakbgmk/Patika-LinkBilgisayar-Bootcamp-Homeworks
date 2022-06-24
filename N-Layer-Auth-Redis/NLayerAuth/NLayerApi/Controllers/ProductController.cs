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
    public class ProductController : CustomBaseController
    {
        
        private readonly IProductService<Product,ProductDto> _productService;
        public ProductController(IProductService<Product, ProductDto> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync();
            return ActionResultInstance(response);
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productService.GetByIdAsync(id);
            return ActionResultInstance(response);
        }

        /// <summary>
        /// Shows all the products with their categories and features.
        /// (Done by Store Procedure)
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFullModel")]
        public async Task<IActionResult> GetFullModel()
        {
            var response = await _productService.GetFullModel();
            return ActionResultInstance(response);
        }

        /// <summary>
        /// Shows all the products with their categories and features.
        /// (Done by Function)
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFullModelWithFunction")]
        public async Task<IActionResult> GetFullModelWithFunction()
        {
            var response = await _productService.GetFullModelWithFunction();
            return ActionResultInstance(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto product)
        {
            var response = await _productService.AddAsync(product);
            return ActionResultInstance(response);
        }

        /// <summary>
        /// Adds product with features.
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateWithFeatures")]
        public async Task<IActionResult> CreateWithFeatures(ProductDto productDto, [FromHeader] ProductFeatureDto productFeatureDto)
        {
            var response = await _productService.CreateWithFeatures(productDto, productFeatureDto);
            return ActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            var response = await _productService.Update(productDto,id);
            return ActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.Remove(id);
            return ActionResultInstance(response);
        }

    }
}
