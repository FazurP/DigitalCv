using AppDigitalCv.Business.Enum;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class CapituloLibroController : Controller
    {

        ICapituloLibro capituloLibroBusiness;
        IPaisBusiness paisBusiness;
        IProgresoProdep progresoProdep;
        List list = new List();

        public CapituloLibroController(ICapituloLibro _capituloLibroBusiness, IPaisBusiness _paisBusiness,
            IProgresoProdep _progresoProdep) {
            capituloLibroBusiness = _capituloLibroBusiness;
            paisBusiness = _paisBusiness;
            progresoProdep = _progresoProdep;
        }
        /// <summary>
        /// Este metodo se encarga de cargar la pantalla con todos sus elementos
        /// </summary>
        /// <returns>una vista</returns>
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                //ViewBag.Progreso = new List<ProgresoProdepDomainModel>(progresoProdep.GetProgresoByPersonal(SessionPersister.AccountSession.IdPersonal));
                ViewBag.enumEstadoActual = new SelectList(list.FillEstado());
                ViewBag.enumProposito = new SelectList(list.FillProposito());
                ViewBag.IdPais = new SelectList(paisBusiness.GetPais(), "IdPais", "StrValor");
                return View();
            }
            else {
                return RedirectToAction("Login", "Seguridad");
            }
        }
        /// <summary>
        /// Este metodo se encarga de recibir un objeto con los datos ingresador por el usuario y validarlos para su
        /// insercion.
        /// </summary>
        /// <param name="capituloLibroVM">recibe los datos ingresados por el usuario</param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult Create(CapituloLibroVM capituloLibroVM)
        {
            if (ModelState.IsValid)
            {
                this.AddUpdateCapitulo(capituloLibroVM);
            }
            return RedirectToAction("Create", "CapituloLibro");
        }
        /// <summary>
        /// Este metodo se encarga de insertar o actualizar los datos ingresador por el usuario, previamente ya validados.
        /// </summary>
        /// <param name="capituloLibro">recibe los datos ingresador por el usuario</param>
        /// <returns>true o false</returns>
        public bool AddUpdateCapitulo(CapituloLibroVM capituloLibro)
        {
            bool respuesta = false;
            capituloLibro.idPersonal = SessionPersister.AccountSession.IdPersonal;
            CapituloLibroDomainModel capituloLibroDomainModel = new CapituloLibroDomainModel();
            ProgresoProdepVM progresoProdepVM = new ProgresoProdepVM();
            ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

            progresoProdepVM.id = 0;
            progresoProdepVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            progresoProdepVM.idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_EXITOSO);
            Mapper.Map(capituloLibro, capituloLibroDomainModel);
            Mapper.Map(progresoProdepVM, progresoProdepDM);

            progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
            capituloLibroDomainModel.idStatus = progresoProdepDM.idStatus;
            respuesta = capituloLibroBusiness.AddUpdateCapituloLibro(capituloLibroDomainModel);

            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de obtener los datos que el usuario tenga registrados.
        /// </summary>
        /// <param name="param">parametros del la tabla</param>
        /// <returns>un Json con los registrados del usuario.</returns>
        [HttpGet]
        public JsonResult GetCapitulosLibros(DataTablesParam param)
        {

            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<CapituloLibroDomainModel> capituloDM = new List<CapituloLibroDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                capituloDM = capituloLibroBusiness.GetCapitulosLibrosByPersonal(IdentityPersonal).Where(p => p.strTitulo.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = capituloLibroBusiness.GetCapitulosLibrosByPersonal(IdentityPersonal).Count();


                capituloDM = capituloLibroBusiness.GetCapitulosLibrosByPersonal(IdentityPersonal).OrderBy(p => p.strTitulo)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = capituloDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = capituloDM.Count(),
                iTotalRecords = capituloDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Este metodo se encarga de obtener un CapituloLibro para su eliminacion.
        /// </summary>
        /// <param name="_idLibro">recibe el id del capituloLibro que se va a eliminar</param>
        /// <returns>una vista parcial, mas el objeto con los datos del libro</returns>
        [HttpGet]
        public ActionResult GetCapituloLibro(int _idLibro) {

            CapituloLibroDomainModel capituloLibroDM = new CapituloLibroDomainModel();

            capituloLibroDM = capituloLibroBusiness.GetCapituloLibro(_idLibro);

            if (capituloLibroBusiness != null)
            {
                CapituloLibroVM capituloLibroVM = new CapituloLibroVM();

                AutoMapper.Mapper.Map(capituloLibroDM, capituloLibroVM);
                return PartialView("_Eliminar", capituloLibroVM);

            }

            return PartialView("_Eliminar");
        }
        /// <summary>
        /// Este metodo se encarga de eliminar un CapituloLibro
        /// </summary>
        /// <param name="_capituloLibroVM">recibe los datos del CapituloLibro que se va a eliminar</param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult DeleteCapituloLibro(CapituloLibroVM _capituloLibroVM) {

            CapituloLibroDomainModel capituloLibroDM = new CapituloLibroDomainModel();

            capituloLibroDM = capituloLibroBusiness.GetCapituloLibro(_capituloLibroVM.id);

            if (capituloLibroDM != null)
            {
                if (capituloLibroBusiness.GetCapitulosLibrosByPersonal(capituloLibroDM.idPersonal).Count == 1)
                {
                    ProgresoProdepDomainModel progresoProdepDM = progresoProdep.GetProgresoPersonal(SessionPersister.AccountSession.IdPersonal,int.Parse(Recursos.RecursosSistema.REGISTRO_EXITOSO));
                    progresoProdep.DeleteProgresoProdep(progresoProdepDM.id);
                    capituloLibroBusiness.DeleteCapituloLibro(capituloLibroDM.id);
                }
                else {
                    capituloLibroBusiness.DeleteCapituloLibro(capituloLibroDM.id);
                }
            }

            return RedirectToAction("Create", "CapituloLibro");
        }
        /// <summary>
        /// Este metodo se encarga obtener un CapituloLibro para su actualizacion
        /// </summary>
        /// <param name="_idLibro">recibe el id del capituloLibro que se va a actualizar</param>
        /// <returns>una vista parcial, mas el objeto con los datos del libro</returns>
        [HttpGet]
        public ActionResult GetCapituloLibroUpdate(int _idLibro) {

            CapituloLibroDomainModel capituloLibroDM = new CapituloLibroDomainModel();

            capituloLibroDM = capituloLibroBusiness.GetCapituloLibro(_idLibro);

            if (capituloLibroDM != null)
            {
                CapituloLibroVM capituloLibroVM = new CapituloLibroVM();

                AutoMapper.Mapper.Map(capituloLibroDM, capituloLibroVM);
                return PartialView("_Editar", capituloLibroVM);

            }

            return PartialView("_Editar");
        }
        /// <summary>
        /// Este metodo se encarga de actualizar un CapituloLibro
        /// </summary>
        /// <param name="capituloLibroVM">recibe los nuevos datos del capituloLibro</param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult UpdateCapituloLibro(CapituloLibroVM capituloLibroVM) {

            CapituloLibroDomainModel capituloLibroDM = new CapituloLibroDomainModel();

            Mapper.Map(capituloLibroVM,capituloLibroDM);

            if (capituloLibroDM.id > 0)
            {       
                capituloLibroBusiness.AddUpdateCapituloLibro(capituloLibroDM);
            }

            return RedirectToAction("Create","CapituloLibro");
        }
    }
}