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
    
    public partial class tblProyectoInvestigacionAplicadaDesarrolloTecnologico
    {
        public int id { get; set; }
        public Nullable<int> idDocumento { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public string strTituloProyecto { get; set; }
        public string strNombrePatrocinador { get; set; }
        public string dteFechaInicio { get; set; }
        public string dteFechaTermino { get; set; }
        public string strTipoPatrocinador { get; set; }
        public string strInvestigadoresParticipantes { get; set; }
        public string strAlumnosParticipantes { get; set; }
        public string strActividadesRealizadas { get; set; }
        public string strConvocatoria { get; set; }
        public Nullable<bool> bitProyectoTecnologico { get; set; }
    
        public virtual catDocumentos catDocumentos { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}
