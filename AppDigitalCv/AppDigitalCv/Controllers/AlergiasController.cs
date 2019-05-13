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
    public class AlergiasController : Controller
    {
        IAlergiasBusiness alergiasBusiness;
        IAlergiasPersonalBusinnes alergiasPersonalBussines;

        public AlergiasController(IAlergiasBusiness _alergiasBusiness, IAlergiasPersonalBusinnes _alergiasPersonalBusinnes)
        {
            alergiasBusiness = _alergiasBusiness;
            alergiasPersonalBussines = _alergiasPersonalBusinnes;
        }

        [HttpGet]
        public ActionResult Create()
        {

            if (SessionPersister.AccountSession != null)
            {
                ViewBag.Alimentos = new SelectList(alergiasBusiness.GetAlergias(), "IdAlergia", "StrDescripcion");
                ViewBag.Alergenos = new SelectList(alergiasBusiness.GetAlergenos(), "IdAlergia", "StrDescripcion");
                ViewBag.Medicamentos = new SelectList(alergiasBusiness.GetMedicamentos(), "IdAlergia", "StrDescripcion");
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }

        }

        /// <summary>
        /// Este metodo se encarga de obtener los datos de la vista y los agrega a un objeto
        /// </summary>
        /// <param name="Alimentos"></param>
        /// <param name="Alergenos"></param>
        /// <param name="Medicamentos"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Alimentos, string Alergenos, string Medicamentos)
        {
            List<AlergiasPersonalVM> alergiaspersonales = new List<AlergiasPersonalVM>();

            if (int.Parse(Alimentos) > 0 && Alimentos != null)
            {
                AlergiasPersonalVM alergiasPersonalAlimentosVM = new AlergiasPersonalVM();
                alergiasPersonalAlimentosVM.idAlergia = int.Parse(Alimentos);
                alergiasPersonalAlimentosVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
                alergiasPersonalAlimentosVM.dteFechaRegistro = DateTime.Now;
                alergiaspersonales.Add(alergiasPersonalAlimentosVM);
            }
            if (int.Parse(Alergenos) > 0 && Alimentos != null)
            {
                AlergiasPersonalVM alergiasPersonalAlergenosVM = new AlergiasPersonalVM();
                alergiasPersonalAlergenosVM.idAlergia = int.Parse(Alergenos);
                alergiasPersonalAlergenosVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
                alergiasPersonalAlergenosVM.dteFechaRegistro = DateTime.Now;
                alergiaspersonales.Add(alergiasPersonalAlergenosVM);
            }
            if (int.Parse(Medicamentos) > 0 && Medicamentos != null)
            {
                AlergiasPersonalVM alergiasPersonalMedicamentosVM = new AlergiasPersonalVM();
                alergiasPersonalMedicamentosVM.idAlergia = int.Parse(Medicamentos);
                alergiasPersonalMedicamentosVM.idPersonal = SessionPersister.AccountSession.IdPersonal;
                alergiasPersonalMedicamentosVM.dteFechaRegistro = DateTime.Now;
                alergiaspersonales.Add(alergiasPersonalMedicamentosVM);
            }

            if (alergiaspersonales.Count() > 0)
            {
                foreach (AlergiasPersonalVM alergia in alergiaspersonales)
                {
                    AddPersonalAlergias(alergia);
                }

                return RedirectToAction("Create", "Alergias");
            }
            return View("Create");
        }

        /// <summary>
        /// Este metodo se encarga de transportar los datos del ViewModel al DomainModel
        /// </summary>
        /// <param name="alergiasPersonalVM"></param>
        /// <returns>true o false si la insersion se llevo acabo.</returns>
        public bool AddPersonalAlergias(AlergiasPersonalVM alergiasPersonalVM)
        {
            AlergiasPersonalDomainModel alergiasPersonalDomainModel = new AlergiasPersonalDomainModel();
            AutoMapper.Mapper.Map(alergiasPersonalVM, alergiasPersonalDomainModel);

            return alergiasBusiness.AddUpdateAlergias(alergiasPersonalDomainModel);
        }

        public ActionResult GetAlegiaById(int idAlergia)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            //AlergiasPersonalDomainModel alergiasPersonalDM = alergiasPersonalBussines.GetAlergiasPersonales(idAlergia, idPersonal);
            AlergiasDomainModel alergiasDM = alergiasBusiness.GetAlergia(idAlergia, idPersonal);

            if (alergiasDM != null)
            {
                AlergiasVM alergiasVM = new AlergiasVM();
                AutoMapper.Mapper.Map(alergiasDM, alergiasVM);
                return PartialView("_Eliminar", alergiasVM);
            }

            return View();
        }
        /// <summary>
        /// Este metodo muestra los datos en la tabla despues de agregarlos.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAlergias(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<AlergiasDomainModel> alergiasDM = new List<AlergiasDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                alergiasDM = alergiasPersonalBussines.GetAlergiasByIdPersonal(IdentityPersonal).Where(p => p.StrDescripcion.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = alergiasPersonalBussines.GetAlergiasByIdPersonal(IdentityPersonal).Count();


                alergiasDM = alergiasPersonalBussines.GetAlergiasByIdPersonal(IdentityPersonal).OrderBy(p => p.StrDescripcion)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = alergiasDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = alergiasDM.Count(),
                iTotalRecords = alergiasDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Este metodo de encarga de eliminar las alergias
        /// </summary>
        /// <param name="alergiasVM"></param>
        /// <returns>una vista</returns>
        public ActionResult DeleteAlergiaById(AlergiasVM alergiasVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            AlergiasPersonalDomainModel alergiasPersonalDM = alergiasPersonalBussines.GetAlergiasPersonales(alergiasVM.IdAlergia, idPersonal);

            if (alergiasPersonalDM != null)
            {
                alergiasPersonalBussines.DeleteAlergias(alergiasPersonalDM);
            }

            return View(Create());
        }
    }
}