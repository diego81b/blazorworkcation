using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BlazorApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlazorApp.Web.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public string BuildToken(ApplicationUser user)
        {
            if (user == null) throw new Exception("User not found");
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                new Claim(ClaimTypes.Name, user.FirstName ?? user.UserName),
                new Claim(ClaimTypes.Surname, user.LastName ?? string.Empty)
            };

            var roles = _userManager.GetRolesAsync(user).Result;
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var keyByteArray = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("publicKey"));
            var singinKey = new SymmetricSecurityKey(keyByteArray);

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Auth:JwtKey").Value));
            var creds = new SigningCredentials(singinKey, SecurityAlgorithms.HmacSha256);
            // TODO impostare default se il parametro è null o < 0
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration.GetValue<string>("JwtExpireDays")));
            var token = new JwtSecurityToken(
                _configuration.GetValue<string>("JwtIssuer"),
                _configuration.GetValue<string>("privateKey"),
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}