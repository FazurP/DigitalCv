using AppDigitalCv.Business.Interface;
using AppDigitalCv.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class CursosController : Controller
    {
        IInstitucionSuperiorBusiness institucionSuperiorBusiness;
        ICursoBusiness cursoBusiness;
        public CursosController(IInstitucionSuperiorBusiness _institucionSuperiorBusiness, ICursoBusiness _cursoBusiness)
        {
            institucionSuperiorBusiness = _institucionSuperiorBusiness;
            cursoBusiness = _cursoBusiness;
        }


        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.Cursos = new SelectList(cursoBusiness.GetCursos(), "Id", "StrDescripcion");
                ViewBag.Institucion = new SelectList(institucionSuperiorBusiness.GetInstitucionSuperior(), "IdInstitucionSuperior", "StrDescripcion");
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
        }
    }
}