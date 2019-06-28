using AppDigitalCv.Business.Enum;
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
    public class CapituloLibroController : Controller
    {

        ICapituloLibro capituloLibroBusiness;
        IPaisBusiness paisBusiness;
        List list = new List();

        public CapituloLibroController(ICapituloLibro _capituloLibroBusiness,IPaisBusiness _paisBusiness) {
            capituloLibroBusiness = _capituloLibroBusiness;
            paisBusiness = _paisBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.enumEstadoActual = new SelectList(list.FillEstado());
                ViewBag.enumProposito = new SelectList(list.FillProposito());
                ViewBag.IdPais = new SelectList(paisBusiness.GetPais(), "IdPais", "StrValor");
                return View();
            }
            else {
                return RedirectToAction("Login", "Seguridad");
            }
        }
        [HttpPost]
        public ActionResult Create(CapituloLibroVM capituloLibroVM)
            {
            if (ModelState.IsValid)
            {
                capituloLibroVM.idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_EXITOSO);
                this.AddUpdateCapitulo(capituloLibroVM);
            }
            return RedirectToAction("Create","CapituloLibro");
        }

        public bool AddUpdateCapitulo(CapituloLibroVM capituloLibro)
        {
            bool respuesta = false;
            capituloLibro.idPersonal = SessionPersister.AccountSession.IdPersonal;
            CapituloLibroDomainModel capituloLibroDomainModel = new CapituloLibroDomainModel();

            AutoMapper.Mapper.Map(capituloLibro, capituloLibroDomainModel);

            respuesta = capituloLibroBusiness.AddUpdateCapituloLibro(capituloLibroDomainModel);

            return respuesta;
        }

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
    }
}