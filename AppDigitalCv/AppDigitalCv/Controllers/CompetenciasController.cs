using AppDigitalCv.Business.Interface;
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

    }
}