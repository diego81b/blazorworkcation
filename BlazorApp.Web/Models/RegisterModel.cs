using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Web.Models
{
    public class RegisterModel
    {
        [Required(AllowEmptyStrings = false)] public string Username { get; set; }

        [Required(AllowEmptyStrings = false)] public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)] public string LastName { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [Required(AllowEmptyStrings = false)] public string Password { get; set; }

        [Required] public bool Privacy { get; set; }
    }
}