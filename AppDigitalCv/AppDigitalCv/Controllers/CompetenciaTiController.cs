using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Security;
using AppDigitalCv.Models;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;

namespace AppDigitalCv.Controllers
{
    public class CompetenciaTiController : Controller
    {
        ICompetenciaBusiness icompetenciaTiBusiness;
        ICompetenciasTiBusiness icompetenciasTiBusiness;
        public CompetenciaTiController(ICompetenciaBusiness _competenciaBusiness, ICompetenciasTiBusiness _icompetenciasTiBusiness)
        {
            icompetenciaTiBusiness = _competenciaBusiness;
            icompetenciasTiBusiness = _icompetenciasTiBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.Competencias = icompetenciaTiBusiness.GetCompetenciasTi();
                return View("Create");
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
            
        }

        [HttpPost]
        public void CreateList(string ItemList)
        {
            int IdPersonal = SessionPersister.AccountSession.IdPersonal;
            if (ItemList != null)
            {
                string[] checkArreglo = ItemList.Split(',');
                if (checkArreglo != null)
                {
                    foreach (var id in checkArreglo)
                    {
                        var IdCompetencia = id;

                        icompetenciasTiBusiness.AddUpdateCompetenciaTi(IdPersonal, int.Parse(IdCompetencia));
                    }
                }
                
            }
           
        }

       
        public ActionResult GetDatosCompetenciasTI()
        {
            
            return View("CompetenciasTI");
            
        }


        [HttpGet]
        public JsonResult GetDatosDeCompetenciasTI()
        {
            int IdPersonal = SessionPersister.AccountSession.IdPersonal;
            var competencias = icompetenciasTiBusiness.GetCompetenciasTi(IdPersonal);
            return Json(competencias,JsonRequestBehavior.AllowGet);
        }


        #region  Consultar los datos de las competencias en ti junto con el datatable se pueden ordenar de forma adecuada

        [HttpGet]
        public JsonResult GetDatosCompetenciaTiTable(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<CompetenciasTiDomainModel> competencias = new List<CompetenciasTiDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                competencias = icompetenciasTiBusiness.GetCompetenciasTi(IdentityPersonal).Where(p => p.CompetenciaTiDomainModel.StrDescripcion.Contains(param.sSearch)).ToList();

            }
            else
            {
                totalCount = icompetenciasTiBusiness.GetCompetenciasTi(IdentityPersonal).Count();
                competencias = icompetenciasTiBusiness.GetCompetenciasTi(IdentityPersonal).OrderBy(p => p.IdPersonal)
                             .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = competencias,
                sEcho = param.sEcho,
                iTotalDisplayRecords = competencias.Count(),
                iTotalRecords = competencias.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        /// <summary>
        /// Este Metodo se encarga de consultar los datos y mostrarlos en una vista parcial
        /// </summary>
        /// <param name="idCompetenciaTI">el identificador  de la competencia en ti</param>
        /// <returns>una vista con los datos solicitados</returns>
        public ActionResult MostrarDatosFamiliaresDeleteById(int IdCompetenciaTIPersonal)
        {
             
            CompetenciasTiDomainModel competenciaTi = new CompetenciasTiDomainModel();
            CompetenciasTiVM competenciaTiVM = new CompetenciasTiVM();
            if (IdCompetenciaTIPersonal > 0)
            {
                competenciaTi = icompetenciasTiBusiness.GetCompetenciaTIByIdCompetencia(IdCompetenciaTIPersonal);
            }
            AutoMapper.Mapper.Map(competenciaTi, competenciaTiVM);
            CompetenciaTiVM competencia = new CompetenciaTiVM();
            competenciaTiVM.CompetenciaVM = competencia;
            AutoMapper.Mapper.Map(competenciaTi.CompetenciaTiDomainModel, competenciaTiVM.CompetenciaVM);
            
            return PartialView("_Eliminar", competenciaTiVM);
        }


        #region Eliminar Competencias de TI
        /// <summary>
        /// Este metodo se encarga de presentar los datos a la vista que se van a eliminar
        /// </summary>
        /// <param name="idPersonal">recibe un identificador del trabajador</param>
        /// <returns>regresa una vista con los datos eliminados</returns>
        public void EliminarDatosDeContactoDocente(CompetenciasTiVM competenciasTiVM)
        {
            int _idPersonal = SessionPersister.AccountSession.IdPersonal;

            CompetenciasTiDomainModel competenciasDM = icompetenciasTiBusiness.GetCompetenciaTIByIdCompetencia(competenciasTiVM.IdCompetenciaTIPersonal);
                
            if (competenciasDM != null)
            {
                icompetenciasTiBusiness.DeleteCompetenciaTiPersonal(competenciasDM.IdCompetenciaTIPersonal);
            }
            
        }
        #endregion


    }
}