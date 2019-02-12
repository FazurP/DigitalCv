using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Security;

namespace AppDigitalCv.Controllers
{
    public class DatosFamiliaresController : Controller
    {
        IFamiliarBusiness ifamiliarBusiness;

        public DatosFamiliaresController(IFamiliarBusiness _familiarBusiness)
        {
            ifamiliarBusiness = _familiarBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        ///[Bind(Include="StrNombre,StrOcupacion,StrDomicilio,IntEdad,BitVive")]
        public ActionResult Create(FamiliaresVM familiaresVM)
        {
            
                familiaresVM.MadreVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                familiaresVM.MadreVM.IdParentesco = int.Parse(Recursos.RecursosSistema.FAMILIAR_MADRE);

                familiaresVM.PadreVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                familiaresVM.PadreVM.IdParentesco = int.Parse(Recursos.RecursosSistema.FAMILIAR_PADRE);

                familiaresVM.ParejaVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                familiaresVM.ParejaVM.IdParentesco = int.Parse(Recursos.RecursosSistema.FAMILIAR_PAREJA);

                FamiliaresDomainModel familiaresDomainModel = new FamiliaresDomainModel();
                AutoMapper.Mapper.Map(familiaresVM, familiaresDomainModel);
                ifamiliarBusiness.AddFamiliares(familiaresDomainModel);
            
            return View("Create");
        }


    }
}