using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
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

        public AlergiasController(IAlergiasBusiness _alergiasBusiness)
        {
            alergiasBusiness = _alergiasBusiness;
        }
        /// <summary>
        /// Este metodo carga los dropdawnlist al carga la vista
        /// </summary>
        /// <returns>una vista</returns>
        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.Alimentos = new SelectList(alergiasBusiness.GetAlergias(), "IdAlergias", "strDescripcion");
                ViewBag.Alergenos = new SelectList(alergiasBusiness.GetAlergenos(), "IdAlergias", "strDescripcion");
                ViewBag.Medicamentos = new SelectList(alergiasBusiness.GetMedicamentos(), "IdAlergias", "strDescripcion");
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

            if (Alimentos != null || Alimentos != "0" && Alergenos != null || Alergenos != "0" 
                && Medicamentos != null || Medicamentos != "0")
            {
                AlergiasPersonalVM alergiasPersonalAlimentosVM = new AlergiasPersonalVM();
                alergiasPersonalAlimentosVM.IdAlergia = int.Parse(Alimentos);
                alergiasPersonalAlimentosVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                alergiasPersonalAlimentosVM.dteFechaRegistro = DateTime.Now;
                alergiaspersonales.Add(alergiasPersonalAlimentosVM);

                AlergiasPersonalVM alergiasPersonalAlergenosVM = new AlergiasPersonalVM();
                alergiasPersonalAlergenosVM.IdAlergia = int.Parse(Alergenos);
                alergiasPersonalAlergenosVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                alergiasPersonalAlergenosVM.dteFechaRegistro = DateTime.Now;
                alergiaspersonales.Add(alergiasPersonalAlergenosVM);


                AlergiasPersonalVM alergiasPersonalMedicamentosVM = new AlergiasPersonalVM();
                alergiasPersonalMedicamentosVM.IdAlergia = int.Parse(Medicamentos);
                alergiasPersonalMedicamentosVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
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
    }
}