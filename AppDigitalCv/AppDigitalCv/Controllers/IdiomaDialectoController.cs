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
    public class IdiomaDialectoController : Controller
    {
        IIdiomaDialectoBusiness IidiomaDialectoBusiness;
        IIdiomaBusiness IidiomaBusinnes;
        Porcentajes p = new Porcentajes();

        public IdiomaDialectoController(IIdiomaDialectoBusiness _IidiomaBusiness, IIdiomaBusiness _Iidioma)
        {
            IidiomaDialectoBusiness = _IidiomaBusiness;
            IidiomaBusinnes = _Iidioma;
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession == null)
            {
                return RedirectToAction("Login","Seguridad");
            }
            else { 
            ViewBag.IdIdioma = new SelectList(IidiomaDialectoBusiness.GetIdioma(), "IdIdioma", "StrDescripcion");
            ViewBag.StrEscrituraProcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrLecturaPorcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrEntendimientoPorcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrComunicacionPorcentaje = new SelectList(p.GetPorcentajes());
            return View();
            }
        }
                                                                                                                        
        /// <summary>
        /// Metodo para insertar el idioma que habla un usuario
        /// </summary>
        /// <param name="idiomaDialectoVM"> Pide un parametro de tipo view model </param>
        /// <returns> Regresa una lista con los datos pedidos </returns>
        [HttpPost]
        public ActionResult Create([Bind(Include = "StrComunicacionPorcentaje, StrEscrituraProcentaje, StrEntendimientoPorcentaje, StrLecturaPorcentaje, IdIdioma, IdDialecto, IdPersonal")] IdiomaDialectoVM idiomaDialectoVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            //idiomaDialectoVM.IdIdioma = ViewBag.IdIdioma;
            idiomaDialectoVM.IdPersonal = idPersonal;
            idiomaDialectoVM.DteFechaRegistro = DateTime.Now;
            if (ModelState.IsValid && idiomaDialectoVM.IdIdioma > 0)
            {
                //Informacion para insertar
                AddEditIdioma(idiomaDialectoVM);
               // AddEditDialecto(idiomaDialectoVM);
                return RedirectToAction("Create","IdiomaDialecto");
            }
            return RedirectToAction("Create", "IdiomaDialecto");
        }

        #region Agregar o editar una entidad
        private bool AddEditIdioma(IdiomaDialectoVM idiomaDialectoVM)
        {

            IdiomaDialectoDomainModel idiomaDialectoDM = new IdiomaDialectoDomainModel();
            AutoMapper.Mapper.Map(idiomaDialectoVM, idiomaDialectoDM);
            return IidiomaDialectoBusiness.AddUpdateIdioma(idiomaDialectoDM);
        }
        #endregion
        /// <summary>
        /// Este metodo se encarga mostrar los idiomas en la tabla
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetIdiomas(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<IdiomaDomainModel> alergiasDM = new List<IdiomaDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                alergiasDM = IidiomaBusinnes.GetIdiomasByIdPersonal(IdentityPersonal).Where(p => p.strDescripcion.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = IidiomaBusinnes.GetIdiomasByIdPersonal(IdentityPersonal).Count();


                alergiasDM = IidiomaBusinnes.GetIdiomasByIdPersonal(IdentityPersonal).OrderBy(p => p.strDescripcion)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = alergiasDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = alergiasDM.Count(),
                iTotalRecords = alergiasDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Este metodo se encarga de obtener el idioma que se va a mostrar en el modal
        /// </summary>
        /// <param name="idIdioma"></param>
        /// <returns>una vista parcial con el idioma</returns>
        [HttpGet]
        public ActionResult GetIdiomaById(int idIdioma)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
         
            IdiomaDomainModel idiomaDM = IidiomaBusinnes.GetIdioma(idIdioma, idPersonal);

            if (idiomaDM != null)
            {
                IdiomaVM idiomaVM = new IdiomaVM();
                AutoMapper.Mapper.Map(idiomaDM, idiomaVM);
                return PartialView("_Eliminar", idiomaVM);
            }

            return View();
        }
        /// <summary>
        /// Este metodo se encarga de eliminar un idioma
        /// </summary>
        /// <param name="idiomaVM"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult DeleteIdiomaById(IdiomaVM idiomaVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            IdiomaDialectoDomainModel alergiasPersonalDM = IidiomaDialectoBusiness.GetIdiomasPersonales(idiomaVM.IdIdioma, idPersonal);

            if (alergiasPersonalDM != null)
            {
                IidiomaDialectoBusiness.DeleteIdiomasDialectos(alergiasPersonalDM);
            }

            return View(Create());
        }

        [HttpGet]
        public ActionResult GetIdiomaByIdEdit(int idIdioma)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            IdiomaDialectoVM idiomaDialectoVM = new IdiomaDialectoVM();
            //IdiomaDomainModel idiomaDM = IidiomaBusinnes.GetIdioma(idIdioma, idPersonal);
            IdiomaDialectoDomainModel idiomaDialectoDM = new IdiomaDialectoDomainModel();

            //IdiomaDialectoDomainModel idiomaDialectoDM = IidiomaDialectoBusiness.GetIdiomasPersonales(idIdioma,idPersonal);


            if (idIdioma > 0)
            {
         
                ViewBag.StrEscrituraProcentaje = new SelectList(p.GetPorcentajes());
                ViewBag.StrLecturaPorcentaje = new SelectList(p.GetPorcentajes());
                ViewBag.StrEntendimientoPorcentaje = new SelectList(p.GetPorcentajes());
                ViewBag.StrComunicacionPorcentaje = new SelectList(p.GetPorcentajes());
                idiomaDialectoDM = IidiomaDialectoBusiness.GetIdiomasPersonales(idIdioma,idPersonal);
               
              
            }

            AutoMapper.Mapper.Map(idiomaDialectoDM, idiomaDialectoVM);
            return PartialView("_Editar", idiomaDialectoVM);
        }

        [HttpPost]
        public void EditarIdiomasPersonales(IdiomaDialectoVM idiomaDialectoVM)
        {

            IdiomaDialectoDomainModel idiomaDialectoDM = new IdiomaDialectoDomainModel();

            AutoMapper.Mapper.Map(idiomaDialectoVM, idiomaDialectoDM);

            if (idiomaDialectoVM.IdIdiomaDialectoPersonal > 0)
            {
                IidiomaDialectoBusiness.AddUpdateIdioma(idiomaDialectoDM);
            }

        }
    }
}