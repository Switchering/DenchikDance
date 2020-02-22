using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DenchikDance.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}