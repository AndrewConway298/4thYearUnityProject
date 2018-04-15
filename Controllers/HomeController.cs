using ScoresWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ScoresWebsite.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        //Website Methods
        //Register
        [HttpGet]
        public ActionResult WebRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WebRegister([Bind(Exclude = "PaymentVerified,Score")]Player player)
        {
            bool Status = false;
            string message = "";
            if (ModelState.IsValid) {

                //Email Check
                var eExist = EmailExist(player.Email);
                if (eExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exists");
                    return View(player);
                }

                //Username Check
                var uExist = UsernameExist(player.Username);
                if (uExist)
                {
                    ModelState.AddModelError("UsernameExist", "Username already exists");
                    return View(player);
                }

                //Password Hashing
                //player.Password = PasswordCrypto.Hash(player.Password);
                //player.ConfirmPassword = PasswordCrypto.Hash(player.ConfirmPassword);

                //Set payment to false
                player.PaymentVerified = false;
                using (DBContext context = new DBContext())
                {
                    //player.PaymentVerified = true;
                    context.Players.Add(player);
                    context.SaveChanges();
                    message = "Your Registration has been successful!";
                    Status = true;
                }

                ModelState.Clear();
                ViewBag.Message = player.Username + " has been registered successfully!";
                ViewBag.Status = Status;
                return View(player);
            }
            else
            {
                message = "Invalid Request";
            }
            return View();
        }

        //Login
        [HttpGet]
        public ActionResult WebLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WebLogin(Player player)
        {
            using (DBContext context = new DBContext())
            {
                var plyr = context.Players.Where(p => p.Username == player.Username && p.Password == player.Password).FirstOrDefault();
                if (plyr != null)
                {
                    Session["Username"] = plyr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is incorrect");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
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

        //Checks for Existing Email and Username
        [NonAction]
        public bool EmailExist(string email)
        {
            using (DBContext context = new DBContext())
            {
                var e = context.Players.Where(a => a.Email == email).FirstOrDefault();
                return e != null;
            }
        }

        [NonAction]
        public bool UsernameExist(string username)
        {
            using (DBContext context = new DBContext())
            {
                var u = context.Players.Where(a => a.Username == username).FirstOrDefault();
                return u != null;
            }
        }
    }

}