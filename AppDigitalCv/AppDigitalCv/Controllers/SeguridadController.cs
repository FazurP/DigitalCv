﻿using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Security;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppDigitalCv.Controllers
{
    public class SeguridadController : Controller
    {
        IAccountBusiness IAccountBusiness;

        private Usuarios.wsusuariosSoapClient wsusuariosSoapClient = new Usuarios.wsusuariosSoapClient();
        private Usuarios.Seguridad  seguridad= new Usuarios.Seguridad();
        private Usuarios.Usuario usuario = new Usuarios.Usuario();
   

        public SeguridadController(IAccountBusiness _IAccountBusiness)
        {
            IAccountBusiness = _IAccountBusiness;
            seguridad.SegUsuario = Recursos.RecursosSistema.SegUsuario;
            seguridad.SegPassword = Recursos.RecursosSistema.SegPassword;
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
            usuario.NomUsuario = accountViewModel.Email;
            usuario.Password = accountViewModel.Password;

            var res = wsusuariosSoapClient.ConsultaUsuarios(seguridad, usuario);

            AccountDomainModel accountDomainModel = new AccountDomainModel();
            AutoMapper.Mapper.Map(accountViewModel, accountDomainModel);

            if (IAccountBusiness.ExistUsuario(accountDomainModel))
            {
                accountDomainModel = IAccountBusiness.ValidarLogin(accountDomainModel);
                ///accountDomainModel = IAccountBusiness.ValidarLoginService(accountDomainModel);

                if (accountDomainModel != null)
                {
                    accountDomainModel.TipoPersonal = res.TipoPersonal.ToString();
                    accountDomainModel.Universidad = res.Universidad;
                    accountDomainModel.TipoUsuario = res.TipoUsuario.ToString();

                    AccountViewModel viewAccount = new AccountViewModel();
                    AutoMapper.Mapper.Map(accountDomainModel, viewAccount);
                    SessionPersister.AccountSession = viewAccount;
                    return RedirectToAction("Create", "Personal");
                }
            }
            else
            {
          
                PersonalDomainModel personalDomainModel = new PersonalDomainModel();        

                if (res.Nombre_usuario != null && res.Clave != null)
                {
                    personalDomainModel.Nombre = res.Nombre;
                    personalDomainModel.ApellidoPaterno = res.ApellidoPaterno;
                    personalDomainModel.ApellidoMaterno = res.ApellidoMaterno;
                    personalDomainModel.AccountDomainModel = new AccountDomainModel { Email = res.Correo_Electronico, Password = usuario.Password, Nombre = usuario.NomUsuario };
                    
                    if (IAccountBusiness.AddUsuario(personalDomainModel))
                    {
                        
                        AccountViewModel viewAccount = new AccountViewModel();
                        viewAccount.NombreCompleto = res.Nombre + " " + res.ApellidoPaterno + " " + res.ApellidoMaterno;
                        SessionPersister.AccountSession = viewAccount;
                        return RedirectToAction("Create", "Personal");
                    }
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


        public ActionResult LogOut()
        {
            SessionPersister.LogOutSession();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Seguridad");
        }
    }
}