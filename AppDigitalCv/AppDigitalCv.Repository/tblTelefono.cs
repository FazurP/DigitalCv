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
    
    public partial class tblTelefono
    {
        public int idTelefono { get; set; }
        public string strTelefonoCelular { get; set; }
        public string strTelefonoCasa { get; set; }
        public string strTelefonoRecados { get; set; }
        public Nullable<int> idDatoContacto { get; set; }
    
        public virtual tblDatosContacto tblDatosContacto { get; set; }
    }
}
