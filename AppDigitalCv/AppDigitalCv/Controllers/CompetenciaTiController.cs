using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Security;

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
                //return RedirectToAction("GetDatosCompetenciasTI");//Json("",JsonRequestBehavior.AllowGet);
            }
           //return View("Create");
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

    }
}