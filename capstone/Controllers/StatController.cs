using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace capstone.Controllers
{
    public class StatController : Controller
    {
        public ActionResult ViewStats(int ID)
        {
            if(Session["ID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            StatService statS = new StatService();
            StatsVM stats = new StatsVM();
            stats.Stats = statS.GetCharacterStats(ID);
            return View("ViewStats", stats);
        }
	}
}