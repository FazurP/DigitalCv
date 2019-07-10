using AppDigitalCv.Business.Interface;
using AppDigitalCv.Repository.Infraestructure.Contract;
using AppDigitalCv.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class ProduccionesArtisticasController : Controller
    {
        IUnitOfWork unitofWork;
        IPaisBusiness paisBusiness;
        IProduccionesArtisticasBusiness produccionesArtisticasBusiness;

        public ProduccionesArtisticasController(IUnitOfWork _unitOfWork, IPaisBusiness _paisBusiness, IProduccionesArtisticasBusiness
            _produccionesArtisticasBusiness)
        {
            unitofWork = _unitOfWork;
            paisBusiness = _paisBusiness;
            produccionesArtisticasBusiness = _produccionesArtisticasBusiness;
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
                return RedirectToAction("Login","Seguridad");
            }
           
        }
    }
}