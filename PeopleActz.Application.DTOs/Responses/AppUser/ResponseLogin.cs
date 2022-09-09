using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.DTOs.Responses.AppUser
{
    public class ResponseLogin
    {
        public string Token { get; set; }
        public IList<string> Role { get; set; } = new List<string>();
        public bool IsLoginSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }
}
