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
using System.Drawing;
using System.Threading;
using AppDigitalCv.Models;

namespace AppDigitalCv.Controllers
{
    public class PersonalController : Controller
    {
        //mandamos llamar al metodo de negocio
        IPersonalBusiness IPersonalBussines;
        IEstadoCivilBusiness estadoCivilBusiness;
        INacionalidadBusiness NacionalidadBusiness;
        IInstitucionesSaludBusiness InstitucionesSaludBusiness;

        public PersonalController(IPersonalBusiness _PersonalBussiness,
            IEstadoCivilBusiness _estadoCivilBusiness,
            INacionalidadBusiness _nacionalidadBusiness,
            IInstitucionesSaludBusiness _institucionesSaludBusiness
            )
        {

            IPersonalBussines = _PersonalBussiness;
            estadoCivilBusiness = _estadoCivilBusiness;
            NacionalidadBusiness = _nacionalidadBusiness;
            InstitucionesSaludBusiness = _institucionesSaludBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idNacionalidad = new SelectList(NacionalidadBusiness.GetAllNacionalidades(), "id", "strValor");
                ViewBag.IdEstadoCivil = new SelectList(estadoCivilBusiness.GetEstadoCivil(), "IdEstadoCivil", "StrDescripcion");
                ViewData["SeguridadSocial.idInstitucion"] = new SelectList(InstitucionesSaludBusiness.GetAllInstitucionesSalud(),"id","strValor");

                return View();
            }
            else {
                return View("~/Views/Seguridad/Login.cshtml");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalVM personalVM)
        {

            if (ModelState.IsValidField("idNacionalidad")
                &&
                ModelState.IsValidField("IdEstadoCivil")
                &&
                ModelState.IsValidField("StrGenero")
                &&
                ModelState.IsValidField("Curp")
                &&
                ModelState.IsValidField("ArchivoCurp")
                &&
                ModelState.IsValidField("RFC")
                &&
                ModelState.IsValidField("ArchivoRfc")
                &&
                ModelState.IsValidField("HomoClave")
                &&
                ModelState.IsValidField("strLogros")
                )
            {
                if (personalVM.ArchivoCurp != null && personalVM.ArchivoRfc != null
                    && personalVM.ArchivoCurp.ContentType.Equals("application/pdf")
                    && personalVM.ArchivoRfc.ContentType.Equals("application/pdf"))
                {
                    personalVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
                    this.CrearDirectorioUsuario(personalVM);

                }
                return RedirectToAction("Create", "Personal");
            }
            else {
                return RedirectToAction("Create", "Personal");
            }
        }

        public string AddEditPersonal(PersonalVM personalVM)
        {
            string resultado = string.Empty;
            PersonalDomainModel personalDM = new PersonalDomainModel();
            AutoMapper.Mapper.Map(personalVM, personalDM);

            resultado = IPersonalBussines.AddUpdatePersonal(personalDM);
            return resultado;
        }

        public void GuardarImagen(ImageVM img)
        {
            if (img != null)
            {
                string ruta = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + "ImagePerfil" + "/"));
                string nombre = "perfil";

                if (Directory.Exists(ruta))
                {

                    if (Directory.GetFiles(ruta).Length == 0)
                    {
                        if (img.image.ContentType.Equals("image/jpeg"))
                        {
                            Bitmap bmp = new Bitmap(CambiarTamanioImagen(Image.FromStream(img.image.InputStream), 128, 128));
                            bmp.Save(ruta + nombre + ".jpeg");                                                 
                        }
                    }
                    else
                    {
                        if (img.image.ContentType.Equals("image/jpeg"))
                        {
                            Bitmap bmp = new Bitmap(CambiarTamanioImagen(Image.FromStream(img.image.InputStream), 128, 128));
                            bmp.Save(ruta + nombre + ".jpeg");                       
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(ruta);
                    GuardarImagen(img);
                }
            }

            img = null;
        }
        public Bitmap CambiarTamanioImagen(Image imagenOriginal, int width, int height)
        {
            var ImagenRedimencionada = new Bitmap(width, height);
            Graphics.FromImage(ImagenRedimencionada).DrawImage(imagenOriginal, 0, 0, width, height);
            Bitmap ImagenFinal = new Bitmap(ImagenRedimencionada);
            return ImagenFinal;
        }

