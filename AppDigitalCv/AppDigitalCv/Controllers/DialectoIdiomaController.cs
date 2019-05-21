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
    public class DialectoIdiomaController : Controller
    {
        IDialectoIdiomaBusiness IdialectoIdiomaBusiness;
        IDialectoBusiness dialectoBusiness;
        Porcentajes p = new Porcentajes();

        public DialectoIdiomaController(IDialectoIdiomaBusiness _IdialectoBusiness, IDialectoBusiness _dialectoBusiness)
        {
            IdialectoIdiomaBusiness = _IdialectoBusiness;
            dialectoBusiness = _dialectoBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession == null)
            {
                return RedirectToAction("Login", "Seguridad");
            }
            else { 
            ViewBag.IdDialecto = new SelectList(IdialectoIdiomaBusiness.GetDialecto(), "IdDialecto", "StrDescripcion");
            ViewBag.StrEscrituraProcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrLecturaPorcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrEntendimientoPorcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrComunicacionPorcentaje = new SelectList(p.GetPorcentajes());
            return View();
            }
        }
        /// <summary>
        /// Este metodo se encarga de insertar los datos de dialecto.
        /// </summary>
        /// <param name="dialectoIdiomaVM"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create([Bind(Include = "StrComunicacionPorcentaje, StrEscrituraProcentaje, StrEntendimientoPorcentaje, StrLecturaPorcentaje, IdIdioma, IdDialecto, IdPersonal")] IdiomaDialectoVM dialectoIdiomaVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            dialectoIdiomaVM.IdPersonal = idPersonal;
            if (ModelState.IsValid && dialectoIdiomaVM.IdDialecto > 0)
            {
                //Informacion para insertar
                AddEditDialecto(dialectoIdiomaVM);
                // AddEditDialecto(idiomaDialectoVM);
                return RedirectToAction("Create", "DialectoIdioma");
            }
          
                return RedirectToAction("Create","DialectoIdioma");
            
        }

        /// <summary>
        /// Este metodo se encarga de pasar los datos del view model al domain model para su insersion o actualizacion.
        /// </summary>
        /// <param name="dialectoIdiomaVM"></param>
        /// <returns></returns>
        public bool AddEditDialecto(IdiomaDialectoVM dialectoIdiomaVM)
        {
            IdiomaDialectoDomainModel dialectoIdiomaDM = new IdiomaDialectoDomainModel();
            AutoMapper.Mapper.Map(dialectoIdiomaVM, dialectoIdiomaDM);
            return IdialectoIdiomaBusiness.AddUpdateDialecto(dialectoIdiomaDM);
        }
        /// <summary>
        /// Este metodo se encarga de cargar los datos en la tabla desde la base de datos
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetDialecto(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<DialectoDomainModel> dialectoDM = new List<DialectoDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                dialectoDM = dialectoBusiness.GetDialectosByIdPersonal(IdentityPersonal).Where(p => p.strDescripcion.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = dialectoBusiness.GetDialectosByIdPersonal(IdentityPersonal).Count();


                dialectoDM = dialectoBusiness.GetDialectosByIdPersonal(IdentityPersonal).OrderBy(p => p.strDescripcion)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = dialectoDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = dialectoDM.Count(),
                iTotalRecords = dialectoDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Este metodo se encarga de obtener un dialecto para mostrarlo en la vista parcial
        /// </summary>
        /// <param name="idDialecto"></param>
        /// <returns>una vista parcial con los datos</returns>
        [HttpGet]
        public ActionResult GetDialectoById(int idDialecto)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;

            DialectoDomainModel dialectoDM = dialectoBusiness.GetDialecto(idDialecto, idPersonal);

            if (dialectoDM != null)
            {
                DialectoVM dialectoVM = new DialectoVM();
                AutoMapper.Mapper.Map(dialectoDM, dialectoVM);
                return PartialView("_Eliminar", dialectoVM);
            }

            return View();
        }
        /// <summary>
        /// Este metodo se encarga de obtener los datos de un dialecto para su actualizacion y mostrar 
        /// en la vista parcial
        /// </summary>
        /// <param name="idDialecto"></param>
        /// <returns>una vista parcial con los datos</returns>
        [HttpGet]
        public ActionResult GetDialectoByIdEdit(int idDialecto)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            IdiomaDialectoVM idiomaDialectoVM = new IdiomaDialectoVM();
            IdiomaDialectoDomainModel idiomaDialectoDM = new IdiomaDialectoDomainModel();

            if (idDialecto > 0)
            {

                ViewBag.StrEscrituraProcentaje = new SelectList(p.GetPorcentajes());
                ViewBag.StrLecturaPorcentaje = new SelectList(p.GetPorcentajes());
                ViewBag.StrEntendimientoPorcentaje = new SelectList(p.GetPorcentajes());
                ViewBag.StrComunicacionPorcentaje = new SelectList(p.GetPorcentajes());
                idiomaDialectoDM = IdialectoIdiomaBusiness.GetDialectoPersonales(idDialecto, idPersonal);


            }

            AutoMapper.Mapper.Map(idiomaDialectoDM, idiomaDialectoVM);
            return PartialView("_Editar", idiomaDialectoVM);
        }
        /// <summary>
        /// Este metodo recibe un objeto del dialecto que se cargo en la vista parcial de _Eliminar
        /// para su eliminacion.
        /// </summary>
        /// <param name="dialectoVM"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult DeleteDialectoById(DialectoVM dialectoVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            IdiomaDialectoDomainModel idiomaDialectoDM = IdialectoIdiomaBusiness.GetDialectoPersonales(dialectoVM.IdDialecto, idPersonal);

            if (idiomaDialectoDM != null)
            {
                IdialectoIdiomaBusiness.DeleteDialectoDialectos(idiomaDialectoDM);
            }

            return View(Create());
        }
        /// <summary>
        /// Este metodo recibe un objeto con los nuevos datos que se ingresaron en la vista parcial de _Editar
        /// para su actualizacion
        /// </summary>
        /// <param name="idiomaDialectoVM"></param>
        [HttpPost]
        public void EditarDialectosPersonales(IdiomaDialectoVM idiomaDialectoVM)
        {

            IdiomaDialectoDomainModel idiomaDialectoDM = new IdiomaDialectoDomainModel();

            AutoMapper.Mapper.Map(idiomaDialectoVM, idiomaDialectoDM);

            if (idiomaDialectoVM.IdIdiomaDialectoPersonal > 0)
            {
                IdialectoIdiomaBusiness.AddUpdateDialecto(idiomaDialectoDM);
            }

        }

    }
}