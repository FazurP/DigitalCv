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
    public class TutoriasController : Controller
    {
        ITutoriasBusiness tutoriasBusiness;
        ITipoEstudioBusiness tipoEstudioBusiness;
        IProgramaEducativoBusiness programaEducativoBusiness;
        List list = new List();

        public TutoriasController(ITutoriasBusiness _tutoriasBusiness, ITipoEstudioBusiness _tipoEstudioBusiness,
            IProgramaEducativoBusiness _programaEducativoBusiness)
        {
            tutoriasBusiness = _tutoriasBusiness;
            tipoEstudioBusiness = _tipoEstudioBusiness;
            programaEducativoBusiness = _programaEducativoBusiness;

        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idProgramaEductivo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(), "idProgramaEducativo", "strDescripcion");
                ViewBag.strTipo = new SelectList(list.FillTipoTutoria());
                ViewBag.strEstadoTutoria = new SelectList(list.FillEstadoTutoria());

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Seguridad");
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

                AutoMapper.Mapper.Map(programaEducativos, programasVM);

                ViewBag.idProgramaEductivo = new SelectList(programasVM,
                "idProgramaEducativo", "strDescripcion");
            }

            return PartialView("_ProgramaEducativo");
        }

        [HttpPost]
        public ActionResult Create(TutoriasVM tutoriasVM)
        {
            if (ModelState.IsValid)
            {
                this.AddUpdateTutorias(tutoriasVM);
            }

            return RedirectToAction("Create", "Tutorias");
        }

        public bool AddUpdateTutorias(TutoriasVM tutoriasVM)
        {
            bool respuesta = false;

            int idPersonal = SessionPersister.AccountSession.IdPersonal;

            tutoriasVM.idPersonal = idPersonal;

            TutoriasDomainModel tutoriasDM = new TutoriasDomainModel();

            AutoMapper.Mapper.Map(tutoriasVM, tutoriasDM);
            tutoriasBusiness.AddUpdateTutorias(tutoriasDM);
            respuesta = true;

            return respuesta;
        }

        [HttpGet]
        public JsonResult GetTutorias(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<TutoriasDomainModel> tutorias = new List<TutoriasDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                tutorias = tutoriasBusiness.GetAllTutoriasByIdPersonal(IdentityPersonal).Where(p => p.strNombreEstudantes.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = tutoriasBusiness.GetAllTutoriasByIdPersonal(IdentityPersonal).Count();


                tutorias = tutoriasBusiness.GetAllTutoriasByIdPersonal(IdentityPersonal).OrderBy(p => p.strNombreEstudantes)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = tutorias,
                sEcho = param.sEcho,
                iTotalDisplayRecords = tutorias.Count(),
                iTotalRecords = tutorias.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTutoriaDelete(int _idTutoria)
        {
            TutoriasDomainModel tutoriasDM = new TutoriasDomainModel();

            tutoriasDM = tutoriasBusiness.GetTutoriaById(_idTutoria);

            if (tutoriasDM != null)
            {
                TutoriasVM tutoriasVM = new TutoriasVM();

                AutoMapper.Mapper.Map(tutoriasDM,tutoriasVM);

                return PartialView("_Eliminar",tutoriasVM);
            }

            return PartialView();
        }

        [HttpPost]
        public ActionResult DeleteTutoria(TutoriasVM tutoriasVM)
        {
            TutoriasDomainModel tutoriasDM = new TutoriasDomainModel();

            tutoriasDM = tutoriasBusiness.GetTutoriaById(tutoriasVM.id);

            if (tutoriasDM != null)
            {
 
                tutoriasBusiness.DeleteTutoria(tutoriasDM.id);

            }

            return RedirectToAction("Create","Tutorias");
        }

        [HttpGet]
        public ActionResult GetTutoriaUpdate(int _idTutoria)
        {
            TutoriasDomainModel tutoriasDM = new TutoriasDomainModel();

            tutoriasDM = tutoriasBusiness.GetTutoriaById(_idTutoria);

            if (tutoriasDM != null)
            {
                TutoriasVM tutoriasVM = new TutoriasVM();

                AutoMapper.Mapper.Map(tutoriasDM, tutoriasVM);
                ViewBag.idProgramaEductivo = new SelectList(programaEducativoBusiness.GetProgramasEducativos(), "idProgramaEducativo", "strDescripcion");
                ViewBag.strTipo = new SelectList(list.FillTipoTutoria());
                ViewBag.strEstadoTutoria = new SelectList(list.FillEstadoTutoria());
                return PartialView("_Editar", tutoriasVM);
            }

            return PartialView();
        }

        [HttpPost]
        public ActionResult UpdateTutoria(TutoriasVM tutoriasVM)
        {

            if (tutoriasVM.id > 0)
            {
                TutoriasDomainModel tutoriasDM = new TutoriasDomainModel();

                AutoMapper.Mapper.Map(tutoriasVM,tutoriasDM);

                tutoriasBusiness.AddUpdateTutorias(tutoriasDM);

            }

            return RedirectToAction("Create","Tutorias");
        }

    }
}