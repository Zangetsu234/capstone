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
        public ActionResult ViewStats()
        {
            if(Session["ID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            StatService statS = new StatService();
            StatsVM stats = new StatsVM();
            stats.Stats = statS.GetCharacterStats(Convert.ToInt32(Session["ID"]));
            return View("ViewStats", stats);
        }
	}
}