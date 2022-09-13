using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PeopleActz.Application.DTOs.Requests.Post
{
    public class PostUpdateRequest
    {
        
        public string Id { get; set; }
    
        public string Name { get; set; }
   
        public string Title { get; set; }
 
        public string Body { get; set; }
    }
}
