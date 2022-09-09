using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.DTOs.Requests.Post
{
    public class PostCreateRequest
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
    }
}
