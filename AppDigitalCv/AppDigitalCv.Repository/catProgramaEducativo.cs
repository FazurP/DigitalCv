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
    
    public partial class catProgramaEducativo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public catProgramaEducativo()
        {
            this.tblDatosLaboralesDocente = new HashSet<tblDatosLaboralesDocente>();
            this.tblParticipacionInstitucionalInterna = new HashSet<tblParticipacionInstitucionalInterna>();
        }
    
        public int idProgramaEducativo { get; set; }
        public string strDescripcion { get; set; }
        public string strObservacion { get; set; }
        public int idInstitucionSuperior { get; set; }
        public int idTipoEstudio { get; set; }
    
        public virtual catInstitucionSuperior catInstitucionSuperior { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDatosLaboralesDocente> tblDatosLaboralesDocente { get; set; }
        public virtual catTipoEstudio catTipoEstudio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblParticipacionInstitucionalInterna> tblParticipacionInstitucionalInterna { get; set; }
    }
}
