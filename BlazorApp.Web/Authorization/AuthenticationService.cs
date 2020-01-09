using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Models.Entities;
using BlazorApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlazorApp.Web.Authorization
{
    public class AuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppClaimsPrincipalFactory _claimsPrincipalFactory;
        private readonly ServerAuthenticationStateProvider _authenticationStateProvider;
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            AppClaimsPrincipalFactory claimsPrincipalFactory,
            ServerAuthenticationStateProvider authenticationStateProvider,
            IAuthorizationService authorizationService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _claimsPrincipalFactory = claimsPrincipalFactory;
            _authenticationStateProvider = authenticationStateProvider;
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginModel model)
        {
            var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.Username);
            if (appUser == null) throw new AuthenticationException();

            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (!result.Succeeded) throw new AuthenticationException();
                var principal = await _claimsPrincipalFactory.CreateAsync(appUser);

                _authenticationStateProvider.SetAuthenticationState(Task.FromResult(new AuthenticationState(principal)));

                return await BuildToken(appUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                var state = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                _authenticationStateProvider.SetAuthenticationState(Task.FromResult(state));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> BuildToken(ApplicationUser user)
        {
            if (user == null) throw new Exception("User not found");
            var principal = await _claimsPrincipalFactory.CreateAsync(user);

            var keyByteArray = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("publicKey"));
            var singinKey = new SymmetricSecurityKey(keyByteArray);

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Auth:JwtKey").Value));
            var creds = new SigningCredentials(singinKey, SecurityAlgorithms.HmacSha256);
            // TODO impostare default se il parametro è null o < 0
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration.GetValue<string>("JwtExpireDays")));
            var token = new JwtSecurityToken(
                _configuration.GetValue<string>("JwtIssuer"),
                _configuration.GetValue<string>("privateKey"),
                principal.Claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}