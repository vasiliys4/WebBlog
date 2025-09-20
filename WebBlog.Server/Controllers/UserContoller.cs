using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBlog.Server.Models.IdentityModel;
using WebBlog.Server.Models.VIewModel;
using WebBlog.Server.Services;

namespace WebBlog.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserContoller : Controller
    {
        private readonly UserService _userService;
        public UserContoller(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> UserRegister([FromBody] UserViewModel user)
        {
            await _userService.Register(user.userName, user.email, user.password);

            return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> UserLogin([FromBody] UserViewModel user)
        {
            if (user == null || string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.password))
                return BadRequest("Invalid user data");

            var token = await _userService.Login(user);

            if (string.IsNullOrEmpty(token))
                return Unauthorized("Invalid credentials");

            HttpContext.Response.Cookies.Append("tasty-cookies", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            return Ok(new { token });
        }
    }
}
