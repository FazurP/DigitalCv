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
        List list = new List();

        public ProductividadInnovadoraController(IUnitOfWork _unitOfWork,IPaisBusiness _paisBusiness,IProductividadInnovadoraBusiness
            _productividadInnovadoraBusiness, IDocumentosBusiness _documentosBusiness)
        {
            unitofWork = _unitOfWork;
            paisBusiness = _paisBusiness;
            productividadInnovadoraBusiness = _productividadInnovadoraBusiness;
            documentosBusiness = _documentosBusiness;
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

                string nombre = SessionPersister.AccountSession.NombreCompleto;
                int idPersonal = SessionPersister.AccountSession.IdPersonal;

                productividadInnovadoraVM.idPersonal = idPersonal;

                AutoMapper.Mapper.Map(productividadInnovadoraVM, productividadInnovadoraDM);

                object[] obj = CrearDocumentoPersonales(productividadInnovadoraVM);

                if (obj[0].Equals(true))
                {
                    productividadInnovadoraDM.documento = new DocumentosDomainModel { StrUrl = obj[1].ToString()};
                    productividadInnovadoraBusiness.AddUpdateProductividadInnovador(productividadInnovadoraDM);
                }
            }
            return RedirectToAction("Create","ProductividadInnovadora");
        }


        public Object[] CrearDocumentoPersonales(ProductividadInnovadoraVM productividadInnovadoraVM)
        {
            Object[] respuesta = new Object[2];
            productividadInnovadoraVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombrecompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombrecompleto));

            if (Directory.Exists(path))
            {
                if (productividadInnovadoraVM.documento.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path, productividadInnovadoraVM.documento);
                }
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDocumentoPersonales(productividadInnovadoraVM);
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
                string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + productividadInnovadoraDM.documento.StrUrl);

                if (FileManager.FileManager.DeleteFileFromServer(url))
                {
                    documentosBusiness.DeleteDocumento(productividadInnovadoraDM.idDocumento);
                }              
            }

            return RedirectToAction("Create","ProductivadInnovadora");
        }

        [HttpGet]
        public ActionResult GetProductividadUpdate(int _idProductividad)
        {
            ProductividadInnovadoraVM productividadInnovadoraVM = new ProductividadInnovadoraVM();
            ProductividadInnovadoraDomainModel productividadInnovadoraDM = new ProductividadInnovadoraDomainModel();

            productividadInnovadoraDM = productividadInnovadoraBusiness.GetProductividad(_idProductividad);

            if (productividadInnovadoraDM != null)
            {
                AutoMapper.Mapper.Map(productividadInnovadoraDM, productividadInnovadoraVM);
                return PartialView("_Editar", productividadInnovadoraVM);
            }
            return PartialView("_Editar");
        }

        [HttpPost]
        public ActionResult UpdateProductividad(ProductividadInnovadoraVM productividadInnovadoraVM)
        {
            ProductividadInnovadoraDomainModel productividadInnovadoraDM = new ProductividadInnovadoraDomainModel();
            if (productividadInnovadoraVM.id > 0)
            {
                AutoMapper.Mapper.Map(productividadInnovadoraVM, productividadInnovadoraDM);
                productividadInnovadoraBusiness.AddUpdateProductividadInnovador(productividadInnovadoraDM);
            }
            return RedirectToAction("Create","ProductividadInnovadora");
        }
    }
}