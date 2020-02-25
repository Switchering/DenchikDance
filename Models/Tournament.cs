using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DenchikDance.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Text { get; set; }
        public byte[] Image { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tournament Date")]
        public DateTime TournamentDate { get; set; }

        public string TournamentImage//можно сделать с параметром
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