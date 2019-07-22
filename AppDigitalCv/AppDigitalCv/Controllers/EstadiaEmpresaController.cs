using AppDigitalCv.Business.Enum;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Repository.Infraestructure.Contract;
using AppDigitalCv.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class EstadiaEmpresaController : Controller
    {
        IEstadiaEmpresaBusiness estadiaEmpresaBusiness;
        ITipoProductoBusiness tipoProductoBusiness;
        IProgramaEducativoBusiness programaEducativoBusiness;
        IProgresoProdep progresoProdep;
        IDocumentosBusiness documentosBusiness;
        List list = new List();

        public EstadiaEmpresaController(IEstadiaEmpresaBusiness _estadiaEmpresaBusiness,ITipoProductoBusiness _tipoProductoBusiness,
            IProgramaEducativoBusiness _programaEducativoBusiness, IProgresoProdep _progresoProdep, IDocumentosBusiness _documentosBusiness)
        {
            estadiaEmpresaBusiness = _estadiaEmpresaBusiness;
            tipoProductoBusiness = _tipoProductoBusiness;
            programaEducativoBusiness = _programaEducativoBusiness;
            progresoProdep = _progresoProdep;
            documentosBusiness = _documentosBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idTipoProducto = new SelectList(tipoProductoBusiness.GetAllTipoProducto(),"id","strDescripcion");
                ViewBag.idProgramaEducativo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(), "idProgramaEducativo", "strDescripcion");
                ViewBag.strEstadoEstadia = new SelectList(list.FillEstadoEstadia());
                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
            
        }
    }
}