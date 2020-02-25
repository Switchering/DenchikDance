using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DenchikDance.Models
{
    public class Article
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Text { get; set; }
        public byte[] Image { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:ddMMyyyyTHH:mm:ssZ}", ApplyFormatInEditMode = true)]
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        public ICollection<TagRelation> TagRelations { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
        public string ArticleImage//можно сделать с параметром
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