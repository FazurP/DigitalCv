using AppDigitalCv.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System.IO;
//cargamos la seguridad y su persistencia
using AppDigitalCv.Security;

namespace AppDigitalCv.Controllers
{
    public class PersonalController : Controller
    {
        //mandamos llamar al metodo de negocio
        IPersonalBusiness IPersonalBussines;
        IEstadoCivilBusiness estadoCivilBusiness;


        public PersonalController(IPersonalBusiness _PersonalBussiness, IEstadoCivilBusiness _estadoCivilBusiness)
        {

                IPersonalBussines = _PersonalBussiness;
                estadoCivilBusiness = _estadoCivilBusiness;
        }
        
        #region Crear 
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.IdEstadoCivil = new SelectList(estadoCivilBusiness.GetEstadoCivil(), "IdEstadoCivil", "StrDescripcion");



                return View();
            }
            else {
                return View("~/Views/Seguridad/Login.cshtml");
            }
           
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,ApellidoPaterno,ApellidoMaterno,IdEstadoCivil,StrGenero,RFC,Curp,HomoClave,ArchivoRfc,ArchivoCurp,ImageFile,strLogros")] PersonalVM personalVM)
        {
          
            if (ModelState.IsValid)
            {
                if (personalVM.ArchivoCurp != null && personalVM.ArchivoRfc != null && personalVM.ImageFile != null)
                {
                    string nombreCompleto = personalVM.Nombre + " " + personalVM.ApellidoPaterno + " " + personalVM.ApellidoMaterno;
                    this.CrearDirectorioUsuario(personalVM);
                                                           
                }
                return RedirectToAction("Create", "Personal");
            }
            else {
                return RedirectToAction("Create","Personal");
            }
        }

        [HttpPost]
        public ActionResult AgregarTipoSangre([Bind(Include = "idPersonal,idTipoSangre")]PersonalVM personalVM)
        {
            //construimos una lista de personalvm para poder mostrar como un json
            List<TipoSangreVM> tipoSangreVMs = new List<TipoSangreVM>();
            
                this.AddEditTipoSangre(personalVM);
                if (Request.IsAjaxRequest())
                {
                    TipoSangreVM tipoSangreVM = new TipoSangreVM();
                    PersonalDomainModel personalDM= IPersonalBussines.GetPersonalById(personalVM.idPersonal);
                    AutoMapper.Mapper.Map(personalDM.TipoSangreDomainModel, tipoSangreVM);
                    tipoSangreVMs.Add(tipoSangreVM);
                    return Json(tipoSangreVMs, JsonRequestBehavior.AllowGet);
                }
            
            return View();
        }

