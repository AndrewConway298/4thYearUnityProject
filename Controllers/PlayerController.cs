using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoresWebsite.Models;

namespace ScoresWebsite.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        mvcappdb dbConnect = new mvcappdb();
        public ActionResult Index()
        {
            return View(dbConnect.Players.ToList());
        }

        /*public ActionResult setPlayerDetails(int id, string username, int score)
        {
            Player pIn = new Player();
            pIn.Id = id;
            pIn.Username = username;
            pIn.Score = score;
            return View(pIn);
        }*/
    }
}