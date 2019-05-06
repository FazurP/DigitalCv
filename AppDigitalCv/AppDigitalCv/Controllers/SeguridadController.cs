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
    public class SeguridadController : Controller
    {
        IAccountBusiness IAccountBusiness;


        public SeguridadController(IAccountBusiness _IAccountBusiness)
        {
            IAccountBusiness = _IAccountBusiness;
        }

        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }

        /// <summary>
        /// Este metodo de controlador se encarga de realizar el proceso de Login 
        /// </summary>
        /// <param name="accountViewModel">Recibe un objeto del tipo AccountViewModel, con el 
        /// nombre de usuario o mail y el password
        /// </param>
        /// <returns>
        /// regresa un ActionResult o una Vista de resultado
        /// </returns>
        [HttpPost]
        public ActionResult Login(AccountViewModel accountViewModel)
        {
            AccountDomainModel accountDomainModel = new AccountDomainModel();
            AutoMapper.Mapper.Map(accountViewModel,accountDomainModel);

            if(!string.IsNullOrEmpty(accountViewModel.Email) && !string.IsNullOrEmpty(accountViewModel.Password))
            {
                accountDomainModel = IAccountBusiness.ValidarLogin(accountDomainModel);
                if (accountDomainModel != null)
                {
                    AccountViewModel viewAccount = new AccountViewModel();
                    AutoMapper.Mapper.Map(accountDomainModel, viewAccount);
                    SessionPersister.AccountSession = viewAccount;
                    return RedirectToAction("Create", "Personal");
                }
                else
                {
                    ViewBag.Validar = Recursos.RecursosSistema.USUARIO_INEXISTENTE;
                }
            }
            return View();
        }

        [HttpPost]
        public void Cerrar()
        {
            try
            {
                SessionPersister.AccountSession = null;
               
            }
            catch (Exception ex)
            {
                string me = ex.Message;
 
            }
           
        }

    }
}