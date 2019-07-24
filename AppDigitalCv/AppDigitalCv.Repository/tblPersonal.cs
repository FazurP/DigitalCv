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
    
    public partial class tblPersonal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPersonal()
        {
            this.catFamiliar = new HashSet<catFamiliar>();
            this.tblAlergiasPersonal = new HashSet<tblAlergiasPersonal>();
            this.tblCompetenciasConocimientosPersonal = new HashSet<tblCompetenciasConocimientosPersonal>();
            this.tblCompetenciasTIPersonal = new HashSet<tblCompetenciasTIPersonal>();
            this.tblDatosContacto = new HashSet<tblDatosContacto>();
            this.tblDatosLaboralesAdministrativos = new HashSet<tblDatosLaboralesAdministrativos>();
            this.tblDatosLaboralesDocente = new HashSet<tblDatosLaboralesDocente>();
            this.tblDeportePersonal = new HashSet<tblDeportePersonal>();
            this.tblEmergencia = new HashSet<tblEmergencia>();
            this.tblEnfermedadPersonal = new HashSet<tblEnfermedadPersonal>();
            this.tblIdiomaDialectoPersonal = new HashSet<tblIdiomaDialectoPersonal>();
            this.tblPasatiempo = new HashSet<tblPasatiempo>();
            this.tblPersonalAsociaciones = new HashSet<tblPersonalAsociaciones>();
            this.tblPremiosDocente = new HashSet<tblPremiosDocente>();
            this.tblTelefono = new HashSet<tblTelefono>();
            this.tblCursos = new HashSet<tblCursos>();
            this.tblDocumentacionPersonal = new HashSet<tblDocumentacionPersonal>();
            this.tblPortafolioPersonal = new HashSet<tblPortafolioPersonal>();
            this.tblParticipacionDocente = new HashSet<tblParticipacionDocente>();
            this.tblParticipacionInstitucionalExterna = new HashSet<tblParticipacionInstitucionalExterna>();
            this.tblParticipacionInstitucionalInterna = new HashSet<tblParticipacionInstitucionalInterna>();
            this.tblExperienciaLaboralExterna = new HashSet<tblExperienciaLaboralExterna>();
            this.tblExperienciaLaboralInterna = new HashSet<tblExperienciaLaboralInterna>();
            this.tblCapituloLibro = new HashSet<tblCapituloLibro>();
            this.tblProgresoProdep = new HashSet<tblProgresoProdep>();
            this.tblInformeTecnico = new HashSet<tblInformeTecnico>();
            this.tblLibro = new HashSet<tblLibro>();
            this.tblManualOperacion = new HashSet<tblManualOperacion>();
            this.tblProductividadInnovadora = new HashSet<tblProductividadInnovadora>();
            this.tblProduccionArtistica = new HashSet<tblProduccionArtistica>();
            this.tblPrototipo = new HashSet<tblPrototipo>();
            this.tblProyectoInvestigacionAplicadaDesarrolloTecnologico = new HashSet<tblProyectoInvestigacionAplicadaDesarrolloTecnologico>();
            this.tblDireccionIndividualizada = new HashSet<tblDireccionIndividualizada>();
            this.tblEstadiaEmpresa = new HashSet<tblEstadiaEmpresa>();
            this.tblTutoria = new HashSet<tblTutoria>();
        }
    
        public int idPersonal { get; set; }
        public string strNombre { get; set; }
        public string strApellidoPaterno { get; set; }
        public string strApellidoMaterno { get; set; }
        public string strCurp { get; set; }
        public string strRfc { get; set; }
        public string archivoRfc { get; set; }
        public string strHomoclave { get; set; }
        public Nullable<System.DateTime> dteFechaNacimiento { get; set; }
        public string strLogros { get; set; }
        public string strUrlFoto { get; set; }
        public string strUrlCurp { get; set; }
        public string strUrlRfc { get; set; }
        public string strGenero { get; set; }
        public Nullable<int> idEstadoCivil { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public Nullable<int> idTipoSangre { get; set; }
        public Nullable<int> idDireccion { get; set; }
    
        public virtual catDireccion catDireccion { get; set; }
        public virtual catEstadoCivil catEstadoCivil { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<catFamiliar> catFamiliar { get; set; }
        public virtual catTipoSangre catTipoSangre { get; set; }
        public virtual catUsuarios catUsuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAlergiasPersonal> tblAlergiasPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCompetenciasConocimientosPersonal> tblCompetenciasConocimientosPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCompetenciasTIPersonal> tblCompetenciasTIPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDatosContacto> tblDatosContacto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDatosLaboralesAdministrativos> tblDatosLaboralesAdministrativos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDatosLaboralesDocente> tblDatosLaboralesDocente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDeportePersonal> tblDeportePersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmergencia> tblEmergencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEnfermedadPersonal> tblEnfermedadPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIdiomaDialectoPersonal> tblIdiomaDialectoPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPasatiempo> tblPasatiempo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPersonalAsociaciones> tblPersonalAsociaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPremiosDocente> tblPremiosDocente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTelefono> tblTelefono { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCursos> tblCursos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDocumentacionPersonal> tblDocumentacionPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPortafolioPersonal> tblPortafolioPersonal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblParticipacionDocente> tblParticipacionDocente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblParticipacionInstitucionalExterna> tblParticipacionInstitucionalExterna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblParticipacionInstitucionalInterna> tblParticipacionInstitucionalInterna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblExperienciaLaboralExterna> tblExperienciaLaboralExterna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblExperienciaLaboralInterna> tblExperienciaLaboralInterna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCapituloLibro> tblCapituloLibro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProgresoProdep> tblProgresoProdep { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblInformeTecnico> tblInformeTecnico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblLibro> tblLibro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblManualOperacion> tblManualOperacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProductividadInnovadora> tblProductividadInnovadora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduccionArtistica> tblProduccionArtistica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPrototipo> tblPrototipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProyectoInvestigacionAplicadaDesarrolloTecnologico> tblProyectoInvestigacionAplicadaDesarrolloTecnologico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDireccionIndividualizada> tblDireccionIndividualizada { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEstadiaEmpresa> tblEstadiaEmpresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTutoria> tblTutoria { get; set; }
    }
}
