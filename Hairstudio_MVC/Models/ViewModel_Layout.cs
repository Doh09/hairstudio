using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Hairstudio_DLL;
using HSRestAPI_DLL.Entities;

namespace Hairstudio_MVC.Models
{
    public class ViewModel_Layout
    {
        private readonly IGatewayService<Message> _mg = new Facade().GetMessageGateway();
        public ViewModel_Layout()
        {
            var messages = _mg.GetAll();
            NavBarLogoLink = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("navbar_logo"));
            FBLogoLink = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("fb_logo"));
            FBLink = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("fb_link"));
        }

        [Required]
        public Message NavBarLogoLink { get; set; }
        [Required]
        public Message FBLogoLink { get; set; }
        [Required]
        public Message FBLink { get; set; }

        
    }
}