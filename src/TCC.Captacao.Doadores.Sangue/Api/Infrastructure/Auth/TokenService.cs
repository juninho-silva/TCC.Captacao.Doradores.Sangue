using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Infrastructure.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly string _secret;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public TokenService(IConfiguration configuration)
        {
            _secret = configuration.GetValue<string>("JwtSettings:Secret");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usernameOrEmail"></param>
        /// <returns></returns>
        public string GenerateToken(string usernameOrEmail)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("name", usernameOrEmail) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
