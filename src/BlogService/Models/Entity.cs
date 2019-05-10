using System;

namespace BlogService.Models
{
    public abstract class Entity
    {
        public string ID { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}