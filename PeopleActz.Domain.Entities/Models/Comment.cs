using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Domain.Entities.Models
{
    public class Comment : IBaseEntity
    {
        public string Id { get; set ; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }

        public Post Post { get; set; }
      
    }
}
