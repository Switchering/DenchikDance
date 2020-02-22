using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DenchikDance.Models
{
    public class TagRelation
    {
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public int TagID { get; set; }

        public Article Article { get; set; }
        public Tag Tag { get; set; }
    }
}