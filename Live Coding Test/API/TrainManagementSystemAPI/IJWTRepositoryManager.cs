using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainManagementSystemAPI.Models;

namespace TrainManagementSystemAPI
{
    public interface IJWTRepositoryManager
    {
        Object Authenticate(User user);
    }
    public class JWTRepositoryManager : IJWTRepositoryManager
    {
        public TrainManagementSystemContext trainManagement { get; set; }

        private readonly string tokenKey;
        public JWTRepositoryManager( string tokenKey, TrainManagementSystemContext trainManagement)
        {
            this.tokenKey = tokenKey;
            this.trainManagement = trainManagement;

        }

        public object Authenticate(User user)
        {
            var users = trainManagement.Users.Where(u => u.EmailId == user.EmailId && u.Password == user.Password).SingleOrDefault();

            if (users != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(tokenKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,users.UserName),
                   
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                
                return new
                {
                    token = jwtToken,
                   
                };
            }
            else
            {
                return null;
            }
        }
        
    }
}
