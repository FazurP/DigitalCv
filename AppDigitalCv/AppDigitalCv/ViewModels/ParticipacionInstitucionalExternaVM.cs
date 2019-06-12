using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class ParticipacionInstitucionalExternaVM
    {
        public int id { get; set; }
        public int idCatInstitucionSuperior { get; set; }
        public int idCatPeriodo { get; set; }
        public int idCatDocumento { get; set; }
        public int idPersonal { get; set; }
        public string strActividad { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public DateTime dteFechaTermino { get; set; }
        public DocumentosVM documentosVM { get; set; }

        //Estos atributos seran solo para mostrar los datos en el model de actualizar

        public string institucionSuperior { get; set; }
        public string periodo { get; set; }
        public string documento { get; set; }
        public DocumentosVM documentosUpdateVM { get; set; }

    }
}