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
    
    public partial class TblFavoritos
    {
        public int IdFavoritos { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdOrganizacion { get; set; }
    
        public virtual Organizaciones_Salud Organizaciones_Salud { get; set; }
        public virtual TblUsuario TblUsuario { get; set; }
    }
}
