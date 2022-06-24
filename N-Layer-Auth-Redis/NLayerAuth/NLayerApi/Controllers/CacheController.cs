using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerCore.Models;
using NLayerCore.Services;

namespace NLayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(await _cacheService.GetValueAsync(key));
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CacheRequestModel model)
        {
            await _cacheService.SetValueAsync(model.Key, model.Value);
            return Ok();
        }
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            await _cacheService.Clear(key);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            _cacheService.ClearAll();
            return Ok();
        }
    }
}
