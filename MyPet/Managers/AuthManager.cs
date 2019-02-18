using System;
using Microsoft.Extensions.Options;
using MyPet.Data.Interfaces;
using MyPet.Managers.Interfaces;
using MyPet.Models;
using MyPet.Utils;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MyPet.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly AppSettings appSettings;
        private readonly IUserRepository userRepository;

        public AuthManager(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            this.appSettings = appSettings.Value;
            this.userRepository = userRepository;
        }
        public string Authenticate(string userName, string password)
        {
            var user = userRepository.Records
                .FirstOrDefault(x => x.UserName == userName && x.Password == HashHelper.GetHashedData(password));

            if (user == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
