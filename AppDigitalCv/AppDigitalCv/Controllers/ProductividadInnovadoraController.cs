using AppDigitalCv.Business.Interface;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using AppDigitalCv.Domain;
using System.IO;
using AppDigitalCv.Business.Enum;
using AppDigitalCv.Models;

namespace AppDigitalCv.Controllers
{
    public class ProductividadInnovadoraController : Controller
    {
        IUnitOfWork unitofWork;
        IPaisBusiness paisBusiness;
        IProductividadInnovadoraBusiness productividadInnovadoraBusiness;
        IDocumentosBusiness documentosBusiness;
        IProgresoProdep progresoProdep;
        List list = new List();

        public ProductividadInnovadoraController(IUnitOfWork _unitOfWork,IPaisBusiness _paisBusiness,IProductividadInnovadoraBusiness
            _productividadInnovadoraBusiness, IDocumentosBusiness _documentosBusiness, IProgresoProdep _progresoProdep)
        {
            unitofWork = _unitOfWork;
            paisBusiness = _paisBusiness;
            productividadInnovadoraBusiness = _productividadInnovadoraBusiness;
            documentosBusiness = _documentosBusiness;
            progresoProdep = _progresoProdep;
        }
       
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.strTipoProductividadInnovadora = new SelectList(list.FillTipoProductividadInnovador());
                ViewBag.strClasificacionInternacionalPatentes = new SelectList(list.FillClasificacionInternacional());
                ViewBag.strEstadoActual = new SelectList(list.FillEstado());
                ViewBag.idPais = new SelectList(paisBusiness.GetPais(),"idPais","strValor");
                ViewBag.strProposito = new SelectList(list.FillProposito());

                return View();
            }
            else
            {
                return RedirectToAction("Login","Seguridad");
            }
            
        }
        [HttpPost]
        public ActionResult Create(ProductividadInnovadoraVM productividadInnovadoraVM)
        {
            if (ModelState.IsValid)
            {
                ProductividadInnovadoraDomainModel productividadInnovadoraDM = new ProductividadInnovadoraDomainModel();
                DocumentosDomainModel documentosDM = new DocumentosDomainModel();
                ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

                string nombre = SessionPersister.AccountSession.NombreCompleto;
                int idPersonal = SessionPersister.AccountSession.IdPersonal;
                int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_PRODUCTIVIDAD_INNOVADORA);

                productividadInnovadoraVM.idPersonal = idPersonal;
                productividadInnovadoraVM.idStatus = idStatus;

                AutoMapper.Mapper.Map(productividadInnovadoraVM, productividadInnovadoraDM);
                AutoMapper.Mapper.Map(productividadInnovadoraVM.documentoVM, documentosDM);
                productividadInnovadoraDM.documentosDomainModel = documentosDM;

                if (GuadarArchivo(productividadInnovadoraDM, nombre))
                {
                    productividadInnovadoraDM.documentosDomainModel.StrUrl = productividadInnovadoraDM.documentosDomainModel.DocumentoFile.FileName;
                    DocumentosDomainModel documentos = documentosBusiness.AddDocumento(documentosDM);
                    productividadInnovadoraDM.idDocumento = documentos.IdDocumento;
                    productividadInnovadoraBusiness.AddUpdateProductividadInnovador(productividadInnovadoraDM);
                    progresoProdepDM.idPersonal = idPersonal;
                    progresoProdepDM.idStatus = idStatus;
                    progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
                }
                else
                {
                    ViewBag.ErrorArchivo = Recursos.RecursosSistema.ERROR_GUARDADO_ARCHIVO;
                }
            }
            return RedirectToAction("Create","ProductividadInnovadora");
        }

        public bool GuadarArchivo(ProductividadInnovadoraDomainModel productividadInnovadoraDomainModel, string nombre)
        {
            bool respuesta = false;

            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre + "/"));

            if (Directory.Exists(path))
            {
                if (productividadInnovadoraDomainModel.documentosDomainModel.DocumentoFile.ContentType.Equals("application/pdf"))
                {
                    string pahtCompleto = Path.Combine(path, Path.GetFileName(productividadInnovadoraDomainModel.documentosDomainModel.DocumentoFile.FileName));
                    productividadInnovadoraDomainModel.documentosDomainModel.DocumentoFile.SaveAs(pahtCompleto);
                    respuesta = true;
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                GuadarArchivo(productividadInnovadoraDomainModel,nombre);
                respuesta = true;
            }
            return respuesta;
        }
        [HttpGet]
        public JsonResult GetProductividad(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<ProductividadInnovadoraDomainModel> productividadDM = new List<ProductividadInnovadoraDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                productividadDM = productividadInnovadoraBusiness.GetProductividades(IdentityPersonal).Where(p => p.strTitulo.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = productividadInnovadoraBusiness.GetProductividades(IdentityPersonal).Count();


                productividadDM = productividadInnovadoraBusiness.GetProductividades(IdentityPersonal).OrderBy(p => p.strTitulo)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = productividadDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = productividadDM.Count(),
                iTotalRecords = productividadDM.Count()

            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetProductividadDelete(int _idProductividad)
        {
            ProductividadInnovadoraVM productividadInnovadoraVM = new ProductividadInnovadoraVM();
            ProductividadInnovadoraDomainModel productividadInnovadoraDM = new ProductividadInnovadoraDomainModel();

            productividadInnovadoraDM = productividadInnovadoraBusiness.GetProductividad(_idProductividad);

            if (productividadInnovadoraDM != null)
            {
                AutoMapper.Mapper.Map(productividadInnovadoraDM, productividadInnovadoraVM);
                return PartialView("_Eliminar", productividadInnovadoraVM);
            }

            return PartialView("_Eliminar");
        }
        [HttpPost]
        public ActionResult DeleteProductividad(ProductividadInnovadoraVM productividadInnovadoraVM)
        {
            ProductividadInnovadoraDomainModel productividadInnovadoraDM = new ProductividadInnovadoraDomainModel();

            productividadInnovadoraDM = productividadInnovadoraBusiness.GetProductividad(productividadInnovadoraVM.id);

            if (productividadInnovadoraDM !=  null)
            {
                if (productividadInnovadoraBusiness.GetProductividades(SessionPersister.AccountSession.IdPersonal).Count == 1)
                {
                    ProgresoProdepDomainModel progresoProdepDM = progresoProdep.GetProgresoPersonal(SessionPersister.AccountSession.IdPersonal, int.Parse(Recursos.RecursosSistema.REGISTRO_PRODUCTIVIDAD_INNOVADORA));
                    documentosBusiness.DeleteDocumento(productividadInnovadoraDM.idDocumento);
                    progresoProdep.DeleteProgresoProdep(progresoProdepDM.id);
                }
                else
                {
                    documentosBusiness.DeleteDocumento(productividadInnovadoraDM.idDocumento);
                }
            }

            return RedirectToAction("Create","ProductivadInnovadora");
        }
       
    }
}