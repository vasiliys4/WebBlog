using Microsoft.EntityFrameworkCore;
using WebBlog.Server.Models.IdentityModel;

namespace WebBlog.Server.Data
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
