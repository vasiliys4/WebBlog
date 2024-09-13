using Microsoft.AspNetCore.Mvc;
using WebBlog.Server.Models.VIewModel;
using WebBlog.Server.Services;

namespace WebBlog.Server.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly PostServices postServices;
        public HomeController(PostServices postServices)
        {
            this.postServices = postServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await postServices.GetAllPostsAsync();
            return Ok(posts);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await postServices.GetPostAsync(id);
            return Ok(post);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel post)
        {
            await postServices.CreatePsotAsync(post);
            return Ok(post);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdatePost(PostViewModel post)
        {
            await postServices.UpdatePostAsync(post);
            return Ok(post);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePost(PostViewModel post)
        {
            await postServices.DeletePostAsync(post);
            return Ok();
        }
    }
}
