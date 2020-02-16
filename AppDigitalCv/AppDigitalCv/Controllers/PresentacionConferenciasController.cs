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
    public class PresentacionConferenciasController : Controller
    {
        private IPresentacionPonenciasBusiness presentacionPonenciasBusiness;

        public PresentacionConferenciasController(IPresentacionPonenciasBusiness _presentacionPonenciasBusiness)
        {
            presentacionPonenciasBusiness = _presentacionPonenciasBusiness;
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Seguridad");
            }

        }

        [HttpPost]
        public ActionResult Create(PresentacionPonenciasVM presentacionPonenciasVM)
        {

            if (ModelState.IsValid)
            {
                presentacionPonenciasVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
                PresentacionPonenciasDomainModel presentacionPonenciasDomainModel = new PresentacionPonenciasDomainModel();

                AutoMapper.Mapper.Map(presentacionPonenciasVM, presentacionPonenciasDomainModel);

                presentacionPonenciasBusiness.AddPonencia(presentacionPonenciasDomainModel);
            }

            return RedirectToAction("Create", "PresentacionConferencias");

        }

        [HttpGet]
        public JsonResult GetPresentacionesPonencias(DataTablesParam param)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            List<PresentacionPonenciasDomainModel> presentacion = new List<PresentacionPonenciasDomainModel>();
            List<PresentacionPonenciasVM> presentacionPonenciasVMs = new List<PresentacionPonenciasVM>();
            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                presentacion = presentacionPonenciasBusiness.GetPresentacionesPonencias(idPersonal).Where(p => p.strNombre.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = presentacionPonenciasBusiness.GetPresentacionesPonencias(idPersonal).Count();

                presentacion = presentacionPonenciasBusiness.GetPresentacionesPonencias(idPersonal).OrderBy(p => p.id)
                          .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = presentacion,
                sEcho = param.sEcho,
                iTotalDisplayRecords = presentacion.Count(),
                iTotalRecords = presentacion.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPresentacionPonencia(int idPonencia) 
        {
            if (idPonencia > 0)
            {
                PresentacionPonenciasDomainModel presentacionPonenciasDomainModel = presentacionPonenciasBusiness.GetPresentacionPonencia(idPonencia);
                PresentacionPonenciasVM presentacionPonenciasVM = new PresentacionPonenciasVM();
                AutoMapper.Mapper.Map(presentacionPonenciasDomainModel, presentacionPonenciasVM);
                return PartialView("_Eliminar", presentacionPonenciasVM);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult EliminarPonencia(PresentacionPonenciasVM presentacionPonenciasVM) 
        {
            if (presentacionPonenciasVM.id > 0)
            {
                presentacionPonenciasBusiness.DeletePresentacionPonencia(presentacionPonenciasVM.id);
            }

            return RedirectToAction("Create", "PresentacionConferencias");
        }
    }
}