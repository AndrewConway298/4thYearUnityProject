using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           PlayerContext pc = new PlayerContext();
           Player singleplay = pc.players.Single(play => play.Id == 1);
            return View(singleplay);
        }

        /*public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/
    }
}
