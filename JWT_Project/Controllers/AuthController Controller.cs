using JWT_Project.Model.Domain;
using JWT_Project.Repository;
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
        private readonly UserService _userService;

        public AuthController(TokenService tokenService, UserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin user)
        {
            var dbUser = _userService.GetUserByUsername(user.Username);
            if (dbUser != null && dbUser.PASSWORD == user.Password)
            {
                var token = _tokenService.GenerateToken(dbUser.USERNAME);
                return Ok(new
                {
                    token = token,
                    username = dbUser.USERNAME,
                    message = "Login successful 🎉",
                    role = dbUser.ROLE
                });
            }

            return Unauthorized("Wrong credentials 😵");
        }
    }
}