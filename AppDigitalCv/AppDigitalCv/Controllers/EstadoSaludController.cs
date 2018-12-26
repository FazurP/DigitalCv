using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Security;

namespace AppDigitalCv.Controllers
{
    public class EstadoSaludController : Controller
    {
        IEnfermedadBusiness IenfermedadesBusiness;
        ITipoSangreBusiness ItipoSangreBusiness;
        IEstadoSaludBusiness IestadoSaludBusiness;
        public EstadoSaludController(IEstadoSaludBusiness _IestadoSaludBusiness, IEnfermedadBusiness _IenfermedadesBusiness, ITipoSangreBusiness _itipoSangreBusiness)
        {
            IenfermedadesBusiness = _IenfermedadesBusiness;
            ItipoSangreBusiness = _itipoSangreBusiness;
            IestadoSaludBusiness = _IestadoSaludBusiness;
        }

        // GET: EstadoSalud
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Enfermedades = new SelectList(IenfermedadesBusiness.GetEnfermedades(), "IdEnfermedad", "StrDescripcion");
            ViewBag.TipoSangre = new SelectList(ItipoSangreBusiness.GetTipoSangre(), "IdTipoSangre", "StrDescripcion");
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Registrar([Bind(Include="IdPersonal,IdEnfermedad,Descripcion")] EstadoSaludVM estadoSaludVM)
        {
            if (ModelState.IsValid)
            {
                this.AddEditEstadoSalud(estadoSaludVM);
                if (Request.IsAjaxRequest())
                {
                    var enfermedades = IestadoSaludBusiness.GetEnfermedadesPersonalById(estadoSaludVM.IdPersonal);
                    return Json(enfermedades, JsonRequestBehavior.AllowGet);
                }
            
            }
            return View();
        }


        #region  Consultar los datos del estado de salud del personal

        [HttpGet]
        public JsonResult GetEstadosDeSaludPersonal(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<EstadoSaludDomainModel> enfermedades = new List<EstadoSaludDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength )+ 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                enfermedades = IestadoSaludBusiness.GetEnfermedadesPersonalById(1).Where(p=>p.NombreEnfermedad.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = IestadoSaludBusiness.GetEnfermedadesPersonalById(IdentityPersonal).Count();

                enfermedades = IestadoSaludBusiness.GetEnfermedadesPersonalById(IdentityPersonal).OrderBy(p=>p.idEnfermedad)
                    .Skip((pageNo-1)*param.iDisplayLength).Take(param.iDisplayLength).ToList();
                
            }
            return Json(new
            {
                aaData = enfermedades,
                sEcho = param.sEcho,
                iTotalDisplayRecords = enfermedades.Count(),
                iTotalRecords = enfermedades.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        #endregion



        #region Agregar o Editar una entidad

        public string AddEditEstadoSalud(EstadoSaludVM estadoSaludVM)
        {
            string resultado = string.Empty;

            EstadoSaludDomainModel estadoSaludDM = new EstadoSaludDomainModel();
            
            AutoMapper.Mapper.Map(estadoSaludVM, estadoSaludDM);///hacemos el mapeado de la entidad
            resultado = IestadoSaludBusiness.AddUpdateEstadoSalud(estadoSaludDM);
            return resultado;
        }
        #endregion



    }
}