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
    
    public partial class tblEmergencia
    {
        public int idEmergencia { get; set; }
        public string strNombre { get; set; }
        public string strTelefono { get; set; }
        public string strDireccion { get; set; }
        public int idParentesco { get; set; }
        public int idPersonal { get; set; }
    
        public virtual catParentesco catParentesco { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}
