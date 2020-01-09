using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models.Entities;
using BlazorApp.Web.Authorization;
using BlazorApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlazorApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AuthenticationService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            AuthenticationService authService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _configuration = configuration;
        }

        /// <summary>
        /// Chiamata alla login che restituisce un Token JWT da utilizzare nelle chiamate successive
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.Username);

            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (!result.Succeeded) return new UnauthorizedObjectResult(result);

                return Ok(_authService.BuildToken(appUser));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        /// <summary>
        /// registra un utente e restituisce il Token JWT da utilizzare nelle chiamate successive
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = true
            };

            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded) return new UnauthorizedObjectResult(result);

                var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.Username);

                await _userManager.AddToRoleAsync(appUser, "User");

                // Send Email

                return Ok();
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        /// <summary>
        /// Cambio password
        /// </summary>
        [HttpPost]
        [Authorize]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordModel model)
        {
            var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.Username);

            try
            {
                var result = await _userManager.ChangePasswordAsync(appUser, model.OldPassword, model.NewPassword);
                if (!result.Succeeded) return new UnauthorizedObjectResult(result);

                return Ok();
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}