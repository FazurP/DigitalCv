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
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.IdParentesco = new SelectList(IparentescoBusiness.GetParentescos(), "IdParentesco", "StrDescripcion");
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
            
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
            ViewBag.IdParentesco = new SelectList(IparentescoBusiness.GetParentescos(), "IdParentesco", "StrDescripcion");
            return View("Create");
        }


        #region  Consultar los datos de los datos del contacto de emergencia junto con el datatable se pueden ordenar de forma adecuada

        //[HttpGet]
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


        /// <summary>
        /// Edicion de datos de contacto de emergencia
        /// </summary>
        /// <param name="idEmergencia">el identificador del contacto de emergencia</param>
        /// <returns>retorna una vista con los datos consultados</returns>
        public ActionResult AddEditDatosContactoEmergencia(int idEmergencia)
        {
            EmergenciaViewModel emergenciaViewModel = new EmergenciaViewModel();
            //creamos el objeto del dominio
            EmergenciaDomianModel emergenciaDM = new EmergenciaDomianModel();
                        
            if (idEmergencia > 0)
            {
                emergenciaDM = IemergenciasBusiness.GetEmergenciaById(idEmergencia);
                

            }
            AutoMapper.Mapper.Map(emergenciaDM, emergenciaViewModel);
            ViewBag.IdParentesco = new SelectList(IparentescoBusiness.GetParentescos(), "IdParentesco", "StrDescripcion");
            return PartialView("_Editar", emergenciaViewModel);
        }

        [HttpPost]
        public void Editar(EmergenciaViewModel emergenciaViewModel)
        {
            
            EmergenciaDomianModel emergenciaDM = new EmergenciaDomianModel();
            AutoMapper.Mapper.Map(emergenciaViewModel, emergenciaDM);
            if (emergenciaViewModel.IdEmergencia  > 0)
            {
                IemergenciasBusiness.AddUpdateEmergencia(emergenciaDM);
            }

        }


        /// <summary>
        /// Este Metodo se encarga de consultar los datos y mostrarlos en una vista parcial
        /// </summary>
        /// <param name="idEmergencia">el identificador  del id de la emergencia</param>
        /// <returns>una vista con los datos solicitados</returns>
        public ActionResult DeleteDatosContactoEmergenciaId(int idEmergencia)
        {
            EmergenciaViewModel emergenciaViewModel = new EmergenciaViewModel();
            //creamos el objeto del dominio
            EmergenciaDomianModel emergenciaDM = new EmergenciaDomianModel();
            if (idEmergencia > 0)
            {
                emergenciaDM = IemergenciasBusiness.GetEmergenciaById(idEmergencia);
            }
            ViewBag.IdParentesco = new SelectList(IparentescoBusiness.GetParentescoById(emergenciaDM.IdParentesco), "IdParentesco", "StrDescripcion");
            AutoMapper.Mapper.Map(emergenciaDM, emergenciaViewModel);
            return PartialView("_Eliminar", emergenciaViewModel);
        }

        #region Eliminar Datos de Contacto 
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="emergenciaViewModel">recibe un identificador del trabajador</param>
        /// <returns>regresa una vista con los datos eliminados</returns>
        public ActionResult Eliminar(EmergenciaViewModel emergenciaViewModel)
        {
            int _idPersonal = SessionPersister.AccountSession.IdPersonal;
            if (emergenciaViewModel != null)
            {
                IemergenciasBusiness.DeleteContactoEmergencia(emergenciaViewModel.IdEmergencia);
                ViewBag.IdParentesco = new SelectList(IparentescoBusiness.GetParentescos(), "IdParentesco", "StrDescripcion");
            }
            return View("Create");
        }
        #endregion





    }
}