using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class DatosContactoController : Controller
    {
        //agregamos el  objeto de negocio
        IDatosContacto IdatosContacto;
        ITelefono Itelefono;

        /// <summary>
        /// Constructor del controlador que recibe el objeto de negocio
        /// </summary>
        /// <param name="_IdatosContacto">
        /// Interface de Negocio
        /// </param>
        public DatosContactoController(IDatosContacto _IdatosContacto, ITelefono _Itelefono)
        {
            IdatosContacto = _IdatosContacto;
            Itelefono = _Itelefono;
        }

        // GET: DatosContacto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include= "MailPersonal,MailInstitucional,NombreFacebook,NombreTwitter,TelefonoCasa,TelefonoCelular,TelefonoRecados")]DatosContactoVM datosContactoVM)
        {
            if (ModelState.IsValid)
            {
                datosContactoVM.IdPersonal = 1; ///este dato es temporal
                this.AddEditDatosContacto(datosContactoVM);
                return View("Create");
            }
            return View("Create");
        }

        [HttpGet]
        public ActionResult EditarDatosContacto()
        {
            return View();
        }


        #region Agregar o Editar una entidad

        public bool AddEditDatosContacto(DatosContactoVM datosContactoVM)
        {
            string resultado = string.Empty;
            bool respuesta = false;

            DatosContactoDomainModel datosContactoDM = new DatosContactoDomainModel();
            AutoMapper.Mapper.Map(datosContactoVM, datosContactoDM);///hacemos el mapeado de la entidad
            //inserción de datos del contacto
            respuesta = IdatosContacto.AddUpdateDatosContacto(datosContactoDM);
            if (respuesta)
            {
                //insercion del telefono en el mismo proceso.
                respuesta = Itelefono.AddUpdateTelefono(datosContactoDM);
            }

            return respuesta;
        }
        #endregion

        #region Consultar Datos de Contacto

       
        public JsonResult ConsultarDatosContacto()
        {
            var datosContacto = IdatosContacto.GetDatosDeContacto(1);////////////////////////modificacion temporal
            return Json(datosContacto, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}