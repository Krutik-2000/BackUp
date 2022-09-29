using EMS.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EMS
{
    public interface IJWTManagerRepository
    {
        Object Authenticate(User user);
        
    }
    public class JWTManagerRepository : IJWTManagerRepository
    {
        public EmployeeContext employeeContext { get; set; }

        private readonly string tokenKey;

        public JWTManagerRepository(string tokenKey, EmployeeContext employeeContext)
        {
            this.tokenKey = tokenKey;
            this.employeeContext = employeeContext;
        }

        public object Authenticate(User user)
        {
            var users = employeeContext.Users.Where(u => u.UserName == user.UserName && u.PasswordHash == user.PasswordHash).SingleOrDefault();

            if (users != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(tokenKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,users.UserName),
                    new Claim(ClaimTypes.Role,users.Role.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var Role = users.Role;
                return new
                {
                    token = jwtToken,
                    role = Role,
                };
            }
            else
            {
                return null;
            }
        }

    }
}
