using AppDigitalCv.Business.Enum;
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
    public class LibroController : Controller
    {
        ILibroBusiness libroBusiness;
        IPaisBusiness paisBusiness;
        IProgresoProdep progresoProdep;
        List list = new List();

        public LibroController(ILibroBusiness _libroBusiness, IPaisBusiness _paisBusiness, IProgresoProdep _progresoProdep)
        {
            libroBusiness = _libroBusiness;
            paisBusiness = _paisBusiness;
            progresoProdep = _progresoProdep;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.strTipoParticipacion = new SelectList(list.FillTipoParticipacion());
                ViewBag.strEstadoActual = new SelectList(list.FillEstado());
                ViewBag.strProposito = new SelectList(list.FillProposito());
                ViewBag.idPais = new SelectList(paisBusiness.GetPais(), "idPais", "strValor");
                return View();
            }
            else {
                return RedirectToAction("Login","Seguridad");
            }
         
        }

        [HttpPost]
        public ActionResult Create(LibroVM libroVM)
        {
            if (ModelState.IsValid)
            {
                this.AddUpdateLibro(libroVM);
            }

            return RedirectToAction("Create", "Libro");
        }

        public bool AddUpdateLibro(LibroVM libroVM)
        {
            bool respuesta = false;
            int idPersonal = SessionPersister.AccountSession.IdPersonal;
            int idStatus = int.Parse(Recursos.RecursosSistema.REGISTRO_LIBRO);

            libroVM.idPersonal = idPersonal;
            libroVM.idStatus = idStatus;

            LibroDomainModel libroDM = new LibroDomainModel();
            ProgresoProdepVM progresoProdepVM = new ProgresoProdepVM();
            ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();

            progresoProdepVM.idPersonal = idPersonal;
            progresoProdepVM.idStatus = idStatus;


            AutoMapper.Mapper.Map(progresoProdepVM,progresoProdepDM);
            AutoMapper.Mapper.Map(libroVM,libroDM);
            libroBusiness.AddUpdateLibro(libroDM);
            progresoProdep.AddUpdateProgresoProdep(progresoProdepDM);
            respuesta = true;
            return respuesta;
        }

        [HttpGet]
        public JsonResult GetLibros(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<LibroDomainModel> librosDM = new List<LibroDomainModel>();

            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                librosDM = libroBusiness.GetLibrosByPersonal(identityPersonal).Where(p => p.strTituloLibro.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = libroBusiness.GetLibrosByPersonal(identityPersonal).Count();

                librosDM = libroBusiness.GetLibrosByPersonal(identityPersonal).OrderBy(p => p.strTituloLibro).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {

                aaData = librosDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = librosDM.Count(),
                iTotalRecords = librosDM.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetLibroDelete(int _idLibro)
        {
            LibroDomainModel libroDM = new LibroDomainModel();

            libroDM = libroBusiness.GetLibro(_idLibro);

            if (libroDM != null)
            {
                LibroVM libroVM = new LibroVM();

                AutoMapper.Mapper.Map(libroDM,libroVM);

                return PartialView("_Eliminar",libroVM);
            }

            return PartialView("_Eliminar");
        }

        [HttpPost]
        public ActionResult DeleteLibro(LibroVM libroVM)
        {
            LibroDomainModel libroDM = new LibroDomainModel();

            libroDM = libroBusiness.GetLibro(libroVM.id);

            if (libroDM != null)
            {
                if (libroBusiness.GetLibrosByPersonal(libroDM.idPersonal).Count == 1)
                {
                    ProgresoProdepDomainModel progresoProdepDM = new ProgresoProdepDomainModel();
                    progresoProdepDM = progresoProdep.GetProgresoPersonal(SessionPersister.AccountSession.IdPersonal, int.Parse(Recursos.RecursosSistema.REGISTRO_LIBRO));
                    progresoProdep.DeleteProgresoProdep(progresoProdepDM.id);
                    libroBusiness.DeleteLibro(libroDM.id);
                }
                else
                {
                    libroBusiness.DeleteLibro(libroDM.id);
                }
            }
            return RedirectToAction("Create","Libro");
        }

        [HttpGet]
        public ActionResult GetLibroUpdate(int _idLibro)
        {
            LibroDomainModel libroDM = new LibroDomainModel();
            libroDM = libroBusiness.GetLibro(_idLibro);

            if (libroDM != null)
            {
                LibroVM libroVM = new LibroVM();

                AutoMapper.Mapper.Map(libroDM, libroVM);
                return PartialView("_Editar",libroVM);
            }

            return PartialView("_Editar");
        }

        [HttpPost]
        public ActionResult UpdateLibro(LibroVM libroVM)
        {

            if (libroVM.id > 0)
            {
                LibroDomainModel libroDM = new LibroDomainModel();
                AutoMapper.Mapper.Map(libroVM,libroDM);

                libroBusiness.AddUpdateLibro(libroDM);
            }
            return RedirectToAction("Create","Libro");
        }
    }
}