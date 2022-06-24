using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerCore.DTOs;
using NLayerCore.Services;

namespace NLayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var response = await _userService.CreateUserAsync(createUserDto);
            return ActionResultInstance(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser(string userName)
        {
            var response = await _userService.GetUserByNameAsync(userName);
            return ActionResultInstance(response);
        }
    }
}
