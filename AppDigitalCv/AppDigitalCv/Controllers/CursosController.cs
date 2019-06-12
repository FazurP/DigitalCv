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
using AppDigitalCv.Models;

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
                ViewBag.IdCurso = new SelectList(cursoBusiness.GetCursos(), "Id", "StrDescripcion");
                ViewBag.IdInstitucionSuperior = new SelectList(institucionSuperiorBusiness.GetInstitucionSuperior(), "IdInstitucionSuperior", "StrDescripcion");
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "IdCurso,IdInstitucionSuperior,FechaInicio,FechaTermino,DocumentoPDF")]CursosVM cursosVM)
        {
            string nombre = SessionPersister.AccountSession.NombreCompleto;
            cursosVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
            if (ModelState.IsValid)
            {
                if (DateTime.Parse(cursosVM.FechaInicio) <= DateTime.Parse(cursosVM.FechaTermino))
                {
                    CursosDomainModel cursosDM = new CursosDomainModel();
                    AutoMapper.Mapper.Map(cursosVM, cursosDM);
                    if (GuardarArchivo(cursosDM, nombre))
                    {
                        cursosDM.StrUrlDocumento = Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre + "/" + cursosDM.DocumentoPDF.FileName;
                        cursosBusiness.AddUpdateCursos(cursosDM);
                    }
                    else
                    {
                        ViewBag.ErrorArchivo = Recursos.RecursosSistema.ERROR_GUARDADO_ARCHIVO;
                    }
                }
                else
                {
                    ViewBag.ErrorFechaComparacion=Recursos.RecursosSistema.ERROR_COMPARACION_FECHA;
                }

            }
            ViewBag.IdCurso = new SelectList(cursoBusiness.GetCursos(), "Id", "StrDescripcion");
            ViewBag.IdInstitucionSuperior = new SelectList(institucionSuperiorBusiness.GetInstitucionSuperior(), "IdInstitucionSuperior", "StrDescripcion");
            return View("Create");
        }
        
        /// <summary>
        /// Este metodo se encarga de guardar un archivo dentro de la estructura de directorios de la aplicacion
        /// </summary>
        /// <param name="cursosDM">una entidad del tipo cursosDM</param>
        /// <param name="nombre">el nombre de la ruta principal del archivo</param>
        /// <returns>un valor boolean</returns>
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


        #region  Consultar los datos de los cursos del personal

        [HttpGet]
        public JsonResult GetCursosPersonales(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<CursosDomainModel> cursos = new List<CursosDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                
                cursos = cursosBusiness.GetCursosPersonalesById(IdentityPersonal).Where(p=>p.CursoDomainModel.StrDescripcion.Contains(param.sSearch)).ToList();
            }
            else
            {
                
                totalCount = cursosBusiness.GetCursosPersonalesById(IdentityPersonal).Count();
                cursos = cursosBusiness.GetCursosPersonalesById(IdentityPersonal).OrderBy(P => P.FechaInicio)
                         .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }
            return Json(new
            {
                aaData = cursos,
                sEcho = param.sEcho,
                iTotalDisplayRecords = cursos.Count(),
                iTotalRecords = cursos.Count()

            }, JsonRequestBehavior.AllowGet);

        }


        public JsonResult ConsultarJson()
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<CursosDomainModel> cursos = new List<CursosDomainModel>();
            cursos = cursosBusiness.GetCursosPersonalesById(IdentityPersonal).ToList();
            return Json(cursos, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Eliminar datos personales

        /// <summary>
        /// Este Metodo se encarga de consultar los datos y mostrarlos en una vista parcial
        /// </summary>
        /// <param name="idPersonal">el identificador  del personal</param>
        /// <returns>una vista con los datos solicitados</returns>
        public ActionResult DeleteCursosPersonal(int Id)
        {
            CursosDomainModel cursosDomain =  new CursosDomainModel();
            CursosVM cursosVM = new CursosVM();

            if (Id > 0)
            {
                cursosDomain = cursosBusiness.GetCursoPersonalById(Id);
            }
            
            AutoMapper.Mapper.Map(cursosDomain, cursosVM);
            return PartialView("_Eliminar", cursosVM);
        }

        #endregion
    }
}