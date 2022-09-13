using PeopleActz.Application.DTOs.Responses.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.DTOs.Responses.Comment
{
    public class CommentDetailsListResponse
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public PostResponse Post { get; set; }
    }
}
