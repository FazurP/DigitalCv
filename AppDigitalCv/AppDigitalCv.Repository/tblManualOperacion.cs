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
    
    public partial class tblManualOperacion
    {
        public int id { get; set; }
        public Nullable<int> idPais { get; set; }
        public Nullable<int> idStatus { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public string strNombre { get; set; }
        public string strDescripcion { get; set; }
        public string strInstitucionBeneficiaria { get; set; }
        public Nullable<System.DateTime> dteFechaPublicacion { get; set; }
    
        public virtual CatPais CatPais { get; set; }
        public virtual catStatus catStatus { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}