using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDigitalCv.Security;
using AppDigitalCv.Models;

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
        public ActionResult Create(FamiliaresVM familiaresVM)
        {
            
                familiaresVM.MadreVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                familiaresVM.MadreVM.IdParentesco = int.Parse(Recursos.RecursosSistema.FAMILIAR_MADRE);
                familiaresVM.PadreVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                familiaresVM.PadreVM.IdParentesco = int.Parse(Recursos.RecursosSistema.FAMILIAR_PADRE);
                familiaresVM.ParejaVM.IdPersonal = SessionPersister.AccountSession.IdPersonal;
                familiaresVM.ParejaVM.IdParentesco = int.Parse(Recursos.RecursosSistema.FAMILIAR_PAREJA);
               
                ifamiliarBusiness.AddFamiliares( this.MapperObject(familiaresVM)  );
            
            return View("Create");
        }

        #region Mappeo de la Entidad de Familiares
        /// <summary>
        /// Este metodo se encarga de mapear manualmente losd atos entre objetos del dominio y objetos de la viewmodel
        /// </summary>
        /// <param name="familiaresVM">recibe una entidad del tipo viewmodel</param>
        /// <returns>regresa una entidad del tipo familiaresdomainmodel</returns>
        private FamiliaresDomainModel MapperObject(FamiliaresVM familiaresVM)
        {
            FamiliaresDomainModel familiaresDomainModel = new FamiliaresDomainModel();
            familiaresDomainModel.PadreDomainModel = new FamiliarDomainModel();
            familiaresDomainModel.PadreDomainModel.IdPersonal = familiaresVM.PadreVM.IdPersonal;
            familiaresDomainModel.PadreDomainModel.IdParentesco = familiaresVM.PadreVM.IdParentesco;
            familiaresDomainModel.PadreDomainModel.StrNombre = familiaresVM.PadreVM.StrNombre;
            familiaresDomainModel.PadreDomainModel.StrOcupacion = familiaresVM.PadreVM.StrOcupacion;
            familiaresDomainModel.PadreDomainModel.StrDomicilio = familiaresVM.PadreVM.StrDomicilio;
            familiaresDomainModel.PadreDomainModel.IntEdad = familiaresVM.PadreVM.IntEdad;
            familiaresDomainModel.PadreDomainModel.BitVive = familiaresVM.PadreVM.BitVive;

            familiaresDomainModel.MadreDomainModel = new FamiliarDomainModel();       
            familiaresDomainModel.MadreDomainModel.IdPersonal = familiaresVM.MadreVM.IdPersonal;
            familiaresDomainModel.MadreDomainModel.IdParentesco = familiaresVM.MadreVM.IdParentesco;
            familiaresDomainModel.MadreDomainModel.StrNombre = familiaresVM.MadreVM.StrNombre;
            familiaresDomainModel.MadreDomainModel.StrOcupacion = familiaresVM.MadreVM.StrOcupacion;
            familiaresDomainModel.MadreDomainModel.StrDomicilio = familiaresVM.MadreVM.StrDomicilio;
            familiaresDomainModel.MadreDomainModel.IntEdad = familiaresVM.MadreVM.IntEdad;
            familiaresDomainModel.MadreDomainModel.BitVive = familiaresVM.MadreVM.BitVive;

            familiaresDomainModel.ParejaDomainModel = new FamiliarDomainModel();
            familiaresDomainModel.ParejaDomainModel.IdPersonal = familiaresVM.ParejaVM.IdPersonal;
            familiaresDomainModel.ParejaDomainModel.IdParentesco = familiaresVM.ParejaVM.IdParentesco;
            familiaresDomainModel.ParejaDomainModel.StrNombre = familiaresVM.ParejaVM.StrNombre;
            familiaresDomainModel.ParejaDomainModel.StrOcupacion = familiaresVM.ParejaVM.StrOcupacion;
            familiaresDomainModel.ParejaDomainModel.StrDomicilio = familiaresVM.ParejaVM.StrDomicilio;
            familiaresDomainModel.ParejaDomainModel.IntEdad = familiaresVM.ParejaVM.IntEdad;
            familiaresDomainModel.ParejaDomainModel.BitVive = familiaresVM.ParejaVM.BitVive;
            return familiaresDomainModel;
        }
        #endregion

        /// <summary>
        /// Este metodo se encarga de consultar todos los familiares del personal por su identificador
        /// </summary>
        /// <returns>regresa un objeto json con el resultado de la consulta</returns>
        //[HttpGet]
        public JsonResult GetFamiliaresPersonal()
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            var familiares = ifamiliarBusiness.GetFamiliaresHijosById(idPersonal);
            return Json(familiares, JsonRequestBehavior.AllowGet);
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
                familiares = ifamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).Where(p => p.StrNombre.Contains(param.sSearch)).ToList();

            }
            else
            {
                totalCount = ifamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).Count();
                familiares = ifamiliarBusiness.GetFamiliaresHijosById(IdentityPersonal).OrderBy(p => p.IdPersonal)
                             .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

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


        //Edicion de Datos Familiares
        public ActionResult AddEditDatosContactoId(int idFamiliar)
        {
            
            ParentescoVM parentescoVM = new ParentescoVM();
            //creamos el objeto del dominio
            FamiliarDomainModel familiarDM = new FamiliarDomainModel();
            if (idFamiliar > 0)
            {
                familiarDM = ifamiliarBusiness.GetFamiliarByIdFamiliar(idFamiliar);

            }
            AutoMapper.Mapper.Map(familiarDM, parentescoVM);
            return PartialView("_Editar", parentescoVM);
        }

        
        public void EditarDatosFamiliar(ParentescoVM parentescoVM )
        {
            FamiliarDomainModel familiarDM = new FamiliarDomainModel();
            
            AutoMapper.Mapper.Map(parentescoVM, familiarDM);
            if (parentescoVM.IdFamiliar > 0)
            {
                ifamiliarBusiness.AddUpdateFamiliar(familiarDM);
            }
            
        }


    }
}