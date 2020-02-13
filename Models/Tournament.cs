using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DenchikDance.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
    }
}