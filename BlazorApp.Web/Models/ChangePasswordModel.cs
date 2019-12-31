using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Web.Models
{
    public class ChangePasswordModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NewPassword { get; set; }
    }
}