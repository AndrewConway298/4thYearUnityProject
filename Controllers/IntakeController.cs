using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoresWebsite.Controllers
{
    public class IntakeController : Controller
    {
        // GET: Intake
        public ActionResult Index(string name, int score)
        {
            return View();
        }

    }
}
