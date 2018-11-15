using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class DocumentosController : Controller
    {
        // GET: Documentos
        public ActionResult Index()
        {
            return View();
        }


        #region  Agregar Documentos del Personal
        /// <summary>
        /// Esta Acción se encarga de visualizar una view con fileupload para cargar archivos
        /// </summary>
        /// <returns>una View con los elementos de presentación apra el usuario</returns>
        [HttpGet]
        public ActionResult AgregarDocumentos()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarDocumentos([Bind(Include = "IdPersonal,ArchivoRfc,ArchivoCurp")]DocumentoPersonalVM DocumentoPersonaVm)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("AgregarDocumentos");
        }
        #endregion

    }
}