using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.DTOs.Requests.AppUser
{
    public class RegisterRequest
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword { get; set; }
        public ICollection<string>? Roles { get; init; }
    }
}
