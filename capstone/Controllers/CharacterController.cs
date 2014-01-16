using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace capstone.Controllers
{
    public class CharacterController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            if(Session["ID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(CharacterFM charFM, StatFM statFM)
        {
            CharacterService charserv = new CharacterService();
            StatService statserv = new StatService();
            if(charFM.Name != null && charserv.CharacterNameLength(charFM))
            {
                charFM.Foreign = Convert.ToInt32(Session["ID"]);
                charserv.CreateCharacter(charFM);
                statserv.CreateStats(statFM, charFM.Name);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Character name not valid.";
            }
            return View(charFM);
        }
        public ActionResult ViewCharacters()
        {
            if(Session["ID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            CharacterService charS = new CharacterService();
            CharactersVM character = new CharactersVM();
            character.Characters = charS.GetUserCharacters(Convert.ToInt32(Session["ID"]));
            return View("ViewCharacters", character);
        }
        public ActionResult Choose()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}