﻿using AppDigitalCv.Business.Interface;
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
            ViewBag.idLengua = new SelectList(IdialectoIdiomaBusiness.GetDialecto(), "IdDialecto", "StrDescripcion");
            ViewBag.strEscritura = new SelectList(p.GetPorcentajes());
            ViewBag.strLectura = new SelectList(p.GetPorcentajes());
            ViewBag.strEntendimiento = new SelectList(p.GetPorcentajes());
            ViewBag.strComunicacion = new SelectList(p.GetPorcentajes());
            return View();
            }
        }
        /// <summary>
        /// Este metodo se encarga de insertar los datos de dialecto.
        /// </summary>
        /// <param name="dialectoIdiomaVM"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(LenguasVM lenguasVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            lenguasVM.idPersonal = idPersonal;
            if (ModelState.IsValid)
            {
                AddEditDialecto(lenguasVM);
            }
                return RedirectToAction("Create","DialectoIdioma");   
        }

        /// <summary>
        /// Este metodo se encarga de pasar los datos del view model al domain model para su insersion o actualizacion.
        /// </summary>
        /// <param name="dialectoIdiomaVM"></param>
        /// <returns></returns>
        public bool AddEditDialecto(LenguasVM lenguasVM)
        {
            LenguasDomainModel lenguasDomainModel = new LenguasDomainModel();
            AutoMapper.Mapper.Map(lenguasVM, lenguasDomainModel);
            return IdialectoIdiomaBusiness.AddUpdateDialecto(lenguasDomainModel);
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
            List<LenguasDomainModel> dialectoDM = new List<LenguasDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                dialectoDM = dialectoBusiness.GetDialectosByIdPersonal(IdentityPersonal).Where(p => p.strComunicacion.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = dialectoBusiness.GetDialectosByIdPersonal(IdentityPersonal).Count();


                dialectoDM = dialectoBusiness.GetDialectosByIdPersonal(IdentityPersonal).OrderBy(p => p.strComunicacion)
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
            LenguasVM lenguas = new LenguasVM();
            LenguasDomainModel lenguasDomainModel = new LenguasDomainModel();

            

            if (idDialecto > 0)
            {
                lenguasDomainModel = IdialectoIdiomaBusiness.GetDialectoPersonales(idDialecto, idPersonal);

                AutoMapper.Mapper.Map(lenguasDomainModel, lenguas);

                return PartialView("_Eliminar", lenguas);
            }
            
            return PartialView();
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
            LenguasVM idiomaDialectoVM = new LenguasVM();
            LenguasDomainModel idiomaDialectoDM = new LenguasDomainModel();

            if (idDialecto > 0)
            {
                ViewBag.strEscritura = new SelectList(p.GetPorcentajes());
                ViewBag.strLectura = new SelectList(p.GetPorcentajes());
                ViewBag.strEntendimiento = new SelectList(p.GetPorcentajes());
                ViewBag.strComunicacion = new SelectList(p.GetPorcentajes());
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
        public ActionResult DeleteDialectoById(LenguasVM lenguasVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            LenguasDomainModel lenguasDomainModel = IdialectoIdiomaBusiness.GetDialectoPersonales(lenguasVM.id, idPersonal);

            if (lenguasDomainModel != null)
            {
                IdialectoIdiomaBusiness.DeleteDialectoDialectos(lenguasDomainModel);
            }

            return RedirectToAction("Create","DialectoIdioma");
        }
        /// <summary>
        /// Este metodo recibe un objeto con los nuevos datos que se ingresaron en la vista parcial de _Editar
        /// para su actualizacion
        /// </summary>
        /// <param name="idiomaDialectoVM"></param>
        [HttpPost]
        public void EditarDialectosPersonales(LenguasVM lenguasVM)
        {

            LenguasDomainModel LenguasDomainModel = new LenguasDomainModel();

            AutoMapper.Mapper.Map(lenguasVM, LenguasDomainModel);

            if (lenguasVM.id > 0)
            {
                IdialectoIdiomaBusiness.AddUpdateDialecto(LenguasDomainModel);
            }

        }

    }
}