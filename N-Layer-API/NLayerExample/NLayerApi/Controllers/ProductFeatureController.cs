using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerService;
using NLayerService.Dtos;

namespace NLayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeatureController : ControllerBase
    {
        private readonly ProductFeatureService _productFeatureService;

        public ProductFeatureController(ProductFeatureService productFeatureService)
        {
            this._productFeatureService = productFeatureService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productFeatureService.GetById(id);
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        /// <summary>
        /// Adds a feature to an existing product.
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> Create(int id, ProductFeatureDto productFeatureDto)
        {
            var response = await _productFeatureService.Create(id, productFeatureDto);
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ProductFeatureDto productFeatureDto)
        {
            var response = await _productFeatureService.Update(id, productFeatureDto);
            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var response = _productFeatureService.Delete(id);
            return new ObjectResult(response) { StatusCode = response.Status };
        }



    }
}
