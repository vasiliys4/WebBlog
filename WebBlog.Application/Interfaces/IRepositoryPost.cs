using WebBlog.Server.Models.Model;

namespace WebBlog.Application.Interfaces
{
    public interface IRepositoryPost
    {
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task<Post> DeletePost(int id);
        Task<Post> GetPostById(int id);
        Task<List<Post>> GetAllPost();
    }
}
