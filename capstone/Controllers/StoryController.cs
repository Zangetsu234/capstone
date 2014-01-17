using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace capstone.Controllers
{
    public class StoryController : Controller
    {
        public ActionResult Start()
        {
            //Session["CharID"] = CharID;
            if(Session["ID"] == null || Session["CharID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            CharacterService charS = new CharacterService();
            return View(charS.GetCharacterByID(Convert.ToInt32(Session["CharID"])).Alignment);
        }
        public ActionResult Index(int CharID)
        {
            Session["CharID"] = CharID;
            return RedirectToAction("Start");
        }
	}
}