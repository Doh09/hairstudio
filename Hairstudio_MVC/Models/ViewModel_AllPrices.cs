using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Hairstudio_DLL.Entities;

namespace Hairstudio_MVC.Models
{
    public class ViewModel_AllPrices
    {
        [Required]
        public Message Message { get; set; }
        [Required]
        [Display(Name = "Pris")]
        public List<ServiceOffered> ServicesOffered { get; set; }

    }
}