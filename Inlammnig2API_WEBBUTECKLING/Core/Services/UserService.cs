using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;
using Inlammnig2API_WEBBUTECKLING.DTO;
using Inlammnig2API_WEBBUTECKLING.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inlammnig2API_WEBBUTECKLING.Core.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public Users Register(RegisterDTO dto)
        {
            var existingUser = _userRepo.GetUserByemail(dto.Email);

            if (existingUser != null)
                return null;

            var user = new Users
            {
                UserName = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            return _userRepo.CreateUser(user);
        }



        public string Logon(LogonDTO dto)
        {
            var user = _userRepo.GetUserByemail(dto.Email);

            if (user == null || user.Password != dto.Password)
                return null;

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mykey1234567&%%485734579453%&//1255362"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email)
    };

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5234",
                audience: "http://localhost:5234",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

