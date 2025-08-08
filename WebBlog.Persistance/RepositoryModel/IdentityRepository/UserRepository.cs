using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebBlog.Server.Data;
using WebBlog.Server.Models.IdentityModel;


namespace WebBlog.Server.RepositoryModel.IdentityRepository
{
    public class UserRepository: IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserDBContext _context;
        public UserRepository(UserDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddUser(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
            };
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception("potomuchto");
            return _mapper.Map<User>(userEntity);
        }
    }
}
