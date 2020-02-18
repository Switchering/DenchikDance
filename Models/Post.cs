using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DenchikDance.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        public ICollection<TagRelation> TagRelations { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
    }
}