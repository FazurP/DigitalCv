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
    
    public partial class CatRespuestas06
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatRespuestas06()
        {
            this.TblEncuesta = new HashSet<TblEncuesta>();
        }
    
        public int id { get; set; }
        public Nullable<bool> bitAlergico { get; set; }
        public Nullable<int> idMedicamento { get; set; }
        public Nullable<int> idSustancia { get; set; }
        public Nullable<int> idAlimento { get; set; }
    
        public virtual CatAlergiaAlimento CatAlergiaAlimento { get; set; }
        public virtual CatAlergiaMedicamento CatAlergiaMedicamento { get; set; }
        public virtual CatAlergiaSustancia CatAlergiaSustancia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblEncuesta> TblEncuesta { get; set; }
    }
}
