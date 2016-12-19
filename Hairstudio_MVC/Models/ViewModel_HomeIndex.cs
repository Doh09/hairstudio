using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Hairstudio_DLL.Entities;

namespace Hairstudio_MVC.Models
{
    public class ViewModel_HomeIndex
    {
        [Required]
        public Message Welcome { get; set; }
        [Required]
        [Display(Name = "Mandag")]
        public Message Monday { get; set; }
        [Required]
        [Display(Name = "Tirsdag")]
        public Message Tuesday { get; set; }
        [Required]
        [Display(Name = "Onsdag")]
        public Message Wednesday { get; set; }
        [Required]
        [Display(Name = "Torsdag")]
        public Message Thursday { get; set; }
        [Required]
        [Display(Name = "Fredag")]
        public Message Friday { get; set; }
        [Required]
        [Display(Name = "Lørdag")]
        public Message Saturday { get; set; }
        [Required]
        [Display(Name = "Søndag")]
        public Message Sunday { get; set; }
        [Required]
        [Display(Name = "Telefon:")]
        public Message Contact { get; set; }
        [Required]
        public List<Message> CarouselImages { get; set; }
    }
}