using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using System.IO;

namespace AppDigitalCv.Controllers
{
    
    public class CursosController : Controller
    {
        IInstitucionSuperiorBusiness institucionSuperiorBusiness;
        ICursoBusiness cursoBusiness;
        ICursosBusiness cursosBusiness;
        public CursosController(IInstitucionSuperiorBusiness _institucionSuperiorBusiness, ICursoBusiness _cursoBusiness, ICursosBusiness _cursosBusiness)
        {
            institucionSuperiorBusiness = _institucionSuperiorBusiness;
            cursoBusiness = _cursoBusiness;
            cursosBusiness = _cursosBusiness;
        }


        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.Cursos = new SelectList(cursoBusiness.GetCursos(), "Id", "StrDescripcion");
                ViewBag.Institucion = new SelectList(institucionSuperiorBusiness.GetInstitucionSuperior(), "IdInstitucionSuperior", "StrDescripcion");
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,IdInstitucionSuperior,FechaInicio,FechaTermino,DocumentoPDF")]CursosVM cursosVM)
        {
            string nombre = SessionPersister.AccountSession.NombreCompleto;
            
            if (ModelState.IsValid)
            {
                CursosDomainModel cursosDM = new CursosDomainModel();
                AutoMapper.Mapper.Map(cursosVM,cursosDM);
                if (GuardarArchivo(cursosDM, nombre)) ///aqui se guarda el archivo
                {
                    cursosDM.StrUrlDocumento = Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre + "/"+cursosDM.DocumentoPDF.FileName;
                    cursosBusiness.AddUpdateCursos(cursosDM);
                }
                else
                {
                    ViewBag.ErrorArchivo = Recursos.RecursosSistema.ERROR_GUARDADO_ARCHIVO;
                }

            }
            ViewBag.Cursos = new SelectList(cursoBusiness.GetCursos(), "Id", "StrDescripcion");
            ViewBag.Institucion = new SelectList(institucionSuperiorBusiness.GetInstitucionSuperior(), "IdInstitucionSuperior", "StrDescripcion");
            return View();
        }





        private bool GuardarArchivo(CursosDomainModel cursosDM,string nombre)
        {
            bool respuesta = false;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre+"/"));
            if (Directory.Exists(path))
            {
                if (cursosDM.DocumentoPDF.ContentType.Equals("application/pdf"))
                {
                    string pathCompleto =Path.Combine(path, Path.GetFileName(cursosDM.DocumentoPDF.FileName));
                    cursosDM.DocumentoPDF.SaveAs(pathCompleto);
                    respuesta = true;
                }
            }
            return respuesta;
        }

    }
}