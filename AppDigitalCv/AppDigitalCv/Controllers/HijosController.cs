using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;

namespace AppDigitalCv.Controllers
{
    public class HijosController : Controller
    {

        IFamiliarBusiness iFamiliarBusiness;
        IPersonalBusiness iPersonalBusiness;
        public HijosController(IFamiliarBusiness _IfamiliarBusiness,IPersonalBusiness _IpersonalBusiness)
        {
            iFamiliarBusiness = _IfamiliarBusiness;
            iPersonalBusiness = _IpersonalBusiness;
        }

        // GET: Hijos
        public ActionResult Index()
        {
            return View();
        }

        //Inserción de los datos de los Hijos
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
            
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StrNombre,DteFechaNacimiento,IntEdad")] ParentescoVM parentescoVM)
        {
            
            if (ModelState.IsValid)
            {
                FamiliarDomainModel familiarDM = new FamiliarDomainModel();
                parentescoVM.IdPersonal = Security.SessionPersister.AccountSession.IdPersonal;

                AutoMapper.Mapper.Map(parentescoVM,familiarDM);
                iFamiliarBusiness.AddUpdateFamiliar(familiarDM);
                               
                return View();
            }
            return View("Create");
        }



        #region Consultar Datos Familiares
        public JsonResult GetDatosFamiliaresHijosByIdPersonal(int idPersonal)
        {
            
            List<ParentescoVM> familiar = new List<ParentescoVM>();
            List<FamiliarDomainModel> familiares =iFamiliarBusiness.GetFamiliaresHijosById(idPersonal);
            AutoMapper.Mapper.Map(familiares, familiar);
            return Json(familiar, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region  Consultar los datos del estado de salud del personal junto con el datatable se pueden ordenar de forma adecuada

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
                familiares = iFamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).Where(p=> p.StrNombre.Contains(param.sSearch)&& p.IdParentesco <2 ).ToList();
                
            }
            else
            {
                totalCount = iFamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).Count();
                familiares = iFamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).OrderBy(p=> p.IdPersonal)
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


        #region Eliminar EstadoSalud
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="idEnfermedad">recibe un identificador del estado de salud</param>
        /// <returns>regresa un estado de salud en una vista</returns>
        public ActionResult EliminarFamiliar(ParentescoVM parentescoVM)
        {
            FamiliarDomainModel familiarDomainModel = iFamiliarBusiness.GetFamiliarByIdFamiliar(parentescoVM.IdFamiliar);
            if (familiarDomainModel != null)
            {
                iFamiliarBusiness.DeleteFamiliar(familiarDomainModel);
                               
            }
            return View("Create");
        }
        #endregion

        #region Consultar para Eliminar de Forma permanente el registro
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="idEnfermedad">recibe un identificador del estado de salud</param>
        /// <returns>regresa un estado de salud en una vista</returns>
        public ActionResult GetFamiliarByIdFamiliar(int IdFamiliar)
        {
            FamiliarDomainModel familiarDomainModel = iFamiliarBusiness.GetFamiliarByIdFamiliar(IdFamiliar);
            if (familiarDomainModel != null)
            {

                ParentescoVM parentescoVM = new ParentescoVM();
                AutoMapper.Mapper.Map(familiarDomainModel, parentescoVM);
                return PartialView("_Eliminar", parentescoVM);
            }
            return View();
        }
        #endregion

    }
}