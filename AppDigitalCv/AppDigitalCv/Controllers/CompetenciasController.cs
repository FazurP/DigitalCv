using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
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
    public class CompetenciasController : Controller
    {
        ICompetenciasBusiness icompetenciasBusiness;
        ICompetenciaPersonalBusiness icompetenciaPersonalBusiness;
        public CompetenciasController(ICompetenciasBusiness _competenciaBusiness, ICompetenciaPersonalBusiness _icompetenciaPersonalBusiness)
        {
            icompetenciasBusiness = _competenciaBusiness;
            icompetenciaPersonalBusiness = _icompetenciaPersonalBusiness;
        }
        /// <summary>
        /// Este metodo carga los checkbox dinamicamento al momento de cargar la pagina.
        /// </summary>
        /// <returns>una vista</returns>
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View("Create");
            }
            else {
                return RedirectToAction("Login", "Seguridad");
            }

        }

        [HttpPost]
        public ActionResult Create(CompetenciasPersonalVM competenciasPersonalVM) 
        {

            if (ModelState.IsValidField("file"))
            {
                competenciasPersonalVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
                Object[] obj = SaveDocuments(competenciasPersonalVM);

                if (obj[0].Equals(true))
                {
                    CompetenciasPersonalDomainModel competenciasPersonalDomainModel = new CompetenciasPersonalDomainModel();
                    AutoMapper.Mapper.Map(competenciasPersonalVM,competenciasPersonalDomainModel);
                    competenciasPersonalDomainModel.file = new DocumentosDomainModel { StrUrl=obj[1].ToString()};

                    icompetenciaPersonalBusiness.AddUpdateCompetencias(competenciasPersonalDomainModel);
                }
            }

            return RedirectToAction("Create","Competencias");
        }

        private object[] SaveDocuments(CompetenciasPersonalVM competenciasVM)
        {
            Object[] respuesta = new Object[2];

            competenciasVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
            string nombreCompleto = SessionPersister.AccountSession.NombreCompleto;
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO+nombreCompleto));

            if (Directory.Exists(path))
            {
                if (competenciasVM.file.DocumentoFile != null)
                {
                    respuesta = FileManager.FileManager.CheckFileIfExist(path,competenciasVM.file);
                }
            }
            else 
            {
                Directory.CreateDirectory(path);
                SaveDocuments(competenciasVM);
            }

            return respuesta;
        }

        /// <summary>
        /// Este metodo se encarga de mostrar las competencias del personal en la tabla.
        /// </summary>
        /// <param name="param"></param>
        /// <returns>un json</returns>
        [HttpGet]
        public JsonResult GetCompetencias(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<CompetenciasPersonalDomainModel> competenciaDM = new List<CompetenciasPersonalDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                competenciaDM = icompetenciaPersonalBusiness.GetAllCompetenciasPersonal(IdentityPersonal).Where(p => p.dteFechaRegistro.ToString().Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = icompetenciaPersonalBusiness.GetAllCompetenciasPersonal(IdentityPersonal).Count();

                competenciaDM = icompetenciaPersonalBusiness.GetAllCompetenciasPersonal(IdentityPersonal).OrderBy(p => p.dteFechaRegistro)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }
            return Json(new
            {
                aaData = competenciaDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = competenciaDM.Count(),
                iTotalRecords = competenciaDM.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        ///// <summary>
        ///// Este metodo se encarga de obtener un objeto de la competencia mediante su ID, para su eliminacion
        ///// </summary>
        ///// <param name="idCompetencia"></param>
        ///// <returns>una vista parcial con el objeto</returns>
        [HttpGet]
        public ActionResult GetCompetenciaByIdPersonal(int idCompetencia)
        {

            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            CompetenciasPersonalDomainModel competenciaDM = icompetenciaPersonalBusiness.GetCompetenciaPersonal(idCompetencia);

            if (competenciaDM != null)
            {
                CompetenciasPersonalVM competenciaVM = new CompetenciasPersonalVM();
                AutoMapper.Mapper.Map(competenciaDM, competenciaVM);
                competenciaVM.file = new DocumentosVM { StrUrl = competenciaDM.file.StrUrl };
                return PartialView("_Eliminar", competenciaVM);
            }

            return View();
        }
        ///// <summary>
        ///// Este metodo se encarga de eliminar el objeto obtenido de la competencia
        ///// </summary>
        ///// <param name="competenciasVM"></param>
        ///// <returns>una vista</returns>
        [HttpPost]
        public ActionResult DeleteCompetenciaById(CompetenciasPersonalVM competenciasVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;

            string url = Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + SessionPersister.AccountSession.NombreCompleto + "/" + competenciasVM.file.StrUrl);

            if (FileManager.FileManager.DeleteFileFromServer(url))
            {
                CompetenciasPersonalDomainModel competenciasPersonalDomainModel = new CompetenciasPersonalDomainModel();
                AutoMapper.Mapper.Map(competenciasVM, competenciasPersonalDomainModel);
                icompetenciaPersonalBusiness.DeleteCompetenciaPersonal(competenciasPersonalDomainModel);
            }

            return RedirectToAction("Create","Competencias");
        }
    }

}