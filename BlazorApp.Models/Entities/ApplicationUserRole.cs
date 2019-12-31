using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BlazorApp.Models.Entities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        private readonly ILazyLoader _lazyLoader;
        private ApplicationUser _user;
        private ApplicationRole _role;

        public ApplicationUserRole()
        {
        }
        public ApplicationUserRole(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public ApplicationUser User 
        {
            get => _lazyLoader.Load(this, ref _user);
            set => _user = value;
        }

        public ApplicationRole Role
        {
            get => _lazyLoader.Load(this, ref _role);
            set => _role = value;
        }
    }
}