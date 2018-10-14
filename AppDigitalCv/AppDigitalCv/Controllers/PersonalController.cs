using AppDigitalCv.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;

namespace AppDigitalCv.Controllers
{
    public class PersonalController : Controller
    {
        //mandamos llamar al metodo de negocio
        IPersonalBusiness IPersonalBussines;


        public PersonalController(IPersonalBusiness _PersonalBussiness)
        {
            IPersonalBussines = _PersonalBussiness;
        }

        /// <summary>
        /// Metodo Get
        /// este metodo se encarga de realziar la presentación de los datos en la vista
        /// </summary>


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,ApellidoPaterno,ApellidoMaterno,RFC,Curp,HomoClave,")] PersonalVM personalVM)
        {
            if (ModelState.IsValid)
            {
                this.AddEditPersonal(personalVM);
                return View();
            }
            else {
                return View("Create");
            }
        }

        // GET: Personal
        public ActionResult Index()
        {
            List<PersonalDomainModel> personalDM = IPersonalBussines.GetEmpleado();
            //aqui cambaimos al modeldomain al viewmodel
            List<PersonalVM> personalVM = new List<PersonalVM>();
            //cambiamos el objeto
            AutoMapper.Mapper.Map(personalDM,personalVM);
            return View();
        }

        [HttpGet]
        public ActionResult DatosPersonales()
        {
            IPersonalBussines.GetEmpleado();
            return View();
        }

        [HttpPost]
        public ActionResult DatosPersonales(PersonalVM personalVM)
        {
            IPersonalBussines.GetEmpleado();
            return View();
        }

        #region Agregar o Editar una entidad

        public string AddEditPersonal(PersonalVM personalVM)
        {
            string resultado = string.Empty;
            PersonalDomainModel personalDM = new PersonalDomainModel();
            AutoMapper.Mapper.Map(personalVM, personalDM);///hacemos el mapeado de la entidad

            resultado = IPersonalBussines.AddUpdatePersonal(personalDM);
            return resultado;
        }
        #endregion

        public ActionResult borrarPersonal(int _idPersonal)
        {
            // bool resultado = IPersonalBussines.DeletePersonal(_idPersonal);
            // return Json(resultado,JsonRequestBehavior.AllowGet);
            return View();
        }

    }
}