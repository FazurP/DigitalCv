using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Business;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;

namespace AppDigitalCv.Controllers
{
    public class PersonalAsociacionesController : Controller
    {
        IAsociacionesBusiness IasociacionesBusiness;
        ITipoEmpresaBusiness ItipoEmpresaBusiness;
        IPersonalAsociacionesBusiness IpersonalAsociacionesBusiness;
        public PersonalAsociacionesController(IAsociacionesBusiness _IasociacionesBusiness, ITipoEmpresaBusiness _ItipoEmpresaBusiness, IPersonalAsociacionesBusiness _IpersonalAsociacionesBusiness)
        {
            IasociacionesBusiness = _IasociacionesBusiness;
            ItipoEmpresaBusiness = _ItipoEmpresaBusiness;
            IpersonalAsociacionesBusiness = _IpersonalAsociacionesBusiness;
        }

        // GET: PersonalAsociaciones
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.IdAsociacion = new SelectList(IasociacionesBusiness.GetAsociaciones(), "IdAsociacion", "StrDescripcion");
                ViewBag.TipoEmpresa = new SelectList("");
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
           
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "IdPersonal,IdAsociacion,DteFecha,StrTipoParticipacion")]PersonalAsociacionesVM personalAsociacionesVM)
        {
            if (ModelState.IsValid)
            {
                PersonalAsociacionesDomainModel personalAsociacionesDM = new PersonalAsociacionesDomainModel();
                personalAsociacionesVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                AutoMapper.Mapper.Map(personalAsociacionesVM, personalAsociacionesDM);
                IpersonalAsociacionesBusiness.AddPersonalAsociaciones(personalAsociacionesDM);
                ViewBag.IdAsociacion = new SelectList(IasociacionesBusiness.GetAsociaciones(), "IdAsociacion", "StrDescripcion");
                ViewBag.TipoEmpresa = new SelectList("");
                return View();
            }

            ViewBag.IdAsociacion = new SelectList(IasociacionesBusiness.GetAsociaciones(), "IdAsociacion", "StrDescripcion");
            ViewBag.TipoEmpresa = new SelectList("");
            return View("Create");

        }



        /// <summary>
        /// Este metodo se encarga de hacer una consulta de tipo de empresa
        /// </summary>
        /// <param name="idPais"> pide el id de pais para asi realizar la consulta </param>
        /// <returns> Regresa una vista parecial que contiene una lista de estados dependiendo del pais seleccionado </returns>
        [HttpPost]
        public ActionResult ConsultarTipoEmpresaByIdAsociacion(int idAsociacion)
        {

            List<TipoEmpresaDomainModel> tipoEmpresas = ItipoEmpresaBusiness.GetTipoEmpresaByIdAsociacion(idAsociacion);
            List<TipoEmpresaVM> tiposEmpresaVM = new List<TipoEmpresaVM>();
            AutoMapper.Mapper.Map(tipoEmpresas, tiposEmpresaVM);

            ViewBag.TipoEmpresa = new SelectList(tiposEmpresaVM, "IdTipoEmpresa", "StrDescripcion");
            return PartialView("_TipoEmpresa");
        }

        #region  Consultar los datos del estado de salud del personal junto con el datatable se pueden ordenar de forma adecuada

        [HttpGet]
        public JsonResult GetDatosPersonalAsociacionTable(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<PersonalAsociacionesDomainModel> personalAsociaciones = new List<PersonalAsociacionesDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                personalAsociaciones = IpersonalAsociacionesBusiness.GetPersonalAsociacinesById(IdentityPersonal).Where(p => p.StrTipoParticipacion 
                .Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = IpersonalAsociacionesBusiness.GetPersonalAsociacinesById(IdentityPersonal).Count();

                personalAsociaciones = IpersonalAsociacionesBusiness.GetPersonalAsociacinesById(IdentityPersonal).OrderBy(p => p.IdPersonal)
                          .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = personalAsociaciones,
                sEcho = param.sEcho,
                iTotalDisplayRecords = personalAsociaciones.Count(),
                iTotalRecords = personalAsociaciones.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region Eliminar Asociacion del  Docente
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="idAsociacion">recibe un identificador de la asociacion</param>
        /// <returns>regresa una vista con los datos eliminados</returns>
        public ActionResult EliminarAsociacionPersonal(PersonalAsociacionesVM personalAsociacionesVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombreUsuario = SessionPersister.AccountSession.NombreCompleto;
            PersonalAsociacionesDomainModel personalAsociacionDM = IpersonalAsociacionesBusiness.GetPersonalAsociacionByIdAsociacion(personalAsociacionesVM.IdAsociacion);
            
            if (personalAsociacionDM != null)
            {
                IpersonalAsociacionesBusiness.DeleteAsociacionDocente(personalAsociacionDM);
                                                
            }
            ViewBag.IdAsociacion = new SelectList(IasociacionesBusiness.GetAsociaciones(), "IdAsociacion", "StrDescripcion");
            ViewBag.TipoEmpresa = new SelectList("");
            return View("Create");
        }
        #endregion



        #region Consultar para Eliminar de Forma permanente el registro
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="IdAsociacion">recibe un identificador de la asociacion del docente</param>
        /// <returns>regresa una asociacion a la cual pertenece el docente en una vista</returns>
        public ActionResult GetAsociacionByIdAsociacion(int IdAsociacion)
        {
            int IdPersonal = SessionPersister.AccountSession.IdPersonal;
            PersonalAsociacionesDomainModel personalAsociacionDM = IpersonalAsociacionesBusiness.GetPersonalAsociacionByIdAsociacion(IdAsociacion); 
                
            if (personalAsociacionDM != null)
            {
                PersonalAsociacionesVM personalAsociacionesVM = new PersonalAsociacionesVM();
                AutoMapper.Mapper.Map(personalAsociacionDM, personalAsociacionesVM);
                return PartialView("_Eliminar", personalAsociacionesVM);
                
            }
            return View();
        }

        #endregion



    }
}