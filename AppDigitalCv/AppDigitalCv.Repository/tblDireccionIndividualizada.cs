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
    
    public partial class tblDireccionIndividualizada
    {
        public int id { get; set; }
        public Nullable<int> idPersonal { get; set; }
        public Nullable<int> idStatus { get; set; }
        public Nullable<int> idTipoEstudio { get; set; }
        public Nullable<int> idInstitucionSuperior { get; set; }
        public string strTituloTesis { get; set; }
        public Nullable<System.DateTime> dteFechaInicio { get; set; }
        public Nullable<System.DateTime> dteFechaTermino { get; set; }
        public string strNumeroAlumnos { get; set; }
        public string strEstadoDireccionIndividualizada { get; set; }
        public Nullable<bool> bitConsideraCurriculum { get; set; }
    
        public virtual catInstitucionSuperior catInstitucionSuperior { get; set; }
        public virtual catStatus catStatus { get; set; }
        public virtual catTipoEstudio catTipoEstudio { get; set; }
        public virtual tblPersonal tblPersonal { get; set; }
    }
}