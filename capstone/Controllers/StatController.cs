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
        public ActionResult Index()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
	}
}