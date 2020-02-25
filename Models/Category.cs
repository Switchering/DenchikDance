using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DenchikDance.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
        public byte[] Image { get; set; }
        public string CategoryImage//можно сделать с параметром
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