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
    
    public partial class tblInformeTecnico
    {
        public int id { get; set; }
        public Nullable<int> idDocumento { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public Nullable<int> idStatus { get; set; }
        public string strAutor { get; set; }
        public string strNombreProyecto { get; set; }
        public string strAlcance { get; set; }
        public string strInstitucionBeneficiaria { get; set; }
        public string dteFechaInicio { get; set; }
        public Nullable<int> enumEstadoActual { get; set; }
        public Nullable<System.DateTime> dteElaboracionInforme { get; set; }
        public Nullable<int> numeroPaginas { get; set; }
        public Nullable<int> idPais { get; set; }
        public Nullable<int> enumProposito { get; set; }
        public Nullable<bool> bitLigarCurriculum { get; set; }
    
        public virtual catDocumentos catDocumentos { get; set; }
        public virtual catStatus catStatus { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}