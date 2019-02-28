﻿using AppDigitalCv.Business.Interface;
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
    public class ContactoEmergenciaController : Controller
    {
        IEmergenciaBusiness IemergenciasBusiness;
        IParentescoBusiness IparentescoBusiness;
        public ContactoEmergenciaController(IEmergenciaBusiness _IemergenciasBusiness, IParentescoBusiness _IparentescoBusiness)
        {
            IemergenciasBusiness = _IemergenciasBusiness;
            IparentescoBusiness = _IparentescoBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdParentesco = new SelectList(IparentescoBusiness.GetParentescos(), "IdParentesco", "StrDescripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StrNombre,StrTelefono,StrDireccion,IdParentesco")]  EmergenciaViewModel emergenciaViewModel)
        {
            if (ModelState.IsValid)
            {
                emergenciaViewModel.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                EmergenciaDomianModel emergenciaDomianModel = new EmergenciaDomianModel();
                AutoMapper.Mapper.Map(emergenciaViewModel, emergenciaDomianModel);
                IemergenciasBusiness.AddUpdateEmergencia(emergenciaDomianModel);
            }
            return View("Create");
        }


        #region  Consultar los datos de los datos del contacto de emergencia junto con el datatable se pueden ordenar de forma adecuada

        [HttpGet]
        public JsonResult GetDatosEmergenciaTable(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<EmergenciaDomianModel> emergencias = new List<EmergenciaDomianModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                emergencias = IemergenciasBusiness.GetEmergenciasById(IdentityPersonal).Where(p => p.StrNombre.Contains(param.sSearch)).ToList();
                  

            }
            else
            {
                totalCount = IemergenciasBusiness.GetEmergenciasById(IdentityPersonal).Count();
                emergencias = IemergenciasBusiness.GetEmergenciasById(IdentityPersonal).OrderBy(p => p.IdPersonal)
                             .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();
                

            }
            return Json(new
            {
                aaData = emergencias,
                sEcho = param.sEcho,
                iTotalDisplayRecords = emergencias.Count(),
                iTotalRecords = emergencias.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        #endregion





    }
}