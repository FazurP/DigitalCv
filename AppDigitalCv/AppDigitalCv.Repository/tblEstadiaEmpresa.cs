//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppDigitalCv.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEstadiaEmpresa
    {
        public int id { get; set; }
        public Nullable<int> idTipoProducto { get; set; }
        public Nullable<int> idProgramaEducativo { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public Nullable<int> idStatus { get; set; }
        public Nullable<int> idDocumento { get; set; }
        public string strNombreEstadia { get; set; }
        public string strResumenProyecto { get; set; }
        public string strObjetivo { get; set; }
        public Nullable<System.DateTime> dteFechaInicio { get; set; }
        public Nullable<System.DateTime> dteFechaTermino { get; set; }
        public string strNumeroAlumnos { get; set; }
        public string strNumeroHoras { get; set; }
        public string strNombreEmpresaInstitucion { get; set; }
        public string strPuntosCriticosResolver { get; set; }
        public string strLogrosBeneficiosObtenidos { get; set; }
        public string strEstadoEstadia { get; set; }
        public Nullable<bool> bitConsideraCurriculum { get; set; }
    
        public virtual catDocumentos catDocumentos { get; set; }
        public virtual catProgramaEducativo catProgramaEducativo { get; set; }
        public virtual catStatus catStatus { get; set; }
        public virtual catTipoProducto catTipoProducto { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}