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

        // GET: Direccion
        public ActionResult Index()
        {
            return View();
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
                ViewBag.Pais = new SelectList(IdireccionBusiness.GetPais(), "IdPais", "StrValor");
                ViewBag.Estados = new SelectList("");
                ViewBag.Municipios = new SelectList("");
                ViewBag.IdColonia = new SelectList("");
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
            
        }

        /// <summary>
        /// Metodo para insertar en la viata de crear
        /// </summary>
        /// <param name="direccionVM"> Pide un objeto de direccion como parametro e incluye solo algunos campos </param>
        /// <returns> Regresa la vista de crear </returns>
        [HttpPost]
        public ActionResult Create([Bind(Include = "StrCalle,StrNumeroInterior,StrNumeroExterior,IdColonia")]DireccionVM direccionVM)
        {
            if (ModelState.IsValid)
            {
                AddEditDireccion(direccionVM);
                ViewBag.Pais = new SelectList(IdireccionBusiness.GetPais(), "IdPais", "StrValor");
                ViewBag.Estados = new SelectList("");
                ViewBag.Municipios = new SelectList("");
                ViewBag.IdColonia = new SelectList("");
                return View("Create");
            }
            ViewBag.Pais = new SelectList(IdireccionBusiness.GetPais(), "IdPais", "StrValor");
            ViewBag.Estados = new SelectList("");
            ViewBag.Municipios = new SelectList("");
            ViewBag.IdColonia = new SelectList("");
            return View("Create");
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


        #region  Crear Una Direccion
        /// <summary>
        /// Metodo para crear una direccion 
        /// </summary>
        /// <param name="direccionVM"> Pide un objeto de tipo direccion como parametro </param>
        /// <returns> Regresa un valor boleano </returns>
        public bool AddEditDireccion(DireccionVM direccionVM)
        {
            bool respuesta = false;
            int IdPersonal = SessionPersister.AccountSession.IdPersonal;
            DireccionDomainModel direccionDomainModel = new DireccionDomainModel();
            AutoMapper.Mapper.Map(direccionVM, direccionDomainModel);///hacemos el mapeado de la entidad
            respuesta= IdireccionBusiness.AddUpdateDireccion(direccionDomainModel);
            DireccionDomainModel direccionMD = IdireccionBusiness.GetDireccionInsertada(direccionDomainModel);
            IpersonalBusiness.AddUpdatePersonalDireccion(direccionMD,IdPersonal);
            return respuesta;
        }

        #endregion

        #region Consultar Datos de Direccion
      
        public JsonResult ConsultarDatosDireccion()
        {
            int IdPersonal = SessionPersister.AccountSession.IdPersonal;
            var datosDireccion = IdireccionBusiness.GetDireccion(IdPersonal); 
            return Json(datosDireccion, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region  Consultar los datos del estado de los habitos personales

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
                direcciones = IdireccionBusiness.GetDireccion(IdentityPersonal).Where(p => p.StrCalle.Contains(param.sSearch)).ToList();
               

            }
            else
            {
                totalCount = IdireccionBusiness.GetDireccion(IdentityPersonal).Count();


                direcciones = IdireccionBusiness.GetDireccion(IdentityPersonal).OrderBy(p => p.StrCalle)
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
            int IdPersonal = SessionPersister.AccountSession.IdPersonal;
            DireccionDomainModel direccionDM = IdireccionBusiness.GetDireccionPersonal(IdDireccion, IdPersonal);
            
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
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            DireccionDomainModel direccionDM = IdireccionBusiness.GetDireccionPersonal(direccionVM.IdDireccion, idPersonal);
            if (direccionDM != null)
            {
                if (IpersonalBusiness.UpdateCampoDireccionId(idPersonal))
                {
                    IdireccionBusiness.DeleteDireccion(direccionDM);
                }
                
            }
            ViewBag.Pais = new SelectList(IdireccionBusiness.GetPais(), "IdPais", "StrValor");
            ViewBag.Estados = new SelectList("");
            ViewBag.Municipios = new SelectList("");
            ViewBag.IdColonia = new SelectList("");
            return View("Create");
        }
        #endregion



    }
}