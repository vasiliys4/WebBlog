namespace WebBlog.Server.RepositoryModel.IdentityRepository
{
    public interface IPasswordHasher
    {
        string GeneratePassword(string password);
        bool VerifyPasswordAsync(string password, string hashedPassword);
    }
}
