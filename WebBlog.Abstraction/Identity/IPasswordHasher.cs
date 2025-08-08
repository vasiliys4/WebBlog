namespace WebBlog.Server.RepositoryModel.IdentityRepository
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
