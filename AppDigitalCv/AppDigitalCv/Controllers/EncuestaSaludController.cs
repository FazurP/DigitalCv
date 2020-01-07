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
    public class EncuestaSaludController : Controller
    {
        IEncuestaSaludBusiness encuestaSaludBusiness;
    
        public EncuestaSaludController(IEncuestaSaludBusiness _encuestaSaludBusiness) 
        {
            encuestaSaludBusiness = _encuestaSaludBusiness;
        }

        [HttpGet]
        public ActionResult Create() 
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewData["Respuestas04.idOpcion"] = new SelectList(encuestaSaludBusiness.GetAllOpcionesRespuesta04(), "id", "strValor");
                ViewData["Respuestas05.idRh"] = new SelectList(encuestaSaludBusiness.GetAllRhs(), "id", "strValor");
                ViewData["Respuestas05.idGrupoSanguineo"] = new SelectList(encuestaSaludBusiness.GetAllGruposSanguineos(), "id", "strValor");

                return View();
            }
            return RedirectToAction("Login", "Seguridad");
        }

        [HttpPost]
        public ActionResult Create(EncuestaVM encuestaVM)
        {
            encuestaVM.idPersonal = SessionPersister.AccountSession.IdPersonal;

            EncuestaDomainModel encuestaDomainModel = new EncuestaDomainModel();

            AutoMapper.Mapper.Map(encuestaVM, encuestaDomainModel);

            encuestaSaludBusiness.AddEncuesta(encuestaDomainModel);

            return RedirectToAction("Create","EncuestaSalud");
        }

        [HttpGet]
        public JsonResult GetEncuestas(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<EncuestaDomainModel> competenciaDM = new List<EncuestaDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                competenciaDM = encuestaSaludBusiness.GetEncuesta(IdentityPersonal).Where(p => p.dteFechaRealizo.ToString().Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = encuestaSaludBusiness.GetEncuesta(IdentityPersonal).Count();

                competenciaDM = encuestaSaludBusiness.GetEncuesta(IdentityPersonal).OrderBy(p => p.dteFechaRealizo)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }
            return Json(new
            {
                aaData = competenciaDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = competenciaDM.Count(),
                iTotalRecords = competenciaDM.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetEncuestaSaludDelete(int _idEncuestaSalud)
        {
           
            if (_idEncuestaSalud > 0)
            {
                EncuestaDomainModel encuestaDomainModel = encuestaSaludBusiness.GetEncuestaById(_idEncuestaSalud);
                EncuestaVM encuestaVM = new EncuestaVM();

                AutoMapper.Mapper.Map(encuestaDomainModel, encuestaVM);

                return PartialView("_Eliminar", encuestaVM);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult DeleteEncuesta(EncuestaVM encuestaVM)
        {
            if (encuestaVM.id > 0)
            {
                encuestaSaludBusiness.DeleteEncuesta(encuestaVM.id);
            }

            return RedirectToAction("Create","EncuestaSalud");
        }
    }
}