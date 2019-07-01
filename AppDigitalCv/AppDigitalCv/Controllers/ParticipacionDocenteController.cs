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
    public class ParticipacionDocenteController : Controller
    {
        IParticipacionDocenteBusiness IparticipacionDocenteBusiness;

        public ParticipacionDocenteController(IParticipacionDocenteBusiness iparticipacionDocenteBusiness)
        {
            IparticipacionDocenteBusiness = iparticipacionDocenteBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                return View();
            }
            else
            {
                return View("~/Views/Seguridad/Login.cshtml");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StrEvento,StrTipoEvento,StrParticipacion,StrTipoParticipacion,BitPonencia,StrNombrePonencia,StrNombreInstitucionEmpresa,StrLugar,DteFecha,CatDocumentosVM,")] ParticipacionDocenteVM participacionDocenteVM)
        {
            if (ModelState.IsValid)
            {
                if (participacionDocenteVM != null)
                {
                    participacionDocenteVM.IdPersonal  = SessionPersister.AccountSession.IdPersonal;
                    ParticipacionDocenteDomainModel participacionDocenteDM = new ParticipacionDocenteDomainModel();
                    AutoMapper.Mapper.Map(participacionDocenteVM, participacionDocenteDM);
                    IparticipacionDocenteBusiness.AddUpdateParticipacionDocente(participacionDocenteDM);
                }
            }

            return View();
        }


    }
}