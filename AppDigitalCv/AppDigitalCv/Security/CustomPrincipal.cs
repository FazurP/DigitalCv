using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AppDigitalCv.Security
{
    public class CustomPrincipal:IPrincipal
    {
        private AccountViewModel accountViewModel;
                
        public CustomPrincipal(AccountViewModel _account)
        {
            this.accountViewModel = _account;
            this.Identity = new GenericIdentity(this.accountViewModel.Nombre);
        }

        public IIdentity Identity { get; set; }

        
        public bool IsInRole(string role)
        {
            //var roles = role.Split(new char[] { ',' });
            //return roles.Any(p => this.accountViewModel.Roles.Contains(role));
            return true;
        }
    }
}