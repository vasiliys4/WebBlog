using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBlog.Server.Models.IdentityModel;
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
        public async Task<IActionResult> UserRegister(UserService userService, User user)
        {
            await _userService.Register(user.UserName, user.Email, user.PasswordHash);

            return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> UserLogin(User user, UserService userService)
        {
            var token = await _userService.Login(user.Email, user.PasswordHash);

            return Ok(token);
        }
    }
}
