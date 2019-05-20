using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Models;
using AppDigitalCv.Security;
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

        }

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

        [HttpPost]
        public ActionResult GetCompetenciasByIdPersonal() {

            return PartialView();
        }
    }
}