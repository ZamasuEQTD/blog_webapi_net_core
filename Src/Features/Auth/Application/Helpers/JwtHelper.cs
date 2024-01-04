using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core;
using Microsoft.IdentityModel.Tokens;
using Users.Domain;

namespace Auth.Application
{
    public interface IJwtHelper {
        public string Firmar(User user);
    }

    public class JwtHelper : IJwtHelper
    {
        private readonly JwtConfig _config;
        public JwtHelper(JwtConfig config)
        {
         _config = config;   
        }
        public string Firmar(User user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,_config.Subject),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("UsuarioId", user.Id.Value.ToString() )
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config.Issuer,
                _config.Audience,
                claims,
                signingCredentials: signIn
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}