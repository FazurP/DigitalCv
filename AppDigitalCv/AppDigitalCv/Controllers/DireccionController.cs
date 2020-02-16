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
    public class DireccionController : Controller
    {
        IDireccionBusiness IdireccionBusiness;
        IPersonalBusiness IpersonalBusiness;
        public DireccionController(IDireccionBusiness _IdDireccionBusiness, IPersonalBusiness _IpersonalBusiness)
        {
            IdireccionBusiness = _IdDireccionBusiness;
            IpersonalBusiness = _IpersonalBusiness;

        }

        [HttpGet]
        public ActionResult EditarDatosDireccion()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();
            }else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
        }

        /// <summary>
        /// Metodo para inicializar y llenbar los view bag 
        /// </summary>
        /// <returns> Regresa una vista de crear con los datos cargados en los dropdownList </returns>
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {              
                ViewBag.IdEstado = new SelectList(IdireccionBusiness.GetEstadoByIdPais(1),"IdEstado","StrValor");
                ViewBag.IdMunicipio = new SelectList("");
                ViewBag.IdColonia = new SelectList("");
                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
        }

        /// <summary>
        /// Metodo para insertar en la viata de crear
        /// </summary>
        /// <param name="direccionVM"> Pide un objeto de direccion como parametro e incluye solo algunos campos </param>
        /// <returns> Regresa la vista de crear </returns>
        [HttpPost]
        public ActionResult Create(DireccionVM direccionVM)
        {

                direccionVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
                DireccionDomainModel direccionDomainModel = new DireccionDomainModel();
                AutoMapper.Mapper.Map(direccionVM, direccionDomainModel);
                IdireccionBusiness.AddUpdateDireccion(direccionDomainModel);
            
            return RedirectToAction("Create","Direccion");
        }

        /// <summary>
        /// Este metodo se encarga de hacer una consulta de los estados de un pais
        /// </summary>
        /// <param name="idPais"> pide el id de pais para asi realizar la consulta </param>
        /// <returns> Regresa una vista parecial que contiene una lista de estados dependiendo del pais seleccionado </returns>
        [HttpPost]
        public ActionResult ConsultarEstadosByPais(int idPais)
        {
            List<EstadoDomainModel> estadosDM = IdireccionBusiness.GetEstadoByIdPais(idPais);
            List<EstadoVM> estadosVM = new List<EstadoVM>();

            AutoMapper.Mapper.Map(estadosDM, estadosVM);
            ViewBag.Estados = new SelectList(estadosVM, "IdEstado", "StrValor");
            return PartialView("_Estados");
        }

        /// <summary>
        /// Este metodo se encarga de realizar la consulta de municipios cuando se selecciona un estado
        /// </summary>
        /// <param name="idEstado"> Pide el ID de estado para realizar la consulta </param>
        /// <returns> Regresa una vista parcialo con los datos cargados de los municipios </returns>
        [HttpPost]
        public ActionResult ConsultarMunicipiosByEstado(int idEstado)
        {
            List<MunicipioDomainModel> municipiosDM = IdireccionBusiness.GetMunicipioByIdEstado(idEstado).OrderBy(s=>s.StrValor).ToList<MunicipioDomainModel>();
            List<MunicipioVM> municipiosVM = new List<MunicipioVM>();

            AutoMapper.Mapper.Map(municipiosDM, municipiosVM);
            ViewBag.Municipios = new SelectList(municipiosVM, "IdMunicipio", "StrValor");
            return PartialView("_Municipios");
        }

        /// <summary>
        /// Este metodo se encarga de realizar la consulta de las colonias apor medio del ID del municipio
        /// </summary>
        /// <param name="idMunicipio"> Requere el Id del municipio para hacer la consulta </param>
        /// <returns> Regresa una vista parcial de colonias acorde al municipio seleccionado </returns>
        [HttpPost]
        public ActionResult ConsultarColoniasByMunicipio(int idMunicipio)
        {
            List<ColoniaDomainModel> coloniaDM = IdireccionBusiness.GetColoniaByMunicipio(idMunicipio).OrderBy(c=>c.StrValor).ToList<ColoniaDomainModel>();
            List<ColoniaVM> coloniasVM = new List<ColoniaVM>();

            AutoMapper.Mapper.Map(coloniaDM, coloniasVM);
            ViewBag.Colonias = new SelectList(coloniasVM, "IdColonia", "StrValor");
            return PartialView("_Colonias");
        }

        [HttpPost]
        public JsonResult ConsultarCodigoPostalByColonia(int idColonia)
        {
            string codigoPostal = IdireccionBusiness.GetCodigoPostalByColonia(idColonia);

            return Json(codigoPostal, JsonRequestBehavior.AllowGet);
        }

        #region  

        [HttpGet]
        public JsonResult GetDireccion(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<DireccionDomainModel> direcciones = new List<DireccionDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                direcciones = IdireccionBusiness.GetDirecciones(IdentityPersonal).Where(p => p.StrCalle.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = IdireccionBusiness.GetDirecciones(IdentityPersonal).Count();
                direcciones = IdireccionBusiness.GetDirecciones(IdentityPersonal).OrderBy(p => p.StrCalle)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = direcciones,
                sEcho = param.sEcho,
                iTotalDisplayRecords = direcciones.Count(),
                iTotalRecords = direcciones.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region Vista Parcial Eliminar
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="idEliminar">recibe un identificador de la direccion</param>
        /// <returns>regresa una direccion  en una vista</returns>
        public ActionResult GeDireccion(int IdDireccion)
        {
            DireccionDomainModel direccionDM = IdireccionBusiness.GetDireccion(IdDireccion);

            if (direccionDM != null)
            {
                DireccionVM direccionVM = new DireccionVM();
                AutoMapper.Mapper.Map(direccionDM, direccionVM);
                return PartialView("_Eliminar", direccionVM);
            }
            return View();
        }
        #endregion
        #region Eliminar Direccion de  la Base de datos
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="DireccionVM">recibe un identificador de la direccion</param>
        /// <returns>regresa una direccion en una vista</returns>
        public ActionResult EliminarDireccion(DireccionVM direccionVM)
        {
            DireccionDomainModel direccionDomainModel = new DireccionDomainModel();

            if (direccionVM.IdDireccion > 0)
            {
                AutoMapper.Mapper.Map(direccionVM, direccionDomainModel);
                IdireccionBusiness.DeleteDireccion(direccionDomainModel);
            }        
            return RedirectToAction("Create","Direccion");
        }
        #endregion

        [HttpGet]
        public ActionResult DisplayDireccion(int id) 
        {

            if (id > 0)
            {
                DireccionDomainModel direccionDomainModel = IdireccionBusiness.GetDireccion(id);
                DireccionVM direccionVM = new DireccionVM();

                AutoMapper.Mapper.Map(direccionDomainModel, direccionVM);

                return PartialView("_VerDatos",direccionVM);
            }
            return PartialView();
        }

    }
}