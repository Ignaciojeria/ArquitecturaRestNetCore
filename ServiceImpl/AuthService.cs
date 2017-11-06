using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiNetCore.Entity;
using WebApiNetCore.IService;
using WebApiNetCore.Jwt;
using WebApiNetCore.Model;

namespace WebApiNetCore.ServiceImpl
{
    public class AuthService : IAuthService
    {
        //Inyectamos la dependencia
        readonly IOptions<JwtConfiguration> _jwtConfig;

        public AuthService(IOptions<JwtConfiguration> jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public string GenerateTokenForUser(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Value.Secret));
            var header = new JwtHeader(new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            var issuer = _jwtConfig.Value.Issuer;

            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }
                .Concat(user.Roles.Select(role => new Claim("role", role)));

            var payload = new JwtPayload(issuer, null, claims, null, DateTime.Now.AddMinutes(30));

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
