﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Domain.Entities.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }

    }
}
