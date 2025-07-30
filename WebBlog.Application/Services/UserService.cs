using WebBlog.Server.Models.IdentityModel;
using WebBlog.Server.RepositoryModel.IdentityRepository;


namespace WebBlog.Server.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider) 
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }
        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.GeneratePassword(password);

            var user = User.Create(Guid.NewGuid(), userName, hashedPassword, email);

            await _userRepository.AddUser(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            var result = _passwordHasher.VerifyPasswordAsync(user.PasswordHash, password);

            if (result == false) { }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
