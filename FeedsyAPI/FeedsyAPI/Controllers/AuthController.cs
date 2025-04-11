using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FeedsyAPI.Models;


namespace FeedsyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            // Add logic to handle user registration
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Add logic to handle user login
            return Ok(new { token = "sample-jwt-token" });
        }

        [HttpGet("me")]
        public IActionResult Me()
        {
            // Add logic to retrieve authenticated user information
            return Ok(new { user = "Authenticated user details" });
        }
    }
}
