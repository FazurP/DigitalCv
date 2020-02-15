using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Security;
using AppDigitalCv.Models;

namespace AppDigitalCv.Controllers
{
    public class DatosFamiliaresController : Controller
    {
        IFamiliarBusiness ifamiliarBusiness;
        IParentescoBusiness parentescoBusiness;

        public DatosFamiliaresController(IFamiliarBusiness _familiarBusiness,IParentescoBusiness _parentescoBusiness)
        {
            ifamiliarBusiness = _familiarBusiness;
            parentescoBusiness = _parentescoBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idParentesco = new SelectList(parentescoBusiness.GetParentescos(), "idParentesco", "StrDescripcion");
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Create(FamiliaresVM familiaresVM)
        {

            FamiliarDomainModel familiarDomainModel = new FamiliarDomainModel();
            familiaresVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
            AutoMapper.Mapper.Map(familiaresVM, familiarDomainModel);

            ifamiliarBusiness.AddUpdateFamiliar(familiarDomainModel);

            return RedirectToAction("Create", "DatosFamiliares");
        }

        #region  Consultar los datos de las competencias en ti junto con el datatable se pueden ordenar de forma adecuada

        [HttpGet]
        public JsonResult GetDatosFamiliaresTable(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<FamiliarDomainModel> familiares = new List<FamiliarDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                familiares = ifamiliarBusiness.GetFamiliaresById(IdentityPersonal).Where(p => p.StrNombre.Contains(param.sSearch)).ToList();
                ///ifamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).Where(p => p.StrNombre.Contains(param.sSearch)).ToList();

            }
            else
            {
                totalCount = ifamiliarBusiness.GetFamiliaresById(IdentityPersonal).Count();
                familiares = ifamiliarBusiness.GetFamiliaresById(IdentityPersonal).OrderBy(p => p.IdPersonal)
                             .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();             

            }
            return Json(new
            {
                aaData = familiares,
                sEcho = param.sEcho,
                iTotalDisplayRecords = familiares.Count(),
                iTotalRecords = familiares.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        #endregion


        //Edicion de Datos Familiares
        public ActionResult AddEditDatosFamiliares(int idFamiliar)
        {
            
            ParentescoVM parentescoVM = new ParentescoVM();
            //creamos el objeto del dominio
            FamiliarDomainModel familiarDM = new FamiliarDomainModel();
            if (idFamiliar > 0)
            {
                familiarDM = ifamiliarBusiness.GetFamiliarByIdFamiliar(idFamiliar);

            }
            AutoMapper.Mapper.Map(familiarDM, parentescoVM);
            return PartialView("_Editar", parentescoVM);
        }

        [HttpPost]
        public void EditarDatosFamiliar(ParentescoVM parentescoVM )
        {
            FamiliarDomainModel familiarDM = new FamiliarDomainModel();
            
            AutoMapper.Mapper.Map(parentescoVM, familiarDM);
            if (parentescoVM.IdFamiliar > 0)
            {
                ifamiliarBusiness.AddUpdateFamiliar(familiarDM);
            }
            
        }

        /// <summary>
        /// Este Metodo se encarga de consultar los datos y mostrarlos en una vista parcial
        /// </summary>
        /// <param name="idFamiliar">el identificador  del familiar</param>
        /// <returns>una vista con los datos solicitados</returns>
        public ActionResult DeleteDatosFamiliaresId(int idFamiliar)
        {
            FamiliarDomainModel familiarDM = new FamiliarDomainModel();
            ParentescoVM parentescoVM = new ParentescoVM();

            if (idFamiliar > 0)
            {
                familiarDM = ifamiliarBusiness.GetFamiliarByIdFamiliar(idFamiliar);
                
            }
            AutoMapper.Mapper.Map(familiarDM, parentescoVM);
            return PartialView("_Eliminar", parentescoVM);
        }

        #region Eliminar Premios Docente
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="parentescoVM">recibe un identificador del trabajador</param>
        /// <returns>regresa una vista con los datos eliminados</returns>
        public ActionResult EliminarDatosDeContactoDocente(ParentescoVM parentescoVM)
        {
            int _idPersonal = SessionPersister.AccountSession.IdPersonal;
            

            if (parentescoVM != null)
            {
                ifamiliarBusiness.DeleteFamiliar(parentescoVM.IdFamiliar);
            }
            return View("Create");
        }
        #endregion

    }
}