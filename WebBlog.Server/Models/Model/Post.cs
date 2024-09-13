using WebBlog.Server.Models.IdentityModel;

namespace WebBlog.Server.Models.Model
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public User? Author { get; set; }
        public ContentPost? Content { get; set; }
        
    }
}
