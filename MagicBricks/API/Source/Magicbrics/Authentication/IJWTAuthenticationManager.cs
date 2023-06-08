using Magicbrics.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Magicbrics.Authentication
{
    public interface IJWTAuthenticationManager
    {
        Object Authenticate(LoginModel user);

    }
    public class JWTAuthenticationManager: IJWTAuthenticationManager
    {
        public magicbrics2392jeetContext context { get; set; }



        private readonly string tokenKey;
        public JWTAuthenticationManager(string tokenKey, magicbrics2392jeetContext dbcontext)
        {
            this.tokenKey = tokenKey;
            context = dbcontext;
        }
        public object Authenticate(LoginModel model)
        {
            var user = context.Users.Where(u => (u.Email==model.EmailOrPhone)||(u.PhoneNo==model.EmailOrPhone)).FirstOrDefault();
            var isUser=   BCrypt.Net.BCrypt.Verify(model.pswd, user.Password);

            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(tokenKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var Role = user.Role;

                return new
                {
                    token = jwtToken,
                    role = Role,
                    uId = user.UserId
                };
            }
            else
            {
                return new Response() { Status = 402, Message = "Unauthorized Access" };
            }
        }


    }

}
