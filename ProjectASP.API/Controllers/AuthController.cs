using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectASP.API.Core;
using ProjectASP.API.DTO;

namespace ProjectASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly JwtTokenCreator _jwtTokenCreator;

        public AuthController(JwtTokenCreator jwtTokenCreator)
        {
            _jwtTokenCreator = jwtTokenCreator;
        }

        [HttpPost("register")]
        public IActionResult Register()
        {

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            string token = _jwtTokenCreator.Create(request.Email, request.Password);

            return Ok(new AuthResponse { Token = token });
        }

        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Console.WriteLine("User logged out.");
            return Ok();
        }

    }
}
