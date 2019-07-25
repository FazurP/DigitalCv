using AppDigitalCv.Business.Enum;
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
    public class TutoriasController : Controller
    {
        ITutoriasBusiness tutoriasBusiness;
        ITipoEstudioBusiness tipoEstudioBusiness;
        IProgramaEducativoBusiness programaEducativoBusiness;
        IProgresoProdep progresoProdep;
        List list = new List();

        public TutoriasController(ITutoriasBusiness _tutoriasBusiness,ITipoEstudioBusiness _tipoEstudioBusiness,
            IProgramaEducativoBusiness _programaEducativoBusiness, IProgresoProdep _progresoProdep)
        {
            tutoriasBusiness = _tutoriasBusiness;
            tipoEstudioBusiness = _tipoEstudioBusiness;
            programaEducativoBusiness = _programaEducativoBusiness;
            progresoProdep = _progresoProdep;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.strTutoria = new SelectList(list.FillTutoria());
                ViewBag.idTipoEstudio = new SelectList(tipoEstudioBusiness.GetTiposEstudios(),"idTipoEstudio","strDescripcion");
                ViewBag.idProgramaEductivo = new SelectList("");
                ViewBag.strTipo = new SelectList(list.FillTipoTutoria());
                ViewBag.strEstadoTutoria = new SelectList(list.FillEstadoTutoria());

                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
        }

        [HttpPost]
        public ActionResult GetProgramaEducativoByTipoEstudio(int _idTipoEstudio)
        {

            if (_idTipoEstudio > 0)
            {
                List<ProgramaEducativoDomainModel> programaEducativos = programaEducativoBusiness.
                    GetProgramasEducativosByTipoEstudio(_idTipoEstudio);
                List<ProgramaEducativoVM> programasVM = new List<ProgramaEducativoVM>();

                AutoMapper.Mapper.Map(programaEducativos,programasVM);

                ViewBag.idProgramaEducativo = new SelectList(programasVM,
                "idProgramaEducativo", "strDescripcion");
            }         

            return PartialView("_ProgramaEducativo");
        }

    }
}