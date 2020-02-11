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
    public class ManualOperacionController : Controller
    {
        IManualOperacionBusiness operacionBusiness;
        IPaisBusiness paisBusiness;

        public ManualOperacionController(IManualOperacionBusiness _operacionBusiness, IPaisBusiness _paisBusiness)
        {

            operacionBusiness = _operacionBusiness;
            paisBusiness = _paisBusiness;

        }
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idPais = new SelectList(paisBusiness.GetPais(), "idPais", "strValor");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Seguridad");
            }

        }

        [HttpPost]
        public ActionResult Create(ManualOperacionVM manualOperacionVM)
        {
            if (ModelState.IsValid)
            {
                int idPersonal = SessionPersister.AccountSession.IdPersonal;

                ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();

                AutoMapper.Mapper.Map(manualOperacionVM, manualOperacionDM);
                manualOperacionDM.idPersonal = idPersonal;

                operacionBusiness.AddUpdateManualOperacion(manualOperacionDM);
            }

            return RedirectToAction("Create", "ManualOperacion");
        }

        [HttpGet]
        public JsonResult GetManuales(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<ManualOperacionDomainModel> manualDM = new List<ManualOperacionDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                manualDM = operacionBusiness.GetManualesByPersonal(IdentityPersonal).Where(p => p.strAutor.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = operacionBusiness.GetManualesByPersonal(IdentityPersonal).Count();


                manualDM = operacionBusiness.GetManualesByPersonal(IdentityPersonal).OrderBy(p => p.strAutor)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = manualDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = manualDM.Count(),
                iTotalRecords = manualDM.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetManualOperacionDelete(int _idManualOperacion)
        {
            ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();

            manualOperacionDM = operacionBusiness.GetManualOperacion(_idManualOperacion);

            if (manualOperacionDM != null)
            {
                ManualOperacionVM manualOperacionVM = new ManualOperacionVM();
                AutoMapper.Mapper.Map(manualOperacionDM,manualOperacionVM);

                return PartialView("_Eliminar",manualOperacionVM);
            }

            return PartialView("_Eliminar");
        }

        [HttpPost]
        public ActionResult DeleteManualOperacion(ManualOperacionVM manualOperacionVM)
        {
            ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();

            manualOperacionDM = operacionBusiness.GetManualOperacion(manualOperacionVM.id);

            if (manualOperacionDM != null)
            {
                if (operacionBusiness.GetManualesByPersonal(manualOperacionDM.idPersonal).Count == 1)
                {
                 
                    operacionBusiness.DeleteManualOperacion(manualOperacionDM.id);
                }
                else
                {
                    operacionBusiness.DeleteManualOperacion(manualOperacionDM.id);
                }               
            }
            return RedirectToAction("Create","ManualOperacion");
        }

        [HttpGet]
        public ActionResult GetManualOperacionUpdate(int _idManualOperacion)
        {
            ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();

            manualOperacionDM = operacionBusiness.GetManualOperacion(_idManualOperacion);

            if (manualOperacionDM != null)
            {
                ManualOperacionVM manualOperacionVM = new ManualOperacionVM();
                AutoMapper.Mapper.Map(manualOperacionDM,manualOperacionVM);
                return PartialView("_Editar",manualOperacionVM);
            }
            return PartialView("_Editar");
        }

        [HttpPost]
        public ActionResult UpdateManualOperacion(ManualOperacionVM manualOperacionVM)
        {
            if (manualOperacionVM.id > 0)
            {
                ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();

                AutoMapper.Mapper.Map(manualOperacionVM,manualOperacionDM);
                operacionBusiness.AddUpdateManualOperacion(manualOperacionDM);
            }

            return RedirectToAction("Create","ManualOperacion");
        }

    }
}