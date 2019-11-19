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
using System.IO;

namespace AppDigitalCv.Controllers
{
    public class IdiomaController : Controller
    {
        IIdiomasBusiness idiomasBusiness;
        IIdiomaBusiness IidiomaBusinnes;
        INivelConocimientoBusiness InivelConocimientoBusiness;

        public IdiomaController(IIdiomasBusiness _IidiomaBusiness, IIdiomaBusiness _Iidioma, INivelConocimientoBusiness _nivelConocimientoBusiness)
        {
            idiomasBusiness = _IidiomaBusiness;
            IidiomaBusinnes = _Iidioma;
            InivelConocimientoBusiness = _nivelConocimientoBusiness;
        }
        

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession == null)
            {
                return RedirectToAction("Login","Seguridad");
            }
            else { 
                ViewBag.IdIdioma = new SelectList(IidiomaBusinnes.GetAllIdiomas(), "IdIdioma", "StrDescripcion");
                ViewBag.idNivelConocimiento = new SelectList(InivelConocimientoBusiness.GetAllNivelesConocimiento(),"id","strValor");
            return View();
            }
        }

        /// <summary>
        /// Metodo para insertar el idioma que habla un usuario
        /// </summary>
        /// <param name="idiomaDialectoVM"> Pide un parametro de tipo view model </param>
        /// <returns> Regresa una lista con los datos pedidos </returns>
        [HttpPost]
        public ActionResult Create(IdiomasVM idiomasVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            idiomasVM.idPersonal = idPersonal;

            if (ModelState.IsValidField("idIdioma") && ModelState.IsValidField("idNivelConocimiento") && ModelState.IsValidField("documentosVM"))
            {
                IdiomasDomainModel idiomasDomainModel = new IdiomasDomainModel();
                AutoMapper.Mapper.Map(idiomasVM, idiomasDomainModel);
                DocumentosDomainModel documentosDomain = new DocumentosDomainModel();
                AutoMapper.Mapper.Map(idiomasVM.documentosVM,documentosDomain);
                idiomasDomainModel.documentosDomain = documentosDomain;
                if (GuardarArchivo(idiomasDomainModel,SessionPersister.AccountSession.NombreCompleto))
                {
                    idiomasDomainModel.documentosDomain.StrUrl = idiomasDomainModel.documentosDomain.DocumentoFile.FileName;
                    idiomasBusiness.AddUpdateIdioma(idiomasDomainModel);
                }           
            }
           
            return RedirectToAction("Create", "Idioma");
        }

        private bool GuardarArchivo(IdiomasDomainModel idiomasDomainModel, string nombre)
        {
            string path = Path.Combine(Server.MapPath(Recursos.RecursosSistema.DOCUMENTO_USUARIO + nombre + "/"));
            if (Directory.Exists(path))
            {
                if (idiomasDomainModel.documentosDomain.DocumentoFile.ContentType.Equals("application/pdf"))
                {
                    string pathCompleto = Path.Combine(path, Path.GetFileName(idiomasDomainModel.documentosDomain.DocumentoFile.FileName));
                    idiomasDomainModel.documentosDomain.DocumentoFile.SaveAs(pathCompleto);

                }
                return true;
            }
            else
            {
                Directory.CreateDirectory(path);
                return GuardarArchivo(idiomasDomainModel, nombre);
            }
        }

        #region Agregar o editar una entidad
        //private bool AddEditIdioma(IdiomaDialectoVM idiomaDialectoVM)
        //{

        //    IdiomaDialectoDomainModel idiomaDialectoDM = new IdiomaDialectoDomainModel();
        //    AutoMapper.Mapper.Map(idiomaDialectoVM, idiomaDialectoDM);
        //    return IidiomaDialectoBusiness.AddUpdateIdioma(idiomaDialectoDM);
        //}
        #endregion
        /// <summary>
        /// Este metodo se encarga mostrar los idiomas en la tabla
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetIdiomas(DataTablesParam param)
        {
            int IdentityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<IdiomasDomainModel> idiomasDM = new List<IdiomasDomainModel>();

            int pageNo = 1;
            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;
            if (param.sSearch != null)
            {
                idiomasDM = idiomasBusiness.GetAllIdiomasByPersonal(IdentityPersonal).Where(p => p.idiomaDomain.strDescripcion.Contains(param.sSearch)).ToList();


            }
            else
            {
                totalCount = idiomasBusiness.GetAllIdiomasByPersonal(IdentityPersonal).Count();


                idiomasDM = idiomasBusiness.GetAllIdiomasByPersonal(IdentityPersonal).OrderBy(p => p.idiomaDomain.strDescripcion)
                    .Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength).ToList();

            }
            return Json(new
            {
                aaData = idiomasDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = idiomasDM.Count(),
                iTotalRecords = idiomasDM.Count()

            }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Este metodo se encarga de obtener el idioma que se va a mostrar en el modal
        /// </summary>
        /// <param name="idIdioma"></param>
        /// <returns>una vista parcial con el idioma</returns>
        [HttpGet]
        public ActionResult GetIdiomaById(int _id)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
         
            IdiomasDomainModel idiomaDM = idiomasBusiness.GetIdiomaById(_id);

            if (idiomaDM != null)
            {
                IdiomasVM idiomaVM = new IdiomasVM();
                AutoMapper.Mapper.Map(idiomaDM, idiomaVM);
                ViewBag.IdIdioma = new SelectList(IidiomaBusinnes.GetAllIdiomas(), "IdIdioma", "StrDescripcion");
                ViewBag.idNivelConocimiento = new SelectList(InivelConocimientoBusiness.GetAllNivelesConocimiento(), "id", "strValor");
                return PartialView("_Eliminar", idiomaVM);
            }

            return View();
        }
        /// <summary>
        /// Este metodo se encarga de eliminar un idioma
        /// </summary>
        /// <param name="idiomaVM"></param>
        /// <returns>una vista</returns>
        [HttpPost]
        public ActionResult DeleteIdiomaById(IdiomasVM idiomaVM)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            IdiomasDomainModel idiomasDomainModel = idiomasBusiness.GetIdiomaById(idiomaVM.id);

            if (idiomasDomainModel != null)
            {
                idiomasBusiness.DeleteIdioma(idiomasDomainModel);
            }

            return RedirectToAction("Create", "Idioma");
        }

        [HttpGet]
        public ActionResult GetIdiomaByIdEdit(int _id)
        {
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            IdiomasVM idiomasVM = new IdiomasVM();
            IdiomasDomainModel idiomasDM = new IdiomasDomainModel();

            if (_id > 0)
            {
                idiomasDM = idiomasBusiness.GetIdiomaById(_id);
                AutoMapper.Mapper.Map(idiomasDM, idiomasVM);
                ViewBag.IdIdioma = new SelectList(IidiomaBusinnes.GetAllIdiomas(), "IdIdioma", "StrDescripcion");
                ViewBag.idNivelConocimiento = new SelectList(InivelConocimientoBusiness.GetAllNivelesConocimiento(), "id", "strValor");
            }   
            return PartialView("_Editar", idiomasVM);
        }

        [HttpPost]
        public void EditarIdiomasPersonales(IdiomasVM idiomasVM)
        {

            IdiomasDomainModel idiomasDomainModel = new IdiomasDomainModel();

            AutoMapper.Mapper.Map(idiomasVM, idiomasDomainModel);

            if (idiomasVM.id > 0)
            {
                idiomasBusiness.AddUpdateIdioma(idiomasDomainModel);
            }

        }
    }
}