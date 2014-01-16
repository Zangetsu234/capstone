using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace capstone.Controllers
{
    public class StoryController : Controller
    {
        public ActionResult Start(int CharID)
        {
            Session["CharID"] = CharID;
            if(Session["ID"] == null || Session["CharID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
	}
}