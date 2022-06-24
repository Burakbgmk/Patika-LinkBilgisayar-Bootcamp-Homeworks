using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContextAuth _context;
        private readonly AuthenticationService _authenticationService;

        public AuthController(UserManager<AppUser> userManager, AppDbContextAuth context, AuthenticationService authenticationService)
        {
            _userManager = userManager;
            _context = context;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel viewModel)
        {
            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user == null) return BadRequest();

            if (!await _userManager.CheckPasswordAsync(user, viewModel.Password)) return BadRequest();

            var userClaims = _authenticationService.GetClaims(user);
            var userToken = new UserToken
            {
                AccessToken = CreateAccessToken(userClaims)
            };

            var userRefreshToken = await _context.UserRefreshTokens.SingleOrDefaultAsync(s => s.UserId == user.Id);
            if (userRefreshToken == null)
            {
                userToken.RefreshToken = CreateRefreshToken();

                await _context.UserRefreshTokens.AddAsync(new()
                {
                    UserId = user.Id,
                    Token = userToken.RefreshToken.Code,
                    Expiration = userToken.RefreshToken.Expiration
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                userToken.RefreshToken = new Token
                {
                    Code = userRefreshToken.Token,
                    Expiration = userRefreshToken.Expiration
                };
            }

            return Ok(userToken);
        }
    }
}
