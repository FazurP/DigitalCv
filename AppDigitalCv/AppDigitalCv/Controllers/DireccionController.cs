﻿using AppDigitalCv.Business;
using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;


namespace AppDigitalCv.Controllers
{
    public class DireccionController : Controller
    {

        IDireccionBusiness IdireccionBusiness;

        public DireccionController(IDireccionBusiness _IdDireccionBusiness)
        {
            IdireccionBusiness = _IdDireccionBusiness;
            
        }

        // GET: Direccion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Pais = new SelectList(IdireccionBusiness.GetPais(), "IdPais", "StrValor");
            
            return View();
        }
    }
}