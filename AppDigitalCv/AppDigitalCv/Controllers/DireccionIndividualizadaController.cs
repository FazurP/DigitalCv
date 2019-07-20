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
    public class DireccionIndividualizadaController : Controller
    {
        IInstitucionSuperiorBusiness institucionSuperior;
        ITipoEstudioBusiness tipoEstudioBusiness;
        IDireccionIndividualizadaBusiness direccionIndividualizadaBusiness;
        IProgresoProdep progresoProdep;
        List list = new List();

        public DireccionIndividualizadaController(IInstitucionSuperiorBusiness _institucionSuperiorBusiness, ITipoEstudioBusiness _tipoEstudioBusiness,
            IDireccionIndividualizadaBusiness _direccionIndividualizadaBusiness, IProgresoProdep _progresoProdep)
        {
            institucionSuperior = _institucionSuperiorBusiness;
            tipoEstudioBusiness = _tipoEstudioBusiness;
            direccionIndividualizadaBusiness = _direccionIndividualizadaBusiness;
            progresoProdep = _progresoProdep;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idTipoEstudio = new SelectList(tipoEstudioBusiness.GetTiposEstudios(), "idTipoEstudio", "strDescripcion");
                ViewBag.strEstadoDireccionIndividualizada = new SelectList(list.FillEstadoDireccionIndividualizada());
                ViewBag.idInstitucionSuperior = new SelectList(institucionSuperior.GetInstitucionSuperior(), "idInstitucionSuperior", "strDescripcion");
                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
           
        }

        [HttpPost]
        public ActionResult Create(DireccionIndividualizadaVM direccionIndividualizadaVM)
        {
            if (ModelState.IsValid)
            {
                this.AddUpdateDireccionIndividualizada(direccionIndividualizadaVM);
            }

            return RedirectToAction("Create","DireccionIndividualizada");
        }

        public bool AddUpdateDireccionIndividualizada(DireccionIndividualizadaVM direccionIndividualizadaVM)
        {
            bool respuesta = false;
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_DIRECCION_INDIVIDUALIZADA);

            direccionIndividualizadaVM.idPersonal = idPersonal;
            direccionIndividualizadaVM.idStatus = idStatus;

            DireccionIndividualizadaDomainModel direccionIndividualizadaDM = new DireccionIndividualizadaDomainModel();
            ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

            progresoProdepDM.idPersonal = idPersonal;
            progresoProdepDM.idStatus = idStatus;

            AutoMapper.Mapper.Map(direccionIndividualizadaVM,direccionIndividualizadaDM);
            direccionIndividualizadaBusiness.AddUpdateDireccionIndividualizada(direccionIndividualizadaDM);
            progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
            respuesta = true;


            return respuesta;

        }

        [HttpGet]
        public JsonResult GetDirecciones(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<DireccionIndividualizadaDomainModel> DireccionesDM = new List<DireccionIndividualizadaDomainModel>();

            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                DireccionesDM = direccionIndividualizadaBusiness.GetDireccionesByIdPersonal(identityPersonal).Where(p => p.strTituloTesis.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = direccionIndividualizadaBusiness.GetDireccionesByIdPersonal(identityPersonal).Count();

                DireccionesDM = direccionIndividualizadaBusiness.GetDireccionesByIdPersonal(identityPersonal).OrderBy(p => p.strTituloTesis).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {

                aaData = DireccionesDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = DireccionesDM.Count(),
                iTotalRecords = DireccionesDM.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDireccionDelete(int _idDireccion)
        {
            DireccionIndividualizadaVM direccionIndividualizadaVM = new DireccionIndividualizadaVM();
            DireccionIndividualizadaDomainModel direccionIndividualizadaDM = new DireccionIndividualizadaDomainModel();

            direccionIndividualizadaDM = direccionIndividualizadaBusiness.GetDireccionById(_idDireccion);

            if (direccionIndividualizadaDM != null)
            {
                AutoMapper.Mapper.Map(direccionIndividualizadaDM,direccionIndividualizadaVM);
                return PartialView("_Eliminar", direccionIndividualizadaVM);
            }

            return PartialView();
        }

        [HttpPost]
        public ActionResult DeleteDireccion(DireccionIndividualizadaVM direccionIndividualizadaVM)
        {
            DireccionIndividualizadaDomainModel direccionIndividualizadaDM = new DireccionIndividualizadaDomainModel();

            direccionIndividualizadaDM = direccionIndividualizadaBusiness.GetDireccionById(direccionIndividualizadaVM.id);

            if (direccionIndividualizadaDM != null)
            {
                if (direccionIndividualizadaBusiness.GetDireccionesByIdPersonal(SessionPersister.AccountSession.IdPersonal).Count == 1)
                {
                    direccionIndividualizadaBusiness.DeleteDireccion(direccionIndividualizadaDM.id);
                    ProgresoProdepDomainModel progresoProdepDM = progresoProdep.GetProgresoPersonal(SessionPersister.AccountSession.IdPersonal,
                        int.Parse(Recursos.RecursosSistema.REGISTRO_DIRECCION_INDIVIDUALIZADA));
                    progresoProdep.DeleteProgresoProdep(progresoProdepDM.id);
                }
                direccionIndividualizadaBusiness.DeleteDireccion(direccionIndividualizadaDM.id);
            }
            return RedirectToAction("Create","DireccionIndividualizada");

        }

        [HttpGet]
        public ActionResult GetDireccionUpdate(int _idDireccion)
        {
            DireccionIndividualizadaVM direccionIndividualizadaVM = new DireccionIndividualizadaVM();
            DireccionIndividualizadaDomainModel direccionIndividualizadaDM = new DireccionIndividualizadaDomainModel();

            direccionIndividualizadaDM = direccionIndividualizadaBusiness.GetDireccionById(_idDireccion);

            if (direccionIndividualizadaDM != null)
            {
                AutoMapper.Mapper.Map(direccionIndividualizadaDM, direccionIndividualizadaVM);
                return PartialView("_Editar", direccionIndividualizadaVM);
            }

            return PartialView();
        }

        [HttpPost]
        public ActionResult UpdateDireccion(DireccionIndividualizadaVM direccionIndividualizadaVM)
        {
            DireccionIndividualizadaDomainModel direccionIndividualizadaDM = new DireccionIndividualizadaDomainModel();

            if (direccionIndividualizadaVM.id > 0)
            {
                AutoMapper.Mapper.Map(direccionIndividualizadaVM,direccionIndividualizadaDM);
                direccionIndividualizadaBusiness.AddUpdateDireccionIndividualizada(direccionIndividualizadaDM);
            }
            return RedirectToAction("Create","DireccionIndividualizada");
        }

    }
}