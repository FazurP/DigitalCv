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
    
    public partial class tblParticipacionInstitucionalInterna
    {
        public int id { get; set; }
        public Nullable<int> idCatProgramaEducativo { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public Nullable<int> idCatDocumento { get; set; }
        public Nullable<int> idCatTipoActividad { get; set; }
        public string strActividad { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public Nullable<System.DateTime> fechaTermino { get; set; }
    
        public virtual catDocumentos catDocumentos { get; set; }
        public virtual catProgramaEducativo catProgramaEducativo { get; set; }
        public virtual catTipoActividad catTipoActividad { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}
