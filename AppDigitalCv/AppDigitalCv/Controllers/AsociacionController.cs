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
        ITipoEmpresaBusiness ItipoEmpresaBusiness;

        public AsociacionController(IAsociacionesBusiness _IasociacionesBusiness, ITipoEmpresaBusiness _ItipoEmpresaBusiness)
        {
            IasociacionesBusiness = _IasociacionesBusiness;
            ItipoEmpresaBusiness = _ItipoEmpresaBusiness;
        }

        [HttpGet]
        
        public ActionResult Create()
        {
            ViewBag.IdTipoEmpresa = new SelectList(ItipoEmpresaBusiness.GetEmpresas(), "IdTipoEmpresa", "StrDescripcion");
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