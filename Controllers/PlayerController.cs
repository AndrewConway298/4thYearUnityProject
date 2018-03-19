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

        // GET: Player
        mvcappdb dbConnect = new mvcappdb();
        public ActionResult Index()
        {
            Console.WriteLine("Hello Index");
            return View(dbConnect.Table.ToList());
        }
        //Unity Data in
        [HttpPost]
        public ActionResult Register(string Username, string Email, string Password)
        {
            if (Username == null || Email == null || Password == null)
            {
                return null;
            }
            using (mvcappdb context = new mvcappdb())
            {
                context.Table.Add(new Player() { Username = Username, Email = Email, Password = Password });
                context.SaveChanges();
            }

            ViewBag.name = Username;
            return View();
        }

        //[HttpGet]
        //public ActionResult Login(string Username, string Password)
        //{
        //    if (Username == null || Password == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        using (mvcappdb db = new mvcappdb())
        //        {
        //            // LINQ to entities
        //            var query = db.Table.OrderBy(Player => Player.Username);
        //            foreach (var Player in query)
        //            {
        //                if(Player.Username == Username)
        //                {
        //                    return View();
        //                }
        //                else
        //                {
        //                    return null;
        //                }
        //            }
        //        }
        //    }
        //    return View();
        //}
    }
}