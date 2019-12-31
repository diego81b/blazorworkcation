using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace BlazorApp.Models.Entities
{
    public class ApplicationRole : IdentityRole
    {
        private readonly ILazyLoader _lazyLoader;
        private ICollection<ApplicationUserRole> _userRoles;

        public ApplicationRole()
        {

        }
        public ApplicationRole(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public ICollection<ApplicationUserRole> UserRoles
        {
            get => _lazyLoader.Load(this, ref _userRoles);
            set => _userRoles = value;
        }
    }
}
