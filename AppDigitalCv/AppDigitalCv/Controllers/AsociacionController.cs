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
    public class AsociacionController : Controller
    {
        IAsociacionesBusiness IasociacionesBusiness;

        public AsociacionController(IAsociacionesBusiness _IasociacionesBusiness)
        {
            IasociacionesBusiness = _IasociacionesBusiness;
        }

        [HttpGet]
        
        public ActionResult Create()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StrDescripcion,StrObservacion,IdTipoEmpresa")]AsociacionesVM asociacionesVM)
        {
            if (ModelState.IsValid)
            {
                AsociacionesDomainModel asociacionesDomainModel = new AsociacionesDomainModel();
                AutoMapper.Mapper.Map(asociacionesVM, asociacionesDomainModel);
                IasociacionesBusiness.AddUpdateAsociaciones(asociacionesDomainModel);
            }
            return RedirectToAction("Create", "PersonalAsociaciones");
        }
    }
}