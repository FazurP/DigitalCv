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
    
    public partial class tblProductividadInnovadora
    {
        public int id { get; set; }
        public Nullable<int> idPais { get; set; }
        public Nullable<int> idDocumento { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public string strAutor { get; set; }
        public string strTipoProductividadInnovadora { get; set; }
        public string strTitulo { get; set; }
        public string strDescripcion { get; set; }
        public string strClasificacionInternacionalPatentes { get; set; }
        public string strUso { get; set; }
        public string strEstadoActual { get; set; }
        public string strNumeroRegistro { get; set; }
        public string strUsuario { get; set; }
        public Nullable<System.DateTime> dteFechaRegistro { get; set; }
        public string strProposito { get; set; }
        public Nullable<bool> bitConsideraCurriculum { get; set; }
        public Nullable<int> idStatus { get; set; }
    
        public virtual catDocumentos catDocumentos { get; set; }
        public virtual CatPais CatPais { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
        public virtual catStatus catStatus { get; set; }
    }
}
