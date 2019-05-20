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
    public class EstadoCivilController : Controller
    {
        IEstadoCivilBusiness IestadoCivilBusines;

        public EstadoCivilController(IEstadoCivilBusiness _IestadoCivilBusiness)
        {
            IestadoCivilBusines = _IestadoCivilBusiness;
        }

        // GET: EstadoCivilSexo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.EstadoCivil = new SelectList(IestadoCivilBusines.GetEstadoCivil(), "IdEstadoCivil", "StrDescripcion");
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
            
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "IdEstadoCivil, StrGenero")]PersonalVM personalVM)
        {
            if (ModelState.IsValid)
            {
                AddEditPersonal(personalVM);
                return RedirectToAction("Create","EstadoCivil");
            }
            return RedirectToAction("Create","EstadoCivil"); 
        }

        #region Agregar o editar una entidad

        public string AddEditPersonal(PersonalVM personallVM)
        {
            string resultado = string.Empty;
            PersonalDomainModel personalDM = new PersonalDomainModel();
            AutoMapper.Mapper.Map(personallVM, personalDM);
            resultado = IestadoCivilBusines.AddUpdateEstadocivil(personalDM);
            return resultado;
        }

        #endregion

    }
}