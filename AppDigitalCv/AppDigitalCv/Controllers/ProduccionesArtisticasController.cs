using AppDigitalCv.Business.Enum;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Repository.Infraestructure.Contract;
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
    public class ProduccionesArtisticasController : Controller
    {
        IUnitOfWork unitofWork;
        IPaisBusiness paisBusiness;
        IProduccionesArtisticasBusiness produccionesArtisticasBusiness;
        IProduccionArtistica produccionArtistica;
        IDocumentosBusiness documentosBusiness;
        IProgresoProdep progresoProdep;
        List list = new List();

        public ProduccionesArtisticasController(IUnitOfWork _unitOfWork, IPaisBusiness _paisBusiness, IProduccionesArtisticasBusiness
            _produccionesArtisticasBusiness, IDocumentosBusiness _documentosBusiness, IProduccionArtistica _produccionArtistica,
            IProgresoProdep _progresoProdep)
        {
            unitofWork = _unitOfWork;
            paisBusiness = _paisBusiness;
            produccionesArtisticasBusiness = _produccionesArtisticasBusiness;
            documentosBusiness = _documentosBusiness;
            produccionArtistica = _produccionArtistica;
            progresoProdep = _progresoProdep;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.IdPais = new SelectList(paisBusiness.GetPais(), "idPais", "strValor");
                ViewBag.idProduccionesArtisticas = new SelectList(produccionArtistica.GetProduccionesArtisticas(), "id", "strDescripcion");
                ViewBag.strProposito = new SelectList(list.FillProposito());
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Seguridad");
            }

        }

        [HttpPost]
        public ActionResult Create(ProduccionesArtisticasVM produccionesArtisticasVM)
        {
            if (ModelState.IsValid)
            {
                ProduccionesArtisticasDomainModel produccionesArtisticasDM = new ProduccionesArtisticasDomainModel();
                DocumentosDomainModel documentosDM = new DocumentosDomainModel();
                ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

                string nombre = SessionPersister.AccountSession.NombreCompleto;
                int idPersonal = SessionPersister.AccountSession.IdPersonal;
                int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_PRODUCCIONES_ARTISTICAS);

                produccionesArtisticasVM.idPersonal = idPersonal;
                produccionesArtisticasVM.idStatus = idStatus;

                AutoMapper.Mapper.Map(produccionesArtisticasVM, produccionesArtisticasDM);
                AutoMapper.Mapper.Map(produccionesArtisticasVM.documentosVM, documentosDM);
                produccionesArtisticasDM.documentosDM = documentosDM;

                if (GuadarArchivo(produccionesArtisticasDM, nombre))
                {
                    produccionesArtisticasDM.documentosDM.StrUrl = produccionesArtisticasDM.documentosDM.DocumentoFile.FileName;
                    DocumentosDomainModel documentos = documentosBusiness.AddDocumento(documentosDM);
                    produccionesArtisticasDM.idDocumento = documentos.IdDocumento;
                    produccionesArtisticasBusiness.AddUpdateProduccionesArtisticas(produccionesArtisticasDM);
                    progresoProdepDM.idPersonal = idPersonal;
                    progresoProdepDM.idStatus = idStatus;
                    progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
                }
            }
            return RedirectToAction("Create", "ProduccionesArtisticas");
        }

        public bool GuadarArchivo(ProduccionesArtisticasDomainModel produccionesArtisticasDomainModel, string nombre)
        {
            bool respuesta = false;

            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre + "/"));

            if (Directory.Exists(path))
            {
                if (produccionesArtisticasDomainModel.documentosDM.DocumentoFile.ContentType.Equals("application/pdf"))
                {
                    string pahtCompleto = Path.Combine(path, Path.GetFileName(produccionesArtisticasDomainModel.documentosDM.DocumentoFile.FileName));
                    produccionesArtisticasDomainModel.documentosDM.DocumentoFile.SaveAs(pahtCompleto);
                    respuesta = true;
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                GuadarArchivo(produccionesArtisticasDomainModel, nombre);
                respuesta = true;
            }
            return respuesta;
        }

        [HttpGet]
        public JsonResult GetParticipacionArtisticas(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<ProduccionesArtisticasDomainModel> produccionesDM = new List<ProduccionesArtisticasDomainModel>();

            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                produccionesDM = produccionesArtisticasBusiness.GetProduccionesArtisticasByPersonal(identityPersonal).Where(p => p.strNombreObra.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = produccionesArtisticasBusiness.GetProduccionesArtisticasByPersonal(identityPersonal).Count();

                produccionesDM = produccionesArtisticasBusiness.GetProduccionesArtisticasByPersonal(identityPersonal).OrderBy(p => p.strNombreObra).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {

                aaData = produccionesDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = produccionesDM.Count(),
                iTotalRecords = produccionesDM.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetProduccionDelete(int _idProduccion)
        {
            ProduccionesArtisticasDomainModel produccionesArtisticasDM = new ProduccionesArtisticasDomainModel();
            ProduccionesArtisticasVM produccionesArtisticasVM = new ProduccionesArtisticasVM();

            produccionesArtisticasDM = produccionesArtisticasBusiness.GetProduccion(_idProduccion);

            if (produccionesArtisticasDM != null)
            {
                AutoMapper.Mapper.Map(produccionesArtisticasDM,produccionesArtisticasVM);
                return PartialView("_Eliminar", produccionesArtisticasVM);
            }

            return PartialView("_Eliminar");
        }

        [HttpPost]
        public ActionResult DeleteProduccion(ProduccionesArtisticasVM produccionesArtisticasVM)
        {
            ProduccionesArtisticasDomainModel produccionesArtisticasDM = new ProduccionesArtisticasDomainModel();

            produccionesArtisticasDM = produccionesArtisticasBusiness.GetProduccion(produccionesArtisticasVM.id);

            if (produccionesArtisticasDM != null)
            {
                if (produccionesArtisticasBusiness.GetProduccionesArtisticasByPersonal(SessionPersister.AccountSession.IdPersonal).Count == 1)
                {
                    ProgresoProdepDomainModel progresoProdepDM = progresoProdep.GetProgresoPersonal(SessionPersister.AccountSession.IdPersonal,int.Parse(Recursos.RecursosSistema.REGISTRO_PRODUCCIONES_ARTISTICAS));
                    documentosBusiness.DeleteDocumento(produccionesArtisticasDM.idDocumento);
                    progresoProdep.DeleteProgresoProdep(progresoProdepDM.id);

                }
                documentosBusiness.DeleteDocumento(produccionesArtisticasDM.idDocumento);
            }

            return RedirectToAction("Create","ProduccionesArtisticas");
        }

        [HttpGet]
        public ActionResult GetProduccionUpdate(int _idProduccion)
        {
            ProduccionesArtisticasDomainModel produccionesArtisticasDM = new ProduccionesArtisticasDomainModel();
            ProduccionesArtisticasVM produccionesArtisticasVM = new ProduccionesArtisticasVM();

            produccionesArtisticasDM = produccionesArtisticasBusiness.GetProduccion(_idProduccion);

            if (produccionesArtisticasDM != null)
            {
                AutoMapper.Mapper.Map(produccionesArtisticasDM, produccionesArtisticasVM);
                return PartialView("_Editar", produccionesArtisticasVM);
            }

            return PartialView("_Editar");
        }

        [HttpPost]
        public ActionResult UpdateProducciones(ProduccionesArtisticasVM produccionesArtisticasVM)
        {
            ProduccionesArtisticasDomainModel produccionesArtisticasDM = new ProduccionesArtisticasDomainModel();

            if (produccionesArtisticasVM.id > 0)
            {
                AutoMapper.Mapper.Map(produccionesArtisticasVM, produccionesArtisticasDM);
                produccionesArtisticasBusiness.AddUpdateProduccionesArtisticas(produccionesArtisticasDM);
            }
            return RedirectToAction("Create","ProduccionesArtisticas");
        }

    }
}