using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class InstitucionSuperiorController : Controller
    {
        IInstitucionSuperiorBusiness institucionSuperior;
        public InstitucionSuperiorController(IInstitucionSuperiorBusiness _institucionSuperior)
        {
            institucionSuperior = _institucionSuperior;
        }
        // GET: InstitucionSuperior
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StrObservacion,StrDescripcion")] InstitucionSuperiorVM institucionSuperiorVM)
        {
            if (ModelState.IsValid)
            {
                InstitucionSuperiorDomainModel institucionSuperiorDomain = new InstitucionSuperiorDomainModel();
                AutoMapper.Mapper.Map(institucionSuperiorVM,institucionSuperiorDomain);
                institucionSuperior.AddUpdateInstitucionSuperior(institucionSuperiorDomain);
                return View();
            }
            return View();
        }

    }
}