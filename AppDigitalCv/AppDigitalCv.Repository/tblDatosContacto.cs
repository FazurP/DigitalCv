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
    
    public partial class tblDatosContacto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDatosContacto()
        {
            this.tblTelefono = new HashSet<tblTelefono>();
        }
    
        public int idDatosContacto { get; set; }
        public string strEmailPersonal1 { get; set; }
        public string strNombreFacebook { get; set; }
        public string strNombreTwitter { get; set; }
        public string strIdTelegram { get; set; }
        public string strNombre { get; set; }
        public string strApellidoPaterno { get; set; }
        public string strApellidoMaterno { get; set; }
        public string strDireccion { get; set; }
        public int idPersonal { get; set; }
        public Nullable<bool> bitContactoEmergencia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTelefono> tblTelefono { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }

    }
}
