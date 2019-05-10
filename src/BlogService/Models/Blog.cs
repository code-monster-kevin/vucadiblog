using System;
using System.Collections.Generic;

namespace BlogService.Models
{
    public class Blog : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public Author Author { get; set; }
    }
}