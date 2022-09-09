using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.DTOs.Responses.AppUser
{
    public class RegisterResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<string>? Roles { get; init; }
    }
}
