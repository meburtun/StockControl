﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Yardim()
        {
            return View();
        }
    }
}