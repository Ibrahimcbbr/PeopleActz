using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.DTOs.Requests.Comment
{
    public class CommentUpdateRequest
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
    }
}
