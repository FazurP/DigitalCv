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
    
    public partial class TblMemoriasExtenso
    {
        public int id { get; set; }
        public string strTituloPresentacion { get; set; }
        public string strNombreCongresoPresento { get; set; }
        public Nullable<int> idEstado { get; set; }
        public Nullable<System.DateTime> dteFechaPublicacion { get; set; }
        public Nullable<int> idPersonal { get; set; }
    
        public virtual CatEstado CatEstado { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}
