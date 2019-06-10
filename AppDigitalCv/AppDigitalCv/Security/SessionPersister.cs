using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.Security
{
    public static class SessionPersister
    {
        static string usernameSessionvar = "username";

        /// <summary>
        /// Esta propiedad  regresa un string como parte de la sesion creada por la aplicación
        /// </summary>
        public static string Username
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[usernameSessionvar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }

            set
            {
                HttpContext.Current.Session[usernameSessionvar] = value;
            }
        }

        /// <summary>
        /// Esta propiedad de la sesion regresa un objeto del tipo AccountViewmODEL
        /// </summary>
        public static AccountViewModel AccountSession
        {
            get {
                if (HttpContext.Current == null)
                    return null;
                AccountViewModel sessionObject =(AccountViewModel) HttpContext.Current.Session["AccountManager"]; ///nombre de la sesion de objeto
                if (sessionObject != null)
                    return sessionObject as AccountViewModel;
                return null;
            }
            set {
                HttpContext.Current.Session["AccountManager"] = value;
            }
        }


        /// <summary>
        /// Este metodo se encarga de eliminar todos los elementos establecidos en la sesion asi como todos
        /// los elementos de autenticacion de la sesion.
        /// </summary>
        public static void LogOutSession()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
        }
    }
}