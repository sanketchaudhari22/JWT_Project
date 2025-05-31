using JWT_Project.Model.Domain;
using JWT_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin user)
        {
            if (user.Username == "admin" && user.Password == "admin123")
            {
                var token = _tokenService.GenerateToken(user.Username);
                return Ok(new { token });
            }

            return Unauthorized("Wrong credentials 😵");
        }

        [HttpGet("profile")]
        [Authorize]
        public IActionResult Profile()
        {
            var username = User.Identity.Name;
            return Ok(new { message = $"Welcome back {username} 🔥" });
        }
    }
}
