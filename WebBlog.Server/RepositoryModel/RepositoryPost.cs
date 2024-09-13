using Microsoft.EntityFrameworkCore;
using WebBlog.Server.Data;
using WebBlog.Server.Models.Model;

namespace WebBlog.Server.RepositoryModel
{
    public class RepositoryPost : IRepositoryPost
    {
        private readonly WebBlogDBContext _dbContext;
        public RepositoryPost(WebBlogDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Post> CreatePost(Post post)
        {
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> DeletePost(Post post)
        {
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetAllPost()
        {
            return await _dbContext.Posts.Include(p => p.Content).ToListAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _dbContext.Posts.Include(p => p.Content).FirstOrDefaultAsync(p => p.PostId == id);
        }

        public async Task<Post> UpdatePost(Post post)
        {
            var oldPost = await _dbContext.Posts.FirstOrDefaultAsync(p => p.PostId == post.PostId);
            oldPost.Title = post.Title;
            oldPost.Content = post.Content;
            oldPost.Author = post.Author;
            await _dbContext.SaveChangesAsync();
            return post;
        }
    }
}
