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
    
    public partial class TblEncuesta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblEncuesta()
        {
            this.tblPersonal = new HashSet<tblPersonal>();
        }
    
        public int id { get; set; }
        public Nullable<int> idRespuesta01 { get; set; }
        public Nullable<int> idRespuesta02 { get; set; }
        public Nullable<int> idRespuesta03 { get; set; }
        public Nullable<int> idRespuesta04 { get; set; }
        public Nullable<int> idRespuesta05 { get; set; }
        public Nullable<int> idRespuesta06 { get; set; }
        public Nullable<int> idRespuesta07 { get; set; }
        public Nullable<int> idRespuesta08 { get; set; }
        public Nullable<int> idRespuesta09 { get; set; }
        public Nullable<int> idRespuesta10 { get; set; }
        public Nullable<int> idRespuesta11 { get; set; }
        public Nullable<int> idRespuesta12 { get; set; }
        public Nullable<int> idRespuesta13 { get; set; }
        public Nullable<int> idRespuesta14 { get; set; }
        public Nullable<int> idRespuesta15 { get; set; }
        public Nullable<int> idRespuesta16 { get; set; }
        public Nullable<int> idRespuesta17 { get; set; }
    
        public virtual CatRespuestas01 CatRespuestas01 { get; set; }
        public virtual CatRespuestas02 CatRespuestas02 { get; set; }
        public virtual CatRespuestas03 CatRespuestas03 { get; set; }
        public virtual CatRespuestas04 CatRespuestas04 { get; set; }
        public virtual CatRespuestas05 CatRespuestas05 { get; set; }
        public virtual CatRespuestas06 CatRespuestas06 { get; set; }
        public virtual CatRespuestas07 CatRespuestas07 { get; set; }
        public virtual CatRespuestas08 CatRespuestas08 { get; set; }
        public virtual CatRespuestas10 CatRespuestas10 { get; set; }
        public virtual CatRespuestas11 CatRespuestas11 { get; set; }
        public virtual CatRespuestas12 CatRespuestas12 { get; set; }
        public virtual CatRespuestas13 CatRespuestas13 { get; set; }
        public virtual CatRespuestas14 CatRespuestas14 { get; set; }
        public virtual CatRespuestas15 CatRespuestas15 { get; set; }
        public virtual CatRespuestas16 CatRespuestas16 { get; set; }
        public virtual CatRespuestas17 CatRespuestas17 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPersonal> tblPersonal { get; set; }
        public virtual CatRespuestas09 CatRespuestas09 { get; set; }
    }
}
