using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.ViewModels
{
    public class EstadiaEmpresaVM
    {
        public int id { get; set; }
        public int idTipoProducto { get; set; }
        public int idProgramaEducativo { get; set; }
        public int idPersonal { get; set; }
        public int idStatus { get; set; }
        public int idDocumento { get; set; }
        public DocumentosVM documentosVM { get; set; }
        public string strNombreEstadia { get; set; }
        public string strResumenProyecto { get; set; }
        public string strObjetivo { get; set; }
        public DateTime dteFechaInicio { get; set; }
        public DateTime dteFechaTermino { get; set; }
        public string strNumeroAlumnos { get; set; }
        public string strNumeroHoras { get; set; }
        public string strNombreEmpresaInstitucion { get; set; }
        public string strPuntosCriticosResolver { get; set; }
        public string strLogrosBeneficiosObtenidos { get; set; }
        public string strEstadoEstadia { get; set; }
        public bool bitConsideraCurriculum { get; set; }
    }
}