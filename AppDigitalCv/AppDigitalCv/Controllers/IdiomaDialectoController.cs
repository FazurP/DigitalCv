using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Security;


namespace AppDigitalCv.Controllers
{
    public class IdiomaDialectoController : Controller
    {
        IIdiomaDialectoBusiness IidiomaDialectoBusiness;
        Porcentajes p = new Porcentajes();

        public IdiomaDialectoController(IIdiomaDialectoBusiness _IidiomaBusiness)
        {
            IidiomaDialectoBusiness = _IidiomaBusiness;
        }

        // GET: Idioma
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdIdioma = new SelectList(IidiomaDialectoBusiness.GetIdioma(), "IdIdioma", "StrDescripcion");
            ViewBag.StrEscrituraProcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrLecturaPorcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrEntendimientoPorcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrComunicacionPorcentaje = new SelectList(p.GetPorcentajes());
            return View();
        }

        /// <summary>
        /// Metodo para insertar el idioma que habla un usuario
        /// </summary>
        /// <param name="idiomaDialectoVM"> Pide un parametro de tipo view model </param>
        /// <returns> Regresa una lista con los datos pedidos </returns>
        [HttpPost]
        public ActionResult Create([Bind(Include = "StrComunicacionPorcentaje, StrEscrituraProcentaje, StrEntendimientoPorcentaje, StrLecturaPorcentaje, IdIdioma, IdDialecto, IdPersonal")] IdiomaDialectoVM idiomaDialectoVM)
        {
            int idPersonal = 1;
            //idiomaDialectoVM.IdIdioma = ViewBag.IdIdioma;
            idiomaDialectoVM.IdPersonal = idPersonal;
            if (ModelState.IsValid)
            {
                //Informacion para insertar
                AddEditIdioma(idiomaDialectoVM);
               // AddEditDialecto(idiomaDialectoVM);
                return RedirectToAction("Create","Personal");
            }
            return View("Create");
        }

        #region Agregar o editar una entidad
        public bool AddEditIdioma(IdiomaDialectoVM idiomaDialectoVM)
        {

            IdiomaDialectoDomainModel idiomaDialectoDM = new IdiomaDialectoDomainModel();
            AutoMapper.Mapper.Map(idiomaDialectoVM, idiomaDialectoDM);
            return IidiomaDialectoBusiness.AddUpdateIdioma(idiomaDialectoDM);
        }
        #endregion
    }
}