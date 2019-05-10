using System;
using System.Collections.Generic;

namespace BlogService.Models
{
    public class Author : Person
    {
        public string Image { get; set; }
        public string Bio { get; set; }
    }
}