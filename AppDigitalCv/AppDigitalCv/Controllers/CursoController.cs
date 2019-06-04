using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class CursoController : Controller
    {
        ICursoBusiness IcursoBusiness;
       
        public CursoController(ICursoBusiness _IcursoBusiness)
        {
            IcursoBusiness = _IcursoBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StrDescripcion")] CursoVM cursoVM)
        {
            if (ModelState.IsValid)
            {
                CursoDomainModel cursoDM = new CursoDomainModel();
                AutoMapper.Mapper.Map(cursoVM, cursoDM);
                IcursoBusiness.AddUpdateCurso(cursoDM);

                return View();
            }
            return View();
        }
    }
}