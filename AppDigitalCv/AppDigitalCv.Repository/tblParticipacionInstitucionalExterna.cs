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
    
    public partial class tblParticipacionInstitucionalExterna
    {
        public int id { get; set; }
        public Nullable<int> idCatInstitucionSuperior { get; set; }
        public Nullable<int> idCatPeriodo { get; set; }
        public Nullable<int> idCatDocumento { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public string strActividad { get; set; }
        public Nullable<System.DateTime> dteFechaInicio { get; set; }
        public Nullable<System.DateTime> dteFechaTermino { get; set; }
    
        public virtual catDocumentos catDocumentos { get; set; }
        public virtual catInstitucionSuperior catInstitucionSuperior { get; set; }
        public virtual catPeriodo catPeriodo { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}