﻿using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SkillTables.ToList();
            return View(values);
        }
    }
}