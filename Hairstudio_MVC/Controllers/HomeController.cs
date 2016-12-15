using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hairstudio_DLL;
using Hairstudio_MVC.Models;
using HSRestAPI_DLL.Entities;

namespace Hairstudio_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGatewayService<Message> _mg = new Facade().GetMessageGateway();
        public ActionResult Index()
        {
            var messages = _mg.GetAll();
            var model = new ViewModel_HomeIndex();
            model.Welcome = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("welcome"));
            model.Monday = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("openinghours_monday"));
            model.Tuesday = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("openinghours_tuesday"));
            model.Wednesday = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("openinghours_wednesday"));
            model.Thursday = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("openinghours_thursday"));
            model.Friday = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("openinghours_friday"));
            model.Saturday = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("openinghours_saturday"));
            model.Sunday = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("openinghours_sunday"));
            model.Contact = messages.FirstOrDefault(m => m.AreaMessageIsUsed.Equals("contact"));
            model.CarouselImages = messages.FindAll(m => m.AreaMessageIsUsed.Equals("imgcarousel"));
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult OnlineBooking()
        {
            ViewBag.Message = "Your online booking page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}