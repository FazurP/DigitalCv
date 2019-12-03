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

        public PersonalController(IPersonalBusiness _PersonalBussiness, IEstadoCivilBusiness _estadoCivilBusiness, INacionalidadBusiness _nacionalidadBusiness)
        {

            IPersonalBussines = _PersonalBussiness;
            estadoCivilBusiness = _estadoCivilBusiness;
            NacionalidadBusiness = _nacionalidadBusiness;
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                PersonalVM personalVM = new PersonalVM();
                PersonalDomainModel personalDomainModel = new PersonalDomainModel();

                personalDomainModel = IPersonalBussines.GetPersonalById(SessionPersister.AccountSession.IdPersonal);

                AutoMapper.Mapper.Map(personalDomainModel, personalVM);

                ViewBag.idNacionalidad = new SelectList(NacionalidadBusiness.GetAllNacionalidades(), "id", "strValor");
                ViewBag.IdEstadoCivil = new SelectList(estadoCivilBusiness.GetEstadoCivil(), "IdEstadoCivil", "StrDescripcion");

                return View(personalVM);
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
                &&
                ModelState.IsValidField("ArchivoNacionalidad")
                )
            {
                if (personalVM.ArchivoCurp != null && personalVM.ArchivoRfc != null && personalVM.ArchivoNacionalidad != null
                    && personalVM.ArchivoCurp.ContentType.Equals("application/pdf")
                    && personalVM.ArchivoRfc.ContentType.Equals("application/pdf")
                    && personalVM.ArchivoNacionalidad.ContentType.Equals("application/pdf"))
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
            AutoMapper.Mapper.Map(personalVM, personalDM);///hacemos el mapeado de la entidad

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
                            img.image.SaveAs(ruta + nombre);
                            Bitmap bmp = new Bitmap(CambiarTamanioImagen(Image.FromFile(ruta + nombre), 128, 128));
                            using (var stream = new MemoryStream())
                            {
                                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                                var image = Image.FromStream(stream);

                                image.Save(ruta + nombre + ".jpeg");
                            }
                        }
                    }
                    else
                    {
                        System.IO.File.Delete(ruta + nombre);
                        System.IO.File.Delete(ruta + nombre + ".jpeg");
                        if (img.image.ContentType.Equals("image/jpeg"))
                        {
                            img.image.SaveAs(ruta + nombre);
                            Bitmap bmp = new Bitmap(CambiarTamanioImagen(Image.FromFile(ruta + nombre), 128, 128));
                            using (var stream = new MemoryStream())
                            {
                                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                                var image = Image.FromStream(stream);

                                image.Save(ruta + nombre + ".jpeg");
                            }
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(ruta);
                    GuardarImagen(img);
                }
            }
        }
        public Bitmap CambiarTamanioImagen(Image imagenOriginal, int width, int height)
        {
            var radio = Math.Max((double)width / imagenOriginal.Width, (double)height / imagenOriginal.Height);
            var nuevoAncho = (int)(imagenOriginal.Width * radio);
            var nuevoAlto = (int)(imagenOriginal.Height * radio);

            var ImagenRedimencionada = new Bitmap(width, height);
            Graphics.FromImage(ImagenRedimencionada).DrawImage(imagenOriginal, 0, 0, width, height);
            Bitmap ImagenFinal = new Bitmap(ImagenRedimencionada);

            return ImagenFinal;
        }

        #region Crear Directorio de Usuario
        //string nombreCompleto ,HttpPostedFileWrapper curpFile, HttpPostedFileWrapper rfcFile, HttpPostedFileWrapper imageFile,
        public void CrearDirectorioUsuario(PersonalVM personalVM)
        {
            string nombreCompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto));
            string pathRfc = string.Empty;
            string pathCurp = string.Empty;
            string pathNacio = string.Empty;

            if (Directory.Exists(path))
            {

                pathRfc = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_RFC), Path.GetFileName(personalVM.ArchivoRfc.FileName));
                pathCurp = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_CURP), Path.GetFileName(personalVM.ArchivoCurp.FileName));
                pathNacio = Path.Combine(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_NACIONALIDAD), Path.GetFileName(personalVM.ArchivoNacionalidad.FileName));

                if (!Directory.Exists(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_RFC))
                    &&
                    !Directory.Exists(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_CURP))
                     &&
                    !Directory.Exists(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_NACIONALIDAD))
                    )
                {
                    Directory.CreateDirectory(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_RFC));
                    Directory.CreateDirectory(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_CURP));
                    Directory.CreateDirectory(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_NACIONALIDAD));

                    CrearDirectorioUsuario(personalVM);
                }
                else 
                {
                   string[] searchRfc = Directory.GetFiles(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_RFC));
                   string[] searchCurp = Directory.GetFiles(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_CURP));
                   string[] searchNacionalidad = Directory.GetFiles(Server.MapPath("~/Imagenes/Usuarios/" + nombreCompleto + Recursos.RecursosSistema.URL_DOC_PERSONAL_NACIONALIDAD));

                    if (searchRfc.Length > 0 && searchCurp.Length > 0 && searchNacionalidad.Length > 0)
                    {
                        if (System.IO.File.Exists(searchRfc[0]) && System.IO.File.Exists(searchCurp[0]) && System.IO.File.Exists(searchNacionalidad[0]))
                        {
                            System.IO.File.Delete(searchRfc[0]);
                            System.IO.File.Delete(searchCurp[0]);
                            System.IO.File.Delete(searchNacionalidad[0]);

                            CrearDirectorioUsuario(personalVM);
                        }
                    }
                    else
                    {
                        personalVM.ArchivoRfc.SaveAs(pathRfc);
                        personalVM.ArchivoCurp.SaveAs(pathCurp);
                        personalVM.ArchivoNacionalidad.SaveAs(pathNacio);

                        personalVM.strUrlRfc = personalVM.ArchivoRfc.FileName;
                        personalVM.strUrlCurp = personalVM.ArchivoCurp.FileName;
                        personalVM.strUrlNacionalidad = personalVM.ArchivoNacionalidad.FileName;

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



    } 
}