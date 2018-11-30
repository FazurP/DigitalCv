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
            ViewBag.EstadoCivil = new SelectList(IestadoCivilBusines.GetEstadoCivil(), "IdEstadoCivil", "StrDescripcion");
            return View();
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