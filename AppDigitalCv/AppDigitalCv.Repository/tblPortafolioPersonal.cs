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
    
    public partial class tblPortafolioPersonal
    {
        public int id { get; set; }
        public int idDocumento { get; set; }
        public int idPersonal { get; set; }
        public string strPeriodo { get; set; }
        public string strAño { get; set; }
        public string strTipo { get; set; }
        public string strUrl { get; set; }
    
        public virtual catDocumentos catDocumentos { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}
