using Microsoft.EntityFrameworkCore;
using WebBlog.Server.Models.Model;

namespace WebBlog.Server.Data
{
    public class WebBlogDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<ContentPost> ContentPosts { get; set; }
        public WebBlogDBContext(DbContextOptions<WebBlogDBContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
