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
    public class ProductFeatureController : CustomBaseController
    {
        private readonly IProductFeatureService<ProductFeature,ProductFeatureDto> _productFeatureService;

        public ProductFeatureController(IProductFeatureService<ProductFeature, ProductFeatureDto> productFeatureService)
        {
            this._productFeatureService = productFeatureService;
        }

        [HttpGet("{id}"),AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productFeatureService.GetByIdAsync(id);
            return ActionResultInstance(response);
        }

        /// <summary>
        /// Adds a feature to an existing product.
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> Create(int id, ProductFeatureDto productFeatureDto)
        {
            var response = await _productFeatureService.AddAsync(id, productFeatureDto);
            return ActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ProductFeatureDto productFeatureDto)
        {
            var response = await _productFeatureService.Update(productFeatureDto,id);
            return ActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productFeatureService.Remove(id);
            return ActionResultInstance(response);
        }



    }
}
