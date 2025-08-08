
using WebBlog.Server.RepositoryModel.IdentityRepository;

namespace PaswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GeneratePassword(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool VerifyPassword(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
