using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class InformeTecnicoVM
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public int idPersonal { get; set; }
        public int idStatus { get; set; }
        public string strAutor { get; set; }
        public string strNombreProyecto { get; set; }
        public string strAlcance { get; set; }
        public string strInstitucionBeneficiaria { get; set; }
        public string enumEstadoActual { get; set; }
        public string dteElaboracionInforme { get; set; }
        public int numeroPaginas { get; set; }
        public int idPais { get; set; }
        public string enumProposito { get; set; }
        public DocumentosVM Documentos { get; set; }

    }
}