using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
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
        Porcentajes p = new Porcentajes();

        public DialectoIdiomaController(IDialectoIdiomaBusiness _IdialectoBusiness)
        {
            IdialectoIdiomaBusiness = _IdialectoBusiness;
        }

        // GET: DialectoIdioma
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdDialecto = new SelectList(IdialectoIdiomaBusiness.GetDialecto(), "IdDialecto", "StrDescripcion");
            ViewBag.StrEscrituraProcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrLecturaPorcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrEntendimientoPorcentaje = new SelectList(p.GetPorcentajes());
            ViewBag.StrComunicacionPorcentaje = new SelectList(p.GetPorcentajes());
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "StrComunicacionPorcentaje, StrEscrituraProcentaje, StrEntendimientoPorcentaje, StrLecturaPorcentaje, IdIdioma, IdDialecto, IdPersonal")] IdiomaDialectoVM dialectoIdiomaVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            dialectoIdiomaVM.IdPersonal = idPersonal;
            if (ModelState.IsValid)
            {
                //Informacion para insertar
                AddEditDialecto(dialectoIdiomaVM);
                // AddEditDialecto(idiomaDialectoVM);
                return RedirectToAction("Create", "Personal");
            }
            return View("Create");
        }


        public bool AddEditDialecto(IdiomaDialectoVM dialectoIdiomaVM)
        {
            IdiomaDialectoDomainModel dialectoIdiomaDM = new IdiomaDialectoDomainModel();
            AutoMapper.Mapper.Map(dialectoIdiomaVM, dialectoIdiomaDM);
            return IdialectoIdiomaBusiness.AddUpdateDialecto(dialectoIdiomaDM);
        }

    }
}