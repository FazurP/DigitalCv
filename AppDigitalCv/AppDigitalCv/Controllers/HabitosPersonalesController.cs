using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class HabitosPersonalesController : Controller
    {
        IDeporteBusiness deporteBusiness;
        IFrecuenciaBusiness frecuenciaBusiness;
        IDeportePersonalBusiness IdeportePersonalBusiness;

        public HabitosPersonalesController(IDeporteBusiness _deporteBusiness, IFrecuenciaBusiness _frecuenciaBusiness, IDeportePersonalBusiness _deportePersonalBusiness)
        {
            deporteBusiness = _deporteBusiness;
            frecuenciaBusiness = _frecuenciaBusiness;
            IdeportePersonalBusiness = _deportePersonalBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdDeporte = new SelectList(deporteBusiness.GetDeportes(), "IdDeporte", "StrDescripcion");
            ViewBag.IdFrecuencia = new SelectList(frecuenciaBusiness.GetFrecuencia(),"IdFrecuencia", "StrDescripcion");
            return View();
        }
        [HttpPost]
        public ActionResult Create(DeportePersonalVM deportePersonalVM)
        {
            int  identityPersonal = SessionPersister.AccountSession.IdPersonal;
            if (ModelState.IsValid)
            {
                DeportePersonalDomainModel deporteDM = new DeportePersonalDomainModel();
                PasatiempoDomainModel pasatiempoDM = new PasatiempoDomainModel();

                PasatiempoVM pasatiempoVM = new PasatiempoVM();
                pasatiempoVM.StrDescripcion = deportePersonalVM.PasatiempoVM.StrDescripcion;
                pasatiempoVM.IdPersonal = identityPersonal;

                deportePersonalVM.IdPersonal = identityPersonal;
                deportePersonalVM.FechaRegistro = DateTime.Now.ToShortDateString();
                deportePersonalVM.PasatiempoVM = pasatiempoVM;

                AutoMapper.Mapper.Map(pasatiempoVM, pasatiempoDM);
                AutoMapper.Mapper.Map(deportePersonalVM, deporteDM);
                deporteDM.PasatiempoDM = pasatiempoDM;

                IdeportePersonalBusiness.AddUpdateHabitosPersonales(deporteDM);
                ViewBag.IdDeporte = new SelectList(deporteBusiness.GetDeportes(), "IdDeporte", "StrDescripcion");
                ViewBag.IdFrecuencia = new SelectList(frecuenciaBusiness.GetFrecuencia(), "IdFrecuencia", "StrDescripcion");

                return View("Create");
            }

            ViewBag.IdDeporte = new SelectList(deporteBusiness.GetDeportes(), "IdDeporte", "StrDescripcion");
            ViewBag.IdFrecuencia = new SelectList(frecuenciaBusiness.GetFrecuencia(), "IdFrecuencia", "StrDescripcion");
            return View("Create");
        }



        #region  Consultar los datos del estado de los habitos personales

        [HttpGet]
        public JsonResult GetDeportesPersonales(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<DeportePersonalDomainModel> deportes = new List<DeportePersonalDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                deportes = IdeportePersonalBusiness.GetDeportesPersonalesById(IdentityPersonal).Where(p=> p.DeporteDM.StrDescripcion.Contains(param.sSearch)).ToList();
                    
            }
            else
            {
                totalCount = IdeportePersonalBusiness.GetDeportesPersonalesById(IdentityPersonal).Count();

                deportes = IdeportePersonalBusiness.GetDeportesPersonalesById(IdentityPersonal).OrderBy(p => p.IdDeportePersonal)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = deportes,
                sEcho = param.sEcho,
                iTotalDisplayRecords = deportes.Count(),
                iTotalRecords = deportes.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region  Consulta que muestra de forma general en json los datos arrojados de una consulta basica
        public JsonResult GetDatos()
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<DeportePersonalDomainModel> deportes = new List<DeportePersonalDomainModel>();
            deportes = IdeportePersonalBusiness.GetDeportesPersonalesById(IdentityPersonal).ToList();
            return Json(deportes,JsonRequestBehavior.AllowGet);
        }
        #endregion



        //Edicion de Datos Familiares
        public ActionResult AddEditHabitosPersonales(int idDeportePersonal)
        {
            
            DeportePersonalVM deportePersonalVM = new DeportePersonalVM();
            DeporteVM deporteVM = new DeporteVM();

            //creamos el objeto del dominio
            DeportePersonalDomainModel deportePersonalDM = new DeportePersonalDomainModel();
            if (idDeportePersonal > 0)
            {
                deportePersonalDM  = IdeportePersonalBusiness.GetDeportesPersonalByIdDeportePersonal(idDeportePersonal);
                

            }
            AutoMapper.Mapper.Map(deportePersonalDM.DeporteDM, deporteVM);
            AutoMapper.Mapper.Map(deportePersonalDM, deportePersonalVM);
            deportePersonalVM.DeporteVM = deporteVM;

            ViewBag.IdFrecuencia = new SelectList(frecuenciaBusiness.GetFrecuencia(), "IdFrecuencia", "StrDescripcion");
            return PartialView("_Editar", deportePersonalVM);
        }

        [HttpPost]
        public void EditarHabitosPersonales(DeportePersonalVM deportePersonalVM)
        {
            
            DeportePersonalDomainModel deportePersonalDM = new DeportePersonalDomainModel();

            AutoMapper.Mapper.Map(deportePersonalVM, deportePersonalDM);

            if (deportePersonalVM.IdDeportePersonal > 0)
            {
                IdeportePersonalBusiness.AddUpdateHabitosPersonales(deportePersonalDM);
            }

        }
        
        /// <summary>
        /// Este Metodo se encarga de consultar los datos y mostrarlos en una vista parcial
        /// </summary>
        /// <param name="idFamiliar">el identificador  del familiar</param>
        /// <returns>una vista con los datos solicitados</returns>
        public ActionResult DeleteHabitosPersonales(int idDeportePersonal)
        {            
            DeportePersonalDomainModel deportePersonalDM = new DeportePersonalDomainModel();
            DeportePersonalVM deportePersonalVM = new DeportePersonalVM();

            if (idDeportePersonal > 0)
            {
                deportePersonalDM = IdeportePersonalBusiness.GetDeportesPersonalByIdDeportePersonal(idDeportePersonal);
            }
            DeporteDomainModel deporteDM= deportePersonalDM.DeporteDM;
            DeporteVM deporteVM = new DeporteVM();
            AutoMapper.Mapper.Map(deporteDM, deporteVM);
            AutoMapper.Mapper.Map(deportePersonalDM, deportePersonalVM);

            ViewBag.IdFrecuencia = new SelectList(frecuenciaBusiness.GetFrecuencia(), "IdFrecuencia", "StrDescripcion");
            deportePersonalVM.DeporteVM = deporteVM;
            return PartialView("_Eliminar", deportePersonalVM);
        }

        #region Eliminar Habitos deportivos  Docente
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="deportePersonalVM">recibe un identificador del trabajador</param>
        /// <returns>regresa una vista con los datos eliminados</returns>
        public ActionResult EliminarDatosHabitosPersonales(DeportePersonalVM deportePersonalVM)
        {
            int _idPersonal = SessionPersister.AccountSession.IdPersonal;
            if (deportePersonalVM != null)
            {
                IdeportePersonalBusiness.DeleteHabitoPersonal(deportePersonalVM.IdDeportePersonal);
            }
            ViewBag.IdDeporte = new SelectList(deporteBusiness.GetDeportes(), "IdDeporte", "StrDescripcion");
            ViewBag.IdFrecuencia = new SelectList(frecuenciaBusiness.GetFrecuencia(), "IdFrecuencia", "StrDescripcion");
            return View("Create");
        }
        #endregion


        #region Este metodo se encarga de agregar una actividad deportiva adicional 
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        #endregion
    }
}

