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

namespace AppDigitalCv.Controllers
{
    public class PersonalController : Controller
    {
        //mandamos llamar al metodo de negocio
        IPersonalBusiness IPersonalBussines;


        public PersonalController(IPersonalBusiness _PersonalBussiness)
        {
            IPersonalBussines = _PersonalBussiness;
        }

        
        #region Crear 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,ApellidoPaterno,ApellidoMaterno,RFC,Curp,HomoClave,ArchivoRfc,ArchivoCurp,ImageFile,strLogros")] PersonalVM personalVM)
        {
            if (ModelState.IsValid)
            {
                if (personalVM.ArchivoCurp != null && personalVM.ArchivoRfc != null && personalVM.ImageFile != null)
                {
                    string nombreCompleto = personalVM.Nombre + " " + personalVM.ApellidoPaterno + " " + personalVM.ApellidoMaterno;
                    this.CrearDirectorioUsuario(personalVM);
                                                           
                }
                return View();
            }
            else {
                return View("Create");
            }
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
            int idPersonal = 4; ///este es un parametro temporal
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
            //return View(personalVM);
        }

        public ActionResult EditarDatosPersonales(int idPersonal)
        {
            PersonalDomainModel personalDM = IPersonalBussines.GetPersonalById(idPersonal);
            PersonalVM personalVM = new PersonalVM();
            AutoMapper.Mapper.Map(personalDM, personalVM);///hacemos el mapeado de la entidad
            return PartialView("_Editar",personalVM);
        }


       
        public ActionResult Details()
        {
            ViewBag.PersonalList = IPersonalBussines.GetEmpleado();
            return PartialView("Details");
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
        #endregion


        #region Consultar Datos del Personal
        [HttpGet]
        public JsonResult ConsultarDatosPersonal()
        {
            var personal = IPersonalBussines.GetEmpleado();
            return Json(personal, JsonRequestBehavior.AllowGet);
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
            string nombreCompleto = personalVM.Nombre + " " + personalVM.ApellidoPaterno + " " + personalVM.ApellidoMaterno;
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