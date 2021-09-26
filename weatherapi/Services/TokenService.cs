using DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace weatherapi.Services
{
    public static class TokenService
    {
        private const double Expiretime = 1.0;
        public static string CreateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenHandeler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(Expiretime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandeler.CreateToken(descriptor);
            return tokenHandeler.WriteToken(token);
        }

    }
}
