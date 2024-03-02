﻿using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagementSystem.Helper
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJwtToken(Users user)
        {
            //list all our claims (information about the user)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = Encoding.UTF8.GetBytes(_configuration["jwt:key"]);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(30));

            var token = new JwtSecurityToken(
                _configuration["jwt:Issuer"],
                _configuration["jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

    

