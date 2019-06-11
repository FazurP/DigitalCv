﻿using AppDigitalCv.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class PortafolioPersonalController : Controller
    {
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();
            }
            else {
                return RedirectToAction("Login","Seguridad");
            }
            
        }
    }
}