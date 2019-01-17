using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;

namespace AppDigitalCv.Controllers
{
    public class PremiosDocenteController : Controller
    {
        IPremiosDocenteBusiness IpremiosDocenteBusiness;
        IPersonalBusiness IpersonalBusiness;
        IDocumentosBusiness IdocumentosBusiness;

        public PremiosDocenteController(IPremiosDocenteBusiness _IpremiosDocenteBusiness, IPersonalBusiness _IpersonalBusiness, IDocumentosBusiness _IdocumentosBusiness)
        {
            IpremiosDocenteBusiness = _IpremiosDocenteBusiness;
            IpersonalBusiness = _IpersonalBusiness;
            IdocumentosBusiness = _IdocumentosBusiness;
        }

        // GET: PremiosDocente
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(PremiosDocenteVM premiosDocenteVM)
        {
            premiosDocenteVM.IdPersonal = Security.SessionPersister.AccountSession.IdPersonal;
            if (ModelState.IsValid)
            {
                this.CrearDocumentoPremioDocente(premiosDocenteVM);
            }

            return View();
        }

        #region  Crear el documento
        public void CrearDocumentoPremioDocente(PremiosDocenteVM premiosDocenteVM)
        {
            PersonalDomainModel personalDM= this.GetPersonalVM(premiosDocenteVM.IdPersonal);
            premiosDocenteVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombreCompleto = personalDM.Nombre + " " + personalDM.ApellidoPaterno + " " + personalDM.ApellidoMaterno;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO+ nombreCompleto));


            if (!Directory.Exists(path))
            {
                //creamos el directorio
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombreCompleto + "/"), Path.GetFileName(premiosDocenteVM.DocumentosVM.DocumentoFile.FileName));
                premiosDocenteVM.DocumentosVM.DocumentoFile.SaveAs(path);
                DocumentosVM documentoVM = new DocumentosVM();
                documentoVM.StrUrl = path;
                premiosDocenteVM.DocumentosVM = documentoVM;
                this.AddEditPremiosDocente(premiosDocenteVM);

            }
            else
            {
                path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombreCompleto + "/"), Path.GetFileName(premiosDocenteVM.DocumentosVM.DocumentoFile.FileName));
                premiosDocenteVM.DocumentosVM.DocumentoFile.SaveAs(path);
                DocumentosVM documentoVM = new DocumentosVM();
                documentoVM.StrUrl = path;
                premiosDocenteVM.DocumentosVM = documentoVM;
                this.AddEditPremiosDocente(premiosDocenteVM);
            }
        }

        #endregion

        #region  Agregar Premios del Docente
        public bool AddEditPremiosDocente(PremiosDocenteVM premiosDocenteVM)
        {
            bool resultado = false;
            PremiosDocenteDomainModel premiosDocenteDM = new PremiosDocenteDomainModel();
            DocumentosDomainModel documentosDomainModel = new DocumentosDomainModel();
            AutoMapper.Mapper.Map(premiosDocenteVM, premiosDocenteDM);///hacemos el mapeado de la entidad
            AutoMapper.Mapper.Map(premiosDocenteVM.DocumentosVM, documentosDomainModel);
            premiosDocenteDM.DocumentosDomainModel = documentosDomainModel;

            DocumentosDomainModel documento =IdocumentosBusiness.AddDocumento(documentosDomainModel);
            premiosDocenteDM.IdDocumento = documento.IdDocumento;
             resultado = IpremiosDocenteBusiness.AddPremiosDocente(premiosDocenteDM);
            return resultado;
        }
        #endregion

        #region Consultar Datos del Personal Docente
        public PersonalDomainModel GetPersonalVM(int idPersonal)
        {
            PersonalDomainModel personalDM = IpersonalBusiness.GetPersonalById(idPersonal);
            return personalDM;
        }
        #endregion

    }
}