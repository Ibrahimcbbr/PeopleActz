using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.DTOs.Responses.AppUser
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public IList<string> Role { get; set; } = new List<string>();
    }
}
