using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SupplyLink.Core.Account;
using SupplyLink.Core.Entities;
using SupplyLink.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly SupplyLinkDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateService(SupplyLinkDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public bool Authenticate(string email, string senha)
        {
            var user = _context.Users.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if(user == null) 
            {
                return false;
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            for (int i = 0; i < hash.Length; i++) 
            {
                if (hash[i] != user.PasswordHash[i]) return false;
            }
            return true;
        }

        public string GenerateToken(int id, string email)
        {
            
            var claims = new[]
            {
                new Claim("id",id.ToString()),
                new Claim("email",email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(privateKey,SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User>GetUserByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
             
        }

        public bool UserExists(string email)
        {
            var user = _context.Users.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
