using WebBlog.Server.Models.IdentityModel;

namespace WebBlog.Server.RepositoryModel.IdentityRepository
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<User> GetByEmail(string email);
    }
}
