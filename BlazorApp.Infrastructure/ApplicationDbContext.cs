using System;
using System.Collections.Generic;
using System.Linq;
using BlazorApp.Infrastructure.Migrations;
using BlazorApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<
        ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<WeatherForecast>().HasData(GetForecasts(new DateTime(2019, 12, 12)));
            builder.Entity<ApplicationRole>().HasData(GetRoles());
            builder.Entity<ApplicationUser>().HasData(GetUsers());
            builder.Entity<ApplicationUserRole>().HasData(GetApplicationUserRoles());
        }

        private static string[] Summaries => new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        private static WeatherForecast[] GetForecasts(DateTime startDate)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = startDate.AddDays(index),
                TemperatureC = index * 20,
                Summary = Summaries[index]
            }).ToArray();
        }

        private static ApplicationRole[] GetRoles()
        {
            return new[]
            {
                new ApplicationRole
                {
                    Id = "438B1BE9-79AD-4F56-8249-55380AF05BDC",
                    Name = "ADMIN",
                    NormalizedName = "ADMIN"
                },
                new ApplicationRole
                {
                    Id = "E5C52454-11F9-4486-BF9F-9A841C76BC77",
                    Name = "USER",
                    NormalizedName = "USER"
                },
            };
        }

        private static ApplicationUser[] GetUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser
            {
                Id = "6B6C81F4-19FD-4D2F-BC5F-052BF87FE152",
                Email = "baldeschidiego@gmail.com",
                FirstName = "Diego",
                LastName = "Baldeschi",
                EmailConfirmed = true,
                UserName = "diego.baldeschi",
                PasswordHash = hasher.HashPassword(null, "@TempPwd!")
            };

            var admin = new ApplicationUser
            {
                Id = "9ADF9CD9-858A-47B6-8399-E3D09B790D1F",
                Email = "admin@mail.com",
                FirstName = "Admin",
                LastName = "Admin",
                EmailConfirmed = true,
                UserName = "administrator",
                PasswordHash = hasher.HashPassword(null, "@TempPwd!")
            };

            return new[]
            {
                user, admin
            };
        }

        private static ApplicationUserRole[] GetApplicationUserRoles()
        {
            return new []
            {
                new ApplicationUserRole
                {
                    UserId = "6B6C81F4-19FD-4D2F-BC5F-052BF87FE152",
                    RoleId = "E5C52454-11F9-4486-BF9F-9A841C76BC77"
                },
                new ApplicationUserRole
                {
                    UserId = "9ADF9CD9-858A-47B6-8399-E3D09B790D1F",
                    RoleId = "438B1BE9-79AD-4F56-8249-55380AF05BDC"
                }
            };
        }
    }
}
