﻿using System;
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
        public ActionResult Create(CharacterFM charFM)
        {
            CharacterService charserv = new CharacterService();
            if(charFM.Name != null && charserv.CharacterNameLength(charFM))
            {
                charserv.CreateCharacter(charFM);
                return RedirectToAction("Create");
            }
            else
            {
                ViewBag.ErrorMessage = "Character name not valid.";
            }
            return View(charFM);
        }
    }
}