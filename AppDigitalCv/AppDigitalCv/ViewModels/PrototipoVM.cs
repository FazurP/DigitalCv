using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class PrototipoVM
    {
        public int id { get; set; }
        public int idPais { get; set; }
        public int idDocumento { get; set; }
        public DocumentosVM documentosVM { get; set; }
        public int idPersonal { get; set; }
        public int idStatsu { get; set; }
        public string strAutor { get; set; }
        public string strTipoPrototipo { get; set; }
        public string strNombrePrototipo { get; set; }
        public string strObjetivos { get; set; }
        public string strCaracteristicas { get; set; }
        public string strInstitucionDestinada { get; set; }
        public DateTime dteFechaPublicacion { get; set; }
        public string strEstadoActual { get; set; }
        public string strProposito { get; set; }
        public bool bitConsideraCurriculum { get; set; }
    }
}