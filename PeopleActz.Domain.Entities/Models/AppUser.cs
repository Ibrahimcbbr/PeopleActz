using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Domain.Entities.Models
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        
        public Post? Post { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
       
    }
}
