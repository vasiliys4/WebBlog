using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBlog.Server.Models.VIewModel;
using WebBlog.Server.Services;


namespace WebBlog.Server.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {
        private readonly PostServices _postServices;
        public HomeController(PostServices postServices) => _postServices = postServices;
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postServices.GetAllPostsAsync();
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postServices.GetPostAsync(id);
            if (post == null)
            {
                return BadRequest();
            }
            return Ok(post);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel post)
        {
            await _postServices.CreatePostAsync(post);
            return Ok(post);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> EditPost([FromBody] PostViewModel post,[FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _postServices.UpdatePostAsync(post, id);
            return Ok(post);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postServices.DeletePostAsync(id);
            return Ok();
        }
    }
}
