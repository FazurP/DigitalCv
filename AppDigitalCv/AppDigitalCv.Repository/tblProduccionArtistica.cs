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
    
    public partial class tblProduccionArtistica
    {
        public int id { get; set; }
        public Nullable<int> idProduccionArtistica { get; set; }
        public Nullable<int> idPais { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public Nullable<int> idStatus { get; set; }
        public Nullable<int> idDocumento { get; set; }
        public string strAutor { get; set; }
        public string strNombreObra { get; set; }
        public string strDescripcion { get; set; }
        public string strImpactoInvestigacion { get; set; }
        public string strImpactoMetodologia { get; set; }
        public string strImpactoDiseño { get; set; }
        public string strImpactoInnovacion { get; set; }
        public Nullable<System.DateTime> dteFechaPublicacion { get; set; }
        public string strLugarPresento { get; set; }
        public string strProposito { get; set; }
        public Nullable<bool> bitConsideraCurriculum { get; set; }
    
        public virtual catDocumentos catDocumentos { get; set; }
        public virtual CatPais CatPais { get; set; }
        public virtual catProduccionArtistica catProduccionArtistica { get; set; }
        public virtual catStatus catStatus { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}