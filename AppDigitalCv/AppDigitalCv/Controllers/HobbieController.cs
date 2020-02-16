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
    public class HobbieController : Controller
    {
        IHobbieBusiness hobbieBusiness;
        IHobbiesBusiness hobbiesBusiness;
        IFrecuenciaBusiness frecuenciaBusiness;

        public HobbieController(IHobbieBusiness _hobbieBusiness, IHobbiesBusiness _hobbiesBusiness, IFrecuenciaBusiness _frecuenciaBusiness)
        {
            hobbieBusiness = _hobbieBusiness;
            hobbiesBusiness = _hobbiesBusiness;
            frecuenciaBusiness = _frecuenciaBusiness;
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (SessionPersister.AccountSession != null)
            {
                ViewBag.idHobbie = new SelectList(hobbiesBusiness.GetAllHobbies(), "id", "strValor");
                ViewBag.idFrecuencia = new SelectList(frecuenciaBusiness.GetFrecuencia(), "IdFrecuencia", "StrDescripcion");
                return View();
            }
            return RedirectToAction("Seguridad", "Login");
        }

        [HttpPost]
        public ActionResult Create(HobbieVM hobbieVM)
        {

            if (ModelState.IsValid)
            {

                hobbieVM.idPersonal = SessionPersister.AccountSession.IdPersonal;

                HobbieDomainModel hobbieDomainModel = new HobbieDomainModel();

                AutoMapper.Mapper.Map(hobbieVM, hobbieDomainModel);

                hobbieBusiness.AddUpdateHobbie(hobbieDomainModel);
            }

            return RedirectToAction("Create", "Hobbie");
        }

        [HttpGet]
        public JsonResult GetAllHobbiesByPersonal(DataTablesParam param)
        {
            int identityPersonal = SessionPersister.AccountSession.IdPersonal;
            List<HobbieDomainModel> hobbiesDM = new List<HobbieDomainModel>();

            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
            }

            int totalCount = 0;

            if (param.sSearch != null)
            {
                hobbiesDM = hobbieBusiness.GetAllHobbiesByPersonal(identityPersonal).Where(p => p.Hobbies.strValor.Contains(param.sSearch)).ToList();
            }
            else
            {
                totalCount = hobbieBusiness.GetAllHobbiesByPersonal(identityPersonal).Count();

                hobbiesDM = hobbieBusiness.GetAllHobbiesByPersonal(identityPersonal).OrderBy(p => p.Hobbies.strValor).Skip((pageNo - 1)
                    * param.iDisplayLength).Take(param.iDisplayLength).ToList();
            }

            return Json(new
            {

                aaData = hobbiesDM,
                sEcho = param.sEcho,
                iTotalDisplayRecords = hobbiesDM.Count(),
                iTotalRecords = hobbiesDM.Count()

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetHobbieUpdate(int _id)
        {
            HobbieDomainModel hobbieDomainModel = new HobbieDomainModel();
            HobbieVM hobbieVM = new HobbieVM();

            if (_id > 0)
            {

                hobbieDomainModel = hobbieBusiness.GetHobbieByPersonal(_id);

                AutoMapper.Mapper.Map(hobbieDomainModel, hobbieVM);

                ViewBag.idHobbie = new SelectList(hobbiesBusiness.GetAllHobbies(), "id", "strValor");
                ViewBag.idFrecuencia = new SelectList(frecuenciaBusiness.GetFrecuencia(), "IdFrecuencia", "StrDescripcion");

            }

            return PartialView("_Editar", hobbieVM);
        }

        [HttpPost]
        public ActionResult UpdateHobbie(HobbieVM hobbieVM) 
        {
            if (hobbieVM.id > 0)
            {
                HobbieDomainModel hobbieDomainModel = new HobbieDomainModel();

                AutoMapper.Mapper.Map(hobbieVM,hobbieDomainModel);

                hobbieBusiness.AddUpdateHobbie(hobbieDomainModel);
            }

            return RedirectToAction("Create","Hobbie");
        }

        [HttpGet]
        public ActionResult GetHobbieDelete(int _id) 
        {
            HobbieDomainModel hobbieDomainModel = new HobbieDomainModel();
            HobbieVM hobbieVM = new HobbieVM();

            if (_id > 0)
            {

                hobbieDomainModel = hobbieBusiness.GetHobbieByPersonal(_id);

                AutoMapper.Mapper.Map(hobbieDomainModel, hobbieVM);
            }

            return PartialView("_Eliminar", hobbieVM);
        }

        [HttpGet]
        public ActionResult DeleteHobbie(int _id) 
        {
            if (_id > 0)
            {
                hobbieBusiness.DeleteHobbie(_id);
            }

            return RedirectToAction("Create","Hobbie");
        }

        [HttpGet]
        public ActionResult DisplayHobbie(int id) 
        {
            if (id > 0)
            {
                HobbieDomainModel hobbieDomainModel = hobbieBusiness.GetHobbieByPersonal(id);
                HobbieVM hobbieVM = new HobbieVM();

                AutoMapper.Mapper.Map(hobbieDomainModel, hobbieVM);

                return PartialView("_VerDatos",hobbieVM);
            }

            return PartialView();
        }
    }
}