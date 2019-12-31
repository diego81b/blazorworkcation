using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BlazorApp.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        private readonly ILazyLoader _lazyLoader;
        private ICollection<ApplicationUserRole> _userRoles;

        public ApplicationUser() { }

        public ApplicationUser(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public ICollection<ApplicationUserRole> UserRoles
        {
            get => _lazyLoader.Load(this, ref _userRoles);
            set => _userRoles = value;
        }
    }
}