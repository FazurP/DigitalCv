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

        public ActionResult Create()
        {
            return View();
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


        public string AddEditPersonal()
        {
            string resultado = string.Empty;
            PersonalVM personalVM = new PersonalVM();
            personalVM.strNombre = "prueba1";
            personalVM.strApellidoPaterno = "prueba2";
            personalVM.strApellidoMaterno = "prueba3";
            personalVM.idPersonal =100000;

            PersonalDomainModel personalDM = new PersonalDomainModel();
            AutoMapper.Mapper.Map(personalVM,personalDM);///hacemos el mapeado de la entidad
            resultado= IPersonalBussines.AddUpdatePersonal(personalDM);
            return resultado;

        }


        public ActionResult borrarPersonal(int _idPersonal)
        {
            // bool resultado = IPersonalBussines.DeletePersonal(_idPersonal);
            // return Json(resultado,JsonRequestBehavior.AllowGet);
            return View();
        }

    }
}