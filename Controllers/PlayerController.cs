using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ScoresWebsite.Models;

namespace ScoresWebsite.Controllers
{
    [Route("/Player")]
    public class PlayerController : Controller
    {
        DBContext dbConnect = new DBContext();
        public ActionResult Index()
        {
            Console.WriteLine("Hello Index");
            return View(dbConnect.Players.ToList());
        }

        //Unity Methods
        //Unity Form Acceptance
        [HttpPost]
        public ActionResult UnityRegister(string Username, string Email, string Password)
        {
            if (Username == null || Email == null || Password == null)
            {
                return null;
            }
            using (DBContext context = new DBContext())
            {
                context.Players.Add(new Player() { Username = Username, Email = Email, Password = Password });
                context.SaveChanges();
            }

            ViewBag.name = Username;
            return View();
        }

        [HttpPost]
        public ActionResult UnityLogin(string Username, string Password)
        {
            using (DBContext context = new DBContext())
            {
                var plyr = context.Players.Where(p => p.Username == Username && p.Password == Password).FirstOrDefault();
                if (plyr != null)
                {
                    Session["Username"] = plyr.Username.ToString();
                    return RedirectToAction("UnityLoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is incorrect");
                }
            }
            return View();
        }

        public ActionResult UnityLoggedIn()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult UnityUpdateScore(string Username, int ScoreIn)
        {
            using (DBContext context = new DBContext())
            {
                var plyr = context.Players.FirstOrDefault(p => p.Username == Username);
                    plyr.Score = ScoreIn;
                    context.SaveChanges();
            }
            return View();
        }
    }
}