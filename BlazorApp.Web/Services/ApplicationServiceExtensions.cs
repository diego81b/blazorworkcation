using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BlazorApp.Infrastructure;
using BlazorApp.Models.Entities;
using BlazorApp.Web.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BlazorApp.Web.Services
{
    public static class ApplicationServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            //services.AddScoped<IFileManagerService, UploadService>();
            services.AddScoped<AuthenticationService>();
            services.AddScoped(typeof(DbContext), x => x.GetRequiredService(typeof(ApplicationDbContext)));
            services.AddScoped<ServerAuthenticationStateProvider>();
            services.AddHttpClient();
        }

        public static void AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            // ===== Add Identity ========
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    // Example @C0mm1t!
                    // Password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;

                    options.User.RequireUniqueEmail = true;

                    options.SignIn.RequireConfirmedAccount = true;

                    options.ClaimsIdentity.UserIdClaimType = JwtRegisteredClaimNames.Sub;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddClaimsPrincipalFactory<AppClaimsPrincipalFactory>()
                .AddDefaultTokenProviders();

            services.AddScoped<AppClaimsPrincipalFactory>();
        }

        public static void AddJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration.GetValue<string>("JwtIssuer"),
                        ValidAudience = configuration.GetValue<string>("privateKey"),
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(configuration.GetValue<string>("publicKey"))),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", c => c.RequireRole("ADMIN"));
            });
        }
    }
}
