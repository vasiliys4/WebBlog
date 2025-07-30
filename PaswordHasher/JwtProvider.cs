using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebBlog.Server.Models.IdentityModel;
using WebBlog.Server.RepositoryModel.IdentityRepository;


namespace PaswordHasher
{
    public class JwtProvider(IOptions<JwtOption> options) : IJwtProvider
    {
        private readonly JwtOption _option = options.Value;

        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_option.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_option.ExpitesHours));

            var tokenVAlue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenVAlue;
        }
    }
}