        #region Crear Directorio de Usuario
        public void CrearDirectorioUsuario(PersonalVM personalVM)
        {
            string nombreCompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto));
            string pathRfc = string.Empty;
            string pathCurp = string.Empty;

            if (Directory.Exists(path))
            {

                pathRfc = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_RFC), Path.GetFileName(personalVM.ArchivoRfc.FileName));
                pathCurp = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_CURP), Path.GetFileName(personalVM.ArchivoCurp.FileName));
               
                if (!Directory.Exists(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_RFC))
                    &&
                    !Directory.Exists(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_CURP))
                    )
                {
                    Directory.CreateDirectory(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_RFC));
                    Directory.CreateDirectory(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_CURP));

                    CrearDirectorioUsuario(personalVM);
                }
                else 
                {
                   string[] searchRfc = Directory.GetFiles(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_RFC));
                   string[] searchCurp = Directory.GetFiles(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_CURP));
                   
                    if (searchRfc.Length > 0 && searchCurp.Length > 0)
                    {
                        if (System.IO.File.Exists(searchRfc[0]) && System.IO.File.Exists(searchCurp[0]))
                        {
                            System.IO.File.Delete(searchRfc[0]);
                            System.IO.File.Delete(searchCurp[0]);

                            CrearDirectorioUsuario(personalVM);
                        }
                    }
                    else
                    {
                        personalVM.ArchivoRfc.SaveAs(pathRfc);
                        personalVM.ArchivoCurp.SaveAs(pathCurp);

                        personalVM.strUrlRfc = personalVM.ArchivoRfc.FileName;
                        personalVM.strUrlCurp = personalVM.ArchivoCurp.FileName;

                        this.AddEditPersonal(personalVM);
                    }             
                }             
            }
            else
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory(path);
                CrearDirectorioUsuario(personalVM);
            }
        }
        #endregion

        [HttpGet]
        public ActionResult InfoPersonal() 
        {

            if (SessionPersister.AccountSession != null)
            {
                PersonalVM personalVM = new PersonalVM();
                PersonalDomainModel personalDomainModel;

                int idPersonal = SessionPersister.AccountSession.IdPersonal;

                personalDomainModel = IPersonalBussines.GetPersonalById(idPersonal);

                AutoMapper.Mapper.Map(personalDomainModel, personalVM);
                return View(personalVM);
            }
            else 
            {
                return RedirectToAction("Login","Seguridad");
            }
           
        }

        [HttpGet]
        public ActionResult GetSemblanzaEdit(int _idPersonal) 
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            PersonalDomainModel personalDomainModel = IPersonalBussines.GetPersonalById(_idPersonal);

            if (personalDomainModel != null)
            {

                PersonalVM personalVM = new PersonalVM();

                AutoMapper.Mapper.Map(personalDomainModel,personalVM);

                return PartialView("_EditarSemblanza", personalVM);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult UpdateSemblanza(PersonalVM personalVM) 
        {
            if (personalVM.idPersonal > 0)
            {
                PersonalDomainModel personalDomainModel = new PersonalDomainModel();

                AutoMapper.Mapper.Map(personalVM,personalDomainModel);

                IPersonalBussines.UpdateSemblanza(personalDomainModel);
            }

            return RedirectToAction("Create","Personal");
        }

        [HttpGet]
        public ActionResult Perfil() 
        {
            if (SessionPersister.AccountSession != null)
            {
                PersonalVM personalVM = new PersonalVM();

                PersonalDomainModel personalDomainModel = IPersonalBussines.GetPerfil(SessionPersister.AccountSession.IdPersonal);

                if (personalDomainModel != null)
                {
                    AutoMapper.Mapper.Map(personalDomainModel, personalVM);
                }
                return View(personalVM);
            }
            else 
            {
                return RedirectToAction("Login","Seguridad");
            }
           
        }
    } 
}