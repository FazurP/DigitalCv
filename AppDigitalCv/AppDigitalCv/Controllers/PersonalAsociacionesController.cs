using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Business;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;

namespace AppDigitalCv.Controllers
{
    public class PersonalAsociacionesController : Controller
    {
        IAsociacionesBusiness IasociacionesBusiness;
        ITipoEmpresaBusiness ItipoEmpresaBusiness;
        public PersonalAsociacionesController(IAsociacionesBusiness _IasociacionesBusiness, ITipoEmpresaBusiness _ItipoEmpresaBusiness)
        {
            IasociacionesBusiness = _IasociacionesBusiness;
            ItipoEmpresaBusiness = _ItipoEmpresaBusiness;
        }




        // GET: PersonalAsociaciones
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Asociacion = new SelectList(IasociacionesBusiness.GetAsociaciones(), "IdAsociacion", "StrDescripcion");
            ViewBag.TipoEmpresa = new SelectList("");
            return View();
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








    }
}