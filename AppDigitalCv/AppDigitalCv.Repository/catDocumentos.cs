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
    
    public partial class catDocumentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public catDocumentos()
        {
            this.tblDocumentacionPersonal = new HashSet<tblDocumentacionPersonal>();
            this.tblPremiosDocente = new HashSet<tblPremiosDocente>();
            this.tblPortafolioPersonal = new HashSet<tblPortafolioPersonal>();
            this.tblParticipacionDocente = new HashSet<tblParticipacionDocente>();
            this.tblParticipacionInstitucionalExterna = new HashSet<tblParticipacionInstitucionalExterna>();
            this.tblParticipacionInstitucionalInterna = new HashSet<tblParticipacionInstitucionalInterna>();
        }
    
        public int idDocumento { get; set; }
        public string strDescripcion { get; set; }
        public string strObservacion { get; set; }
        public string strUrl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDocumentacionPersonal> tblDocumentacionPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPremiosDocente> tblPremiosDocente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPortafolioPersonal> tblPortafolioPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblParticipacionDocente> tblParticipacionDocente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblParticipacionInstitucionalExterna> tblParticipacionInstitucionalExterna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblParticipacionInstitucionalInterna> tblParticipacionInstitucionalInterna { get; set; }
    }
}
