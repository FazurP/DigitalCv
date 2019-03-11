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
                PasatiempoVM pasatiempoVM = new PasatiempoVM();
                pasatiempoVM.StrDescripcion = deportePersonalVM.PasatiempoVM.StrDescripcion;
                pasatiempoVM.IdPersonal = identityPersonal;
                deportePersonalVM.IdPersonal = identityPersonal;
                deportePersonalVM.FechaRegistro = DateTime.Now.ToShortDateString();
                deportePersonalVM.PasatiempoVM = pasatiempoVM;
                //IdeportePersonalBusiness.AddUpdateHabitosPersonales(deportePersonalVM);
                return View("Create");
            }
            return View();
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


    }
}