        [HttpGet]
        public JsonResult ConsultaTipoSangre()
        {
            List<TipoSangreVM> tipoSangreVMs = new List<TipoSangreVM>();
            //PersonalVM personaVM = new PersonalVM();
            PersonalDomainModel personalDM = IPersonalBussines.GetPersonalById(1);
            TipoSangreVM tipoSangreVM = new TipoSangreVM();

            //AutoMapper.Mapper.Map(personalDM, personaVM);
            AutoMapper.Mapper.Map(personalDM.TipoSangreDomainModel, tipoSangreVM);
            tipoSangreVMs.Add(tipoSangreVM);
            return Json(tipoSangreVMs, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region Detalles de la Informacion en Vista
        /// <summary>
        /// Este metodo se encarga de mostrar la información previamente guardada por el usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InfoPersonal()
        {
            if (SessionPersister.AccountSession != null)
            {
                ///este es el id del personal
                int idPersonal = SessionPersister.AccountSession.IdPersonal;
                //creamos el objeto que representara los datos en la vista
                PersonalVM personalVM = new PersonalVM();
                //obtenemos el objeto del modelo de dominio
                PersonalDomainModel personaDominio = IPersonalBussines.GetPersonalById(idPersonal);
                ///mapaeamos el objeto con los valores del modelo de dominio
                AutoMapper.Mapper.Map(personaDominio, personalVM);
                ViewBag.NombreCompleto = personalVM.Nombre + " " + personalVM.ApellidoPaterno + " " + personalVM.ApellidoMaterno;
                //consultamos la fecha desde el servidor
                ViewBag.FechaServidor = this.ConsultarHorarioServidor();
                return View(personalVM);
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
            
        }
        #endregion

        // GET: Personal
        public ActionResult Index()
        {
            List<PersonalDomainModel> personalDM = IPersonalBussines.GetEmpleado();
            //aqui cambaimos al modeldomain al viewmodel
            List<PersonalVM> personalVM = new List<PersonalVM>();
            //cambiamos el objeto
            AutoMapper.Mapper.Map(personalDM,personalVM);
            return View();
        }

        #region Estos metodos y vista seran borrados

        [HttpGet]
        public ActionResult DatosPersonales()
        {
            ViewBag.PersonalList =IPersonalBussines.GetEmpleado();
            return View();
        }

        [HttpPost]
        public ActionResult DatosPersonales(PersonalVM personalVM)
        {
            //mando los datos ya editados del personal.
            this.AddEditPersonal(personalVM);
            return PartialView("_Editar", personalVM);
            
        }

        [HttpGet]
        public ActionResult Editar()
        {

            if (SessionPersister.AccountSession != null)
            {

                int idPersonal = SessionPersister.AccountSession.IdPersonal;
                PersonalDomainModel personalDM = IPersonalBussines.GetPersonalById(idPersonal);
                PersonalVM personalVM = new PersonalVM();
                AutoMapper.Mapper.Map(personalDM, personalVM);///hacemos el mapeado de la entidad

                var personalDocumentos = ConsultarDcocumentosPersonal(); ///mandamos llamar los documentos del personal
                ViewBag.Identificador = personalDocumentos.IdPersonal;
                ViewBag.Curp = personalDocumentos.UrlCurp;
                ViewBag.Rfc = personalDocumentos.UrlRfc;

                return View("Editar"); ///"_Editar",personalVM
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }

        }

       
       
        #endregion

        #region Agregar o Editar una entidad

        public string AddEditPersonal(PersonalVM personalVM)
        {
            string resultado = string.Empty;
            PersonalDomainModel personalDM = new PersonalDomainModel();
            AutoMapper.Mapper.Map(personalVM, personalDM);///hacemos el mapeado de la entidad

            resultado = IPersonalBussines.AddUpdatePersonal(personalDM);
            return resultado;
        }


        public string AddEditTipoSangre(PersonalVM personalVM)
        {
            string resultado = string.Empty;
            PersonalDomainModel personalDM = new PersonalDomainModel();
            AutoMapper.Mapper.Map(personalVM, personalDM);///hacemos el mapeado de la entidad

            resultado = IPersonalBussines.AddUpdateTipoSangre(personalDM);
            return resultado;
        }


        #endregion
          
        #region Eliminar Documentos del Personal

        public JsonResult EliminarCurp(int idPersonal)
        {
            bool resultado= IPersonalBussines.DeleteFileCurp(idPersonal);
            return Json(resultado,JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarRfc(int idPersonal)
        {
            bool resultado = IPersonalBussines.DeleteFileRfc(idPersonal);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Consultar Datos del Personal

        public JsonResult ConsultarDatosPersonal()
        {
            var personal = IPersonalBussines.GetEmpleadoDocumentos(SessionPersister.AccountSession.IdPersonal);////////////////////////modificacion temporal
            return Json(personal, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Consultar Documentos del Personal
        /// <summary>
        /// Este metodo se encarga de consultar los documentos del personal
        /// </summary>
        /// <returns>un json como resultado de la consulta</returns>
        public DocumentoPersonalVM ConsultarDcocumentosPersonal()
        {
            DocumentoPersonalDomainModel documentosDM = IPersonalBussines.GetDocumentoPersonal(SessionPersister.AccountSession.IdPersonal);
            DocumentoPersonalVM documentosVM = new DocumentoPersonalVM();
            AutoMapper.Mapper.Map(documentosDM, documentosVM);
            return documentosVM;
        }
        #endregion


        public ActionResult borrarPersonal(int _idPersonal)
        {
            // bool resultado = IPersonalBussines.DeletePersonal(_idPersonal);
            // return Json(resultado,JsonRequestBehavior.AllowGet);
            return View();
        }

        #region Subir Imagen
        public JsonResult ImageUpload(PersonalVM modelo)
        {
            var file = modelo.ImageFile;
            if (file != null)
            {
                //obtenemos el nombre del archivo
                var fileName = Path.GetFileName(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileNameSinExtension = Path.GetFileNameWithoutExtension(file.FileName);
                file.SaveAs(Server.MapPath("/Imagenes/" + file.FileName));
                
            }
            return Json(file.FileName,JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Crear Directorio de Usuario
        //string nombreCompleto ,HttpPostedFileWrapper curpFile, HttpPostedFileWrapper rfcFile, HttpPostedFileWrapper imageFile,
        public void CrearDirectorioUsuario(PersonalVM personalVM)
        {
            string nombreCompleto = personalVM.Nombre + " " + personalVM.ApellidoPaterno + " " + personalVM.ApellidoMaterno;///falta agregar el id del personal para asegurar que no se repitan las carpetas
            string path = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/"+nombreCompleto));
            string pathRfc = string.Empty;
            string pathCurp = string.Empty;

            if (!Directory.Exists(path))
            {
                //creamos el directorio
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                path = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/"+nombreCompleto+"/"), Path.GetFileName(personalVM.ImageFile.FileName));
                pathRfc = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + "/"), Path.GetFileName(personalVM.ArchivoRfc.FileName));
                pathCurp = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + "/"), Path.GetFileName(personalVM.ArchivoCurp.FileName));

                personalVM.ImageFile.SaveAs(path);
                personalVM.ArchivoRfc.SaveAs(pathRfc);
                personalVM.ArchivoCurp.SaveAs(pathCurp);

                personalVM.strUrlFoto = path;
                personalVM.strUrlRfc = pathRfc;
                personalVM.strUrlCurp = pathCurp;
                
                this.AddEditPersonal(personalVM);

            }
        }
        #endregion


        #region Consultar Horario del Servidor
        private string ConsultarHorarioServidor()
        {
            return DateTime.Now.ToString("dd MMMM, yyyy");
        }
        #endregion


    }
}