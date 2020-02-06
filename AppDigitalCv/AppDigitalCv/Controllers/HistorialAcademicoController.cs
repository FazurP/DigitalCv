using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class HistorialAcademicoController : Controller
    {

        IInstitucionAcreditaDoctoradoBusiness institucionAcreditaDoctorado;
        IInstitucionAcreditaLicenciaturaBusiness institucionAcreditaLicenciaturaBusiness;
        IStatusDoctoradoBusiness statusDoctorado;
        IFuenteFinaciamientoDoctoradoBusiness fuenteFinaciamientoDoctoradoBusiness;
        IDoctoradoBusiness doctoradoBusiness;
        IInstitucionAcreditaMaestriaBusiness institucionAcredita;
        IStatusMaestriaBusiness statusMaestria;
        IFuenteFinanciamientoMaestriaBusiness fuenteFinanciamiento;
        IMaestriaBusiness maestriaBusiness;
        ILicenciaturaIngBusiness licenciaturaIngBusiness;
        IBachilleratoBusiness bachilleratoBusiness;
        IHistorialAcademicoBusiness HistorialAcademicoBusiness;
        IDocumentosBusiness documentosBusiness;

        public HistorialAcademicoController(IInstitucionAcreditaDoctoradoBusiness _institucionAcreditaDoctorado,
            IInstitucionAcreditaLicenciaturaBusiness _institucionAcreditaLicenciaturaBusiness,
            IStatusDoctoradoBusiness _statusDoctorado,
            IFuenteFinaciamientoDoctoradoBusiness _fuenteFinaciamientoDoctoradoBusiness,
            IDoctoradoBusiness _doctoradoBusiness,
            IInstitucionAcreditaMaestriaBusiness _institucionAcredita,
            IStatusMaestriaBusiness _statusMaestria,
            IFuenteFinanciamientoMaestriaBusiness _fuenteFinanciamiento,
            IMaestriaBusiness _maestriaBusiness,
            ILicenciaturaIngBusiness _licenciaturaIngBusiness,
            IBachilleratoBusiness _bachilleratoBusiness,
            IHistorialAcademicoBusiness _historialAcademicoBusiness,
            IDocumentosBusiness _documentosBusiness
            )
        {
            institucionAcreditaDoctorado = _institucionAcreditaDoctorado;
            institucionAcreditaLicenciaturaBusiness = _institucionAcreditaLicenciaturaBusiness;
            statusDoctorado = _statusDoctorado;
            fuenteFinaciamientoDoctoradoBusiness = _fuenteFinaciamientoDoctoradoBusiness;
            doctoradoBusiness = _doctoradoBusiness;
            institucionAcredita = _institucionAcredita;
            statusMaestria = _statusMaestria;
            fuenteFinanciamiento = _fuenteFinanciamiento;
            maestriaBusiness = _maestriaBusiness;
            licenciaturaIngBusiness = _licenciaturaIngBusiness;
            bachilleratoBusiness = _bachilleratoBusiness;
            HistorialAcademicoBusiness = _historialAcademicoBusiness;
            documentosBusiness = _documentosBusiness;
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
                return RedirectToAction("Login","Seguridad");
            }
            
        }

        [HttpPost]
        public ActionResult Create(HistorialAcademicoVM historialAcademicoVM) 
        {
            Object[] obj = { };

            switch (historialAcademicoVM.Type)
            {             
                case 1:
                    
                    obj = CrearDocumentoPersonales(historialAcademicoVM);

                    if (obj[0].Equals(true))
                    {
                        HistorialAcademicoDomainModel historialAcademicoDM = new HistorialAcademicoDomainModel();
                        AutoMapper.Mapper.Map(historialAcademicoVM, historialAcademicoDM);
                        doctoradoBusiness.AddDoctorado(historialAcademicoDM);
                    }
                   
                    break;
                case 2:
                     obj = CrearDocumentoPersonales(historialAcademicoVM);

                    if (obj[0].Equals(true))
                    {
                        HistorialAcademicoDomainModel historialAcademicoDM = new HistorialAcademicoDomainModel();
                        AutoMapper.Mapper.Map(historialAcademicoVM, historialAcademicoDM);
                        maestriaBusiness.AddMaestria(historialAcademicoDM);
                    }
                    break;
                case 3:
                    obj = CrearDocumentoPersonales(historialAcademicoVM);

                    if (obj[0].Equals(true))
                    {
                        HistorialAcademicoDomainModel historialAcademicoDM = new HistorialAcademicoDomainModel();
                        AutoMapper.Mapper.Map(historialAcademicoVM, historialAcademicoDM);
                        licenciaturaIngBusiness.AddLicenciaturaIng(historialAcademicoDM);
                    }
                    break;
                case 4:
                    obj = CrearDocumentoPersonales(historialAcademicoVM);

                    if (obj[0].Equals(true))
                    {
                        HistorialAcademicoDomainModel historialAcademicoDM = new HistorialAcademicoDomainModel();
                        AutoMapper.Mapper.Map(historialAcademicoVM, historialAcademicoDM);
                        licenciaturaIngBusiness.AddLicenciaturaIng(historialAcademicoDM);
                    }
                    break;
                case 5:
                    obj = CrearDocumentoPersonales(historialAcademicoVM);

                    if (obj[0].Equals(true))
                    {
                        HistorialAcademicoDomainModel historialAcademicoDM = new HistorialAcademicoDomainModel();
                        AutoMapper.Mapper.Map(historialAcademicoVM, historialAcademicoDM);
                        bachilleratoBusiness.addBachillerato(historialAcademicoDM);
                    }
                    break;
                default:
                    break;
            }
            return RedirectToAction("Create","HistorialAcademico");
        }

        [HttpGet]
        public ActionResult GetInstitucionAcreditanDoctorados()
        {
            List<InstitucionAcreditaDoctoradoDomainModel> institucionAcreditaDoctoradoDomainModels = new List<InstitucionAcreditaDoctoradoDomainModel>();

            institucionAcreditaDoctoradoDomainModels = institucionAcreditaDoctorado.GetAllInstitucionesAcreditanDoctorados();

            List<InstitucionAcreditaDoctoradoVM> institucionAcreditaCapacitacionProfesionalVMs = new List<InstitucionAcreditaDoctoradoVM>();

            AutoMapper.Mapper.Map(institucionAcreditaDoctoradoDomainModels, institucionAcreditaCapacitacionProfesionalVMs);

            ViewBag.InstitucionAcredita = new SelectList(institucionAcreditaCapacitacionProfesionalVMs,"id","strValor");

            return PartialView("_InstitucionesAcreditan");

        }

        [HttpGet]
        public ActionResult GetStatusDoctorados() 
        {
            List<StatusDoctoradoVM> statusDoctoradosVM = new List<StatusDoctoradoVM>();
            List<StatusDoctoradoDomainModel> statusDoctoradosDM = new List<StatusDoctoradoDomainModel>();

            statusDoctoradosDM = statusDoctorado.GetAllStatusDoctorados();

            AutoMapper.Mapper.Map(statusDoctoradosDM,statusDoctoradosVM);

            ViewBag.Status = new SelectList(statusDoctoradosVM, "id", "strValor");

            return PartialView("_StatusDoctorados");
        }

        [HttpGet]
        public ActionResult GetFuentesFinanciamientoDoctorados() 
        {
            List<FuenteFinanciamientoDoctoradoDomainModel> FuenteFinanciamientoDoctoradoDomainModel = new List<FuenteFinanciamientoDoctoradoDomainModel>();
            List<FuenteFinanciamientoDoctoradoVM> FuenteFinanciamientoDoctoradoVM = new List<FuenteFinanciamientoDoctoradoVM>();

            FuenteFinanciamientoDoctoradoDomainModel = fuenteFinaciamientoDoctoradoBusiness.GetAllFuentesFinaciamientosDoctorados();

            AutoMapper.Mapper.Map(FuenteFinanciamientoDoctoradoDomainModel, FuenteFinanciamientoDoctoradoVM);

            ViewBag.FuenteFinaciamiento = new SelectList(FuenteFinanciamientoDoctoradoDomainModel, "id","strValor");

            return PartialView("_FuenteFinaciamientoDoctorado");
        }

        [HttpGet]
        public ActionResult GetInstitucionAcreditanLicenciaturaIng() 
        {
            List<InstitucionAcreditaLicenciaturaDomainModel> institucionAcreditaLicenciaturaDomainModels = new List<InstitucionAcreditaLicenciaturaDomainModel>();
            List<InstitucionAcreditaLicenciaturaVM> institucionAcreditaLicenciaturaVMs = new List<InstitucionAcreditaLicenciaturaVM>();

            institucionAcreditaLicenciaturaDomainModels = institucionAcreditaLicenciaturaBusiness.GetAllInstitucionAcreditanLicenciaturas();

            AutoMapper.Mapper.Map(institucionAcreditaLicenciaturaDomainModels,institucionAcreditaLicenciaturaVMs);

            ViewBag.InstitucionAcreditaLicenciatura = new SelectList(institucionAcreditaLicenciaturaVMs,"id","strValor");

            return PartialView("_InstitucionesAcreditanLicenciatura");
        }

        [HttpGet]
        public ActionResult GetStatusLicenciaturasIng()
        {
            List<StatusLicenciaturaDomainModel> statusLicenciaturaDomainModels = new List<StatusLicenciaturaDomainModel>();
            List<StatusLicenciaturaVM> statusLicenciaturaVMs = new List<StatusLicenciaturaVM>();

            statusLicenciaturaDomainModels = licenciaturaIngBusiness.GetStatusLicenciaturas();

            AutoMapper.Mapper.Map(statusLicenciaturaDomainModels, statusLicenciaturaVMs);

            ViewBag.Status = new SelectList(statusLicenciaturaVMs, "id", "strValor");

            return PartialView("_StatusDoctorados");
        }

      [HttpGet]
        public ActionResult GetInstitucionAcreditanMaestrias()
        {
            List<InstitucionAcreditaMaestriaDomainModel> institucionAcreditaMaestriaDomainModels = new List<InstitucionAcreditaMaestriaDomainModel>();

            institucionAcreditaMaestriaDomainModels = institucionAcredita.GetAllInstitucionesAcreditanMaestria();

            List<InstitucionAcreditaMaestriaVM> institucionAcreditaMaestriaVMs = new List<InstitucionAcreditaMaestriaVM>();

            AutoMapper.Mapper.Map(institucionAcreditaMaestriaDomainModels, institucionAcreditaMaestriaVMs);

            ViewBag.InstitucionAcredita = new SelectList(institucionAcreditaMaestriaVMs, "id", "strValor");
            return PartialView("_InstitucionesAcreditan");
        }

        [HttpGet]
        public ActionResult GetStatusMaestrias()
        {
            List<StatusMaestriaVM> statusMaestriasVM = new List<StatusMaestriaVM>();
            List<StatusMaestriaDomainModel> statusMaestriasDM = new List<StatusMaestriaDomainModel>();

            statusMaestriasDM = statusMaestria.GetAllStatusMaestrias();

            AutoMapper.Mapper.Map(statusMaestriasDM, statusMaestriasVM);

            ViewBag.Status = new SelectList(statusMaestriasVM, "id", "strValor");

            return PartialView("_StatusDoctorados");
        }

        [HttpGet]
        public ActionResult GetFuentesFinanciamientoMaestrias()
        {
            List<FuenteFinaciamientoMaestriaDomainModel> fuenteFinaciamientoMaestriaDomainModels = new List<FuenteFinaciamientoMaestriaDomainModel>();
            List<FuenteFinaciamientoMaestriaVM> fuenteFinaciamientoMaestriaVMs = new List<FuenteFinaciamientoMaestriaVM>();

            fuenteFinaciamientoMaestriaDomainModels = fuenteFinanciamiento.GetAllFuentesFinanciamientosMaestria();

            AutoMapper.Mapper.Map(fuenteFinaciamientoMaestriaDomainModels, fuenteFinaciamientoMaestriaVMs);

            ViewBag.FuenteFinaciamiento = new SelectList(fuenteFinaciamientoMaestriaVMs, "id", "strValor");

            return PartialView("_FuenteFinaciamientoDoctorado");
        }

        public Object[] CrearDocumentoPersonales(HistorialAcademicoVM historialAcademicoVM)
        {
            Object[] respuesta = new Object[2];
            historialAcademicoVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (historialAcademicoVM.Documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, historialAcademicoVM.Documentos);
                }
            }
            else
            {
                Directory.CreateDirectory(path);
                CrearDocumentoPersonales(historialAcademicoVM);
            }

            return respuesta;
        }

        [HttpGet]
        public JsonResult GetDoctorados(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<DoctoradoDomainModel> historialAcademicoDomainModels = new List<DoctoradoDomainModel>();


            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                historialAcademicoDomainModels = doctoradoBusiness.GetDoctorados(identityPersonal).Where(p => p.strNombre.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = doctoradoBusiness.GetDoctorados(identityPersonal).Count();

                historialAcademicoDomainModels = doctoradoBusiness.GetDoctorados(identityPersonal).OrderBy(p => p.strNombre).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {
                aaData = historialAcademicoDomainModels,
                sEcho = param.sEcho,
                iTotalDisplayRecords = historialAcademicoDomainModels.Count(),
                iTotalRecords = historialAcademicoDomainModels.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMaestrias(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<MaestriaDomainModel> historialAcademicoDomainModels = new List<MaestriaDomainModel>();


            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                historialAcademicoDomainModels = maestriaBusiness.GetMaestrias(identityPersonal).Where(p => p.strNombre.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = maestriaBusiness.GetMaestrias(identityPersonal).Count();

                historialAcademicoDomainModels = maestriaBusiness.GetMaestrias(identityPersonal).OrderBy(p => p.strNombre).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {
                aaData = historialAcademicoDomainModels,
                sEcho = param.sEcho,
                iTotalDisplayRecords = historialAcademicoDomainModels.Count(),
                iTotalRecords = historialAcademicoDomainModels.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetLicenciaturasIng(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<LicenciaturaIngenieriaDomainModel> historialAcademicoDomainModels = new List<LicenciaturaIngenieriaDomainModel>();


            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                historialAcademicoDomainModels = licenciaturaIngBusiness.GetLicenciaturasIngs(identityPersonal).Where(p => p.strNombre.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = licenciaturaIngBusiness.GetLicenciaturasIngs(identityPersonal).Count();

                historialAcademicoDomainModels = licenciaturaIngBusiness.GetLicenciaturasIngs(identityPersonal).OrderBy(p => p.strNombre).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {
                aaData = historialAcademicoDomainModels,
                sEcho = param.sEcho,
                iTotalDisplayRecords = historialAcademicoDomainModels.Count(),
                iTotalRecords = historialAcademicoDomainModels.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetBachilleratos(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<BachilleratoDomainModel> historialAcademicoDomainModels = new List<BachilleratoDomainModel>();


            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                historialAcademicoDomainModels = bachilleratoBusiness.GetBachillerato(identityPersonal).Where(p => p.strNombre.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = bachilleratoBusiness.GetBachillerato(identityPersonal).Count();

                historialAcademicoDomainModels = bachilleratoBusiness.GetBachillerato(identityPersonal).OrderBy(p => p.strNombre).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {
                aaData = historialAcademicoDomainModels,
                sEcho = param.sEcho,
                iTotalDisplayRecords = historialAcademicoDomainModels.Count(),
                iTotalRecords = historialAcademicoDomainModels.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DeleteHistorialAcademico(int _idHistorial, int _idType)
        {
            HistorialAcademicoVM historialAcademicoVM = new HistorialAcademicoVM();
            switch (_idType)
            {
                case 1:
                    DoctoradoDomainModel doctoradoDomainModel = doctoradoBusiness.GetDoctorado(_idHistorial);
                    historialAcademicoVM.Doctorado = new DoctoradoVM();
                    AutoMapper.Mapper.Map(doctoradoDomainModel, historialAcademicoVM.Doctorado);
                    historialAcademicoVM.Type = 1;
                    break;
                case 2:
                    MaestriaDomainModel maestriaDomainModel = maestriaBusiness.GetMaestria(_idHistorial);
                    historialAcademicoVM.Maestria = new MaestriaVM();
                    AutoMapper.Mapper.Map(maestriaDomainModel,historialAcademicoVM.Maestria);
                    historialAcademicoVM.Type = 2;
                    break;
                case 3:
                    LicenciaturaIngenieriaDomainModel licenciaturaIngenieriaDomainModel = licenciaturaIngBusiness.GetLicenciaturaIng(_idHistorial);
                    historialAcademicoVM.LicenciaturaIngenieria = new LicenciaturaIngenieriaVM();
                    AutoMapper.Mapper.Map(licenciaturaIngenieriaDomainModel,historialAcademicoVM.LicenciaturaIngenieria);
                    historialAcademicoVM.Type = 3;
                    break;
                case 4:
                    BachilleratoDomainModel bachilleratoDomainModel = bachilleratoBusiness.GetBachilleratos(_idHistorial);
                    historialAcademicoVM.Bachillerato = new BachilleratoVM();
                    AutoMapper.Mapper.Map(bachilleratoDomainModel,historialAcademicoVM.Bachillerato);
                    historialAcademicoVM.Type = 4;
                    break;
                default:
                    break;
            }

            return PartialView("_Eliminar", historialAcademicoVM);
        }

        [HttpPost]
        public ActionResult Delete(HistorialAcademicoVM historialAcademicoVM)
        {
            HistorialAcademicoDomainModel historialAcademicoDomainModel = new HistorialAcademicoDomainModel();
            string url;
            switch (historialAcademicoVM.Type)
            {
                case 1:
                   
                    historialAcademicoDomainModel.Doctorado = new DoctoradoDomainModel();

                    historialAcademicoDomainModel.Doctorado = doctoradoBusiness.GetDoctorado(historialAcademicoVM.Doctorado.id);

                    url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + historialAcademicoDomainModel.Doctorado.Documentos.StrUrl);

                    if (FileManager.FileManager.DeleteFileFromServer(url))
                    {
                        doctoradoBusiness.DeleteDoctorado(historialAcademicoDomainModel);
                    }
                    break;
                case 2:

                    historialAcademicoDomainModel.Maestria = new MaestriaDomainModel();
                    historialAcademicoDomainModel.Maestria = maestriaBusiness.GetMaestria(historialAcademicoVM.Maestria.id);
                    url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + historialAcademicoDomainModel.Maestria.Documentos.StrUrl);

                    if (FileManager.FileManager.DeleteFileFromServer(url))
                    {
                        maestriaBusiness.DeleteMaestria(historialAcademicoDomainModel);
                    }
                    break;
                case 3:

                    historialAcademicoDomainModel.LicenciaturaIngenieria = new LicenciaturaIngenieriaDomainModel();
                    historialAcademicoDomainModel.LicenciaturaIngenieria = licenciaturaIngBusiness.GetLicenciaturaIng(historialAcademicoVM.LicenciaturaIngenieria.id);
                    url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + historialAcademicoDomainModel.LicenciaturaIngenieria.Documentos.StrUrl);

                    if (FileManager.FileManager.DeleteFileFromServer(url))
                    {
                        licenciaturaIngBusiness.DeleteLicenciarturaIng(historialAcademicoDomainModel);
                    }
                    break;
                case 4:

                    historialAcademicoDomainModel.Bachillerato = new BachilleratoDomainModel();
                    historialAcademicoDomainModel.Bachillerato = bachilleratoBusiness.GetBachilleratos(historialAcademicoVM.Bachillerato.id);
                    url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + historialAcademicoDomainModel.Bachillerato.Documentos.StrUrl);

                    if (FileManager.FileManager.DeleteFileFromServer(url))
                    {
                        if (documentosBusiness.DeleteDocumento(historialAcademicoDomainModel.Bachillerato.idDocumento))
                        {
                            bachilleratoBusiness.DeleteBachillerato(historialAcademicoDomainModel);
                        }
                    }

                    break;
                default:
                    break;
            }

            return RedirectToAction("Create","HistorialAcademico");
        }
    }
}