using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DenchikDance.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public new string Email { get; set;  }
        public string Password { get; set; }
        public ICollection<Article> Articles { get; set; }
        public byte[] Image { get; set; }
        public string UserImage//можно сделать с параметром
        {
            get
            {
                string imageSrc;
                if (Image == null || Image.Length < 10)
                {
                    imageSrc = "/images/noImage.png";
                }
                else
                {
                    var imageBase64 = Convert.ToBase64String(Image); //сразу конвертировать
                    imageSrc = string.Format("data:image/gif;base64, {0}", imageBase64);//или ЧО??? 
                }
                return imageSrc;
            }
        }
    }
}