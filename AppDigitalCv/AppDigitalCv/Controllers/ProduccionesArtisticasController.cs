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
        List list = new List();

        public ProduccionesArtisticasController(IUnitOfWork _unitOfWork, IPaisBusiness _paisBusiness, IProduccionesArtisticasBusiness
            _produccionesArtisticasBusiness, IDocumentosBusiness _documentosBusiness, IProduccionArtistica _produccionArtistica)
        {
            unitofWork = _unitOfWork;
            paisBusiness = _paisBusiness;
            produccionesArtisticasBusiness = _produccionesArtisticasBusiness;
            documentosBusiness = _documentosBusiness;
            produccionArtistica = _produccionArtistica;
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

                int idPersonal = SessionPersister.AccountSession.IdPersonal;

                produccionesArtisticasVM.idPersonal = idPersonal;

                AutoMapper.Mapper.Map(produccionesArtisticasVM, produccionesArtisticasDM);

                object[] obj = CrearDocumentoPersonales(produccionesArtisticasVM);

                if (obj[0].Equals(true))
                {
                    produccionesArtisticasDM.documentos = new DocumentosDomainModel { StrUrl = obj[1].ToString() };
                    produccionesArtisticasBusiness.AddUpdateProduccionesArtisticas(produccionesArtisticasDM);
                }
            }
            return RedirectToAction("Create", "ProduccionesArtisticas");
        }

        private Object[] CrearDocumentoPersonales(ProduccionesArtisticasVM produccionesArtisticasVM)
        {
            Object[] respuesta = new Object[2];
            produccionesArtisticasVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (produccionesArtisticasVM.documentos.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, produccionesArtisticasVM.documentos);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(produccionesArtisticasVM);
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
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + produccionesArtisticasDM.documentos.StrUrl);
                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(produccionesArtisticasDM.idDocumento);
                }
              
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