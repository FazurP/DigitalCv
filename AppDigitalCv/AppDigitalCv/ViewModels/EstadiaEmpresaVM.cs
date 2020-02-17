using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class EstadiaEmpresaVM
    {
        public int id { get; set; }
        public int idProgramaEducativo { get; set; }
        public int idPersonal { get; set; }
        public int idDocumento { get; set; }
        public string strNombreAlumno { get; set; }
        public string strResumenProyecto { get; set; }
        public string strObjetivo { get; set; }
        public string dteFechaInicio { get; set; }
        public string dteFechaTermino { get; set; }
        public string strNombreEmpresaInstitucion { get; set; }
        public string strPuntosCriticosResolver { get; set; }
        public string strLogrosBeneficiosObtenidos { get; set; }
        public string strEstadoEstadia { get; set; }

        //Objetos de las Relaciones

        public DocumentosVM documentos { get; set; }

    }
}