using AppDigitalCv.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class ContactoEmergenciaController : Controller
    {
        IParentescoBusiness IparentescoBusiness;
        public ContactoEmergenciaController(IParentescoBusiness _IparentescoBusiness)
        {
            IparentescoBusiness = _IparentescoBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdParentesco = new SelectList(IparentescoBusiness.GetParentescos(), "IdParentesco", "StrDescripcion");
            return View();
        }

        #region  Consultar los datos de las competencias en ti junto con el datatable se pueden ordenar de forma adecuada

        [HttpGet]
        public JsonResult GetDatosFamiliaresTable(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<FamiliarDomainModel> familiares = new List<FamiliarDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                familiares = ifamiliarBusiness.GetFamiliaresById(IdentityPersonal).Where(p => p.StrNombre.Contains(param.sSearch)).ToList();
                ///ifamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).Where(p => p.StrNombre.Contains(param.sSearch)).ToList();

            }
            else
            {
                totalCount = ifamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).Count();
                familiares = ifamiliarBusiness.GetFamiliaresById(IdentityPersonal).OrderBy(p => p.IdPersonal)
                             .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();
                //ifamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).OrderBy(p => p.IdPersonal)
                //.Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = familiares,
                sEcho = param.sEcho,
                iTotalDisplayRecords = familiares.Count(),
                iTotalRecords = familiares.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        #endregion





    }
}