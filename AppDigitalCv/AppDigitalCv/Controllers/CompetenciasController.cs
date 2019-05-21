using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
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
                ViewBag.Habilidad = icompetenciasBusiness.GetCompetenciasHabilidad();
                ViewBag.Destreza = icompetenciasBusiness.GetCompetenciasDestreza();
                ViewBag.Valor = icompetenciasBusiness.GetCompetenciasValor();
                return View("Create");
            }
            else {
                return RedirectToAction("Login", "Seguridad");
            }

        }
        /// <summary>
        /// Este metodo se encarga de recibir y registrar los checkbox seleccionados por el usuario.
        /// </summary>
        /// <param name="ItemList"></param>
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

                        icompetenciaPersonalBusiness.AddUpdateCompetencias(IdPersonal, int.Parse(IdCompetencia));
                    }
                }

            }
            else {
                RedirectToAction("Create","Competencias");
            }

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
            List<CompetenciasDomainModel> competenciaDM = new List<CompetenciasDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                competenciaDM = icompetenciaPersonalBusiness.GetCompetenciasByIdPersonal(IdentityPersonal).Where(p => p.strDescripcion.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = icompetenciaPersonalBusiness.GetCompetenciasByIdPersonal(IdentityPersonal).Count();


                competenciaDM = icompetenciaPersonalBusiness.GetCompetenciasByIdPersonal(IdentityPersonal).OrderBy(p => p.strDescripcion)
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
        /// <summary>
        /// Este metodo se encarga de obtener un objeto de la competencia mediante su ID, para su eliminacion
        /// </summary>
        /// <param name="idCompetencia"></param>
        /// <returns>una vista parcial con el objeto</returns>
        [HttpGet]
        public ActionResult GetCompetenciaByIdPersonal(int idCompetencia) {

            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            CompetenciasDomainModel competenciaDM = icompetenciasBusiness.GetCompetencia(idCompetencia, idPersonal);

            if (competenciaDM != null)
            {
                CompetenciasVM competenciaVM = new CompetenciasVM();
                AutoMapper.Mapper.Map(competenciaDM, competenciaVM);
                return PartialView("_Eliminar", competenciaVM);
            }

            return View();
        }
        /// <summary>
        /// Este metodo se encarga de eliminar el objeto obtenido de la competencia
        /// </summary>
        /// <param name="competenciasVM"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult DeleteCompetenciaById(CompetenciasVM competenciasVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            CompetenciasPersonalDomainModel competenciaPersonalDM = icompetenciaPersonalBusiness.GetCompetenciaPersonal(competenciasVM.idCompetencia, idPersonal);

            if (competenciaPersonalDM != null)
            {
                icompetenciaPersonalBusiness.DeleteCompetencia(competenciaPersonalDM);
            }

            return View(Create());
        }
    }

}