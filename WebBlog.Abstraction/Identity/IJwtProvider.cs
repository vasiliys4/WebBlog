
using WebBlog.Server.Models.IdentityModel;

namespace WebBlog.Server.RepositoryModel.IdentityRepository
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
