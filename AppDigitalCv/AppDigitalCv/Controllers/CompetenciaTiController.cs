using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Security;
using AppDigitalCv.Models;
using AppDigitalCv.Domain;

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
            ViewBag.Competencias = icompetenciaTiBusiness.GetCompetenciasTi();
            return View("Create");
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





    }
}