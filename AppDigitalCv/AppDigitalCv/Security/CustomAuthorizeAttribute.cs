using AppDigitalCv.Business;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private IAccountBusiness IaccountBusiness;

        

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            
            if (SessionPersister.AccountSession == null)
                //si no viene vacio el objeto entramos sin problema
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Index" }));
            else
            {
                AccountDomainModel accountModel = new AccountDomainModel();
                AccountViewModel viewAccount = SessionPersister.AccountSession;
                AutoMapper.Mapper.Map(viewAccount, accountModel);
                accountModel = IaccountBusiness.ValidarLogin(accountModel);
                AutoMapper.Mapper.Map(accountModel, viewAccount);
                CustomPrincipal customPrincipal = new CustomPrincipal(viewAccount);
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "AccessDenegade", action = "Index" }));
            }
            //if (string.IsNullOrEmpty(SessionPersister.Username))
            //    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Index" }));
            //else
            //{
            //    AccountModel am = new AccountModel();
            //    CustomPrincipal customPrincipal = new CustomPrincipal(am.Find(SessionPersister.Username));
            //    if (!customPrincipal.IsInRole(Roles))
            //        filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "AccessDenegade", action = "Index" }));
            //}
        }

    }
}