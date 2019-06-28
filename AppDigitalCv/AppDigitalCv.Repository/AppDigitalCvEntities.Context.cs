﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bdGestionDocenteEntities : DbContext
    {
        public bdGestionDocenteEntities()
            : base("name=bdGestionDocenteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDatosContacto> tblDatosContacto { get; set; }
        public virtual DbSet<tblTelefono> tblTelefono { get; set; }
        public virtual DbSet<catAlergias> catAlergias { get; set; }
        public virtual DbSet<catArea> catArea { get; set; }
        public virtual DbSet<catAsociaciones> catAsociaciones { get; set; }
        public virtual DbSet<catCategoria> catCategoria { get; set; }
        public virtual DbSet<CatColonia> CatColonia { get; set; }
        public virtual DbSet<catCompetencias> catCompetencias { get; set; }
        public virtual DbSet<catCompetenciaTI> catCompetenciaTI { get; set; }
        public virtual DbSet<catCuerpoAcademico> catCuerpoAcademico { get; set; }
        public virtual DbSet<catDeporte> catDeporte { get; set; }
        public virtual DbSet<catDialecto> catDialecto { get; set; }
        public virtual DbSet<catDireccion> catDireccion { get; set; }
        public virtual DbSet<catEdificio> catEdificio { get; set; }
        public virtual DbSet<catEnfermedad> catEnfermedad { get; set; }
        public virtual DbSet<CatEstado> CatEstado { get; set; }
        public virtual DbSet<catEstadoCivil> catEstadoCivil { get; set; }
        public virtual DbSet<catFamiliar> catFamiliar { get; set; }
        public virtual DbSet<catFrecuencia> catFrecuencia { get; set; }
        public virtual DbSet<catIdioma> catIdioma { get; set; }
        public virtual DbSet<catInstitucionSuperior> catInstitucionSuperior { get; set; }
        public virtual DbSet<CatMunicipio> CatMunicipio { get; set; }
        public virtual DbSet<catNivelSalarial> catNivelSalarial { get; set; }
        public virtual DbSet<CatPais> CatPais { get; set; }
        public virtual DbSet<catParentesco> catParentesco { get; set; }
        public virtual DbSet<catProgramaEducativo> catProgramaEducativo { get; set; }
        public virtual DbSet<catRoles> catRoles { get; set; }
        public virtual DbSet<catSalarios> catSalarios { get; set; }
        public virtual DbSet<catStatus> catStatus { get; set; }
        public virtual DbSet<catTipoAlergias> catTipoAlergias { get; set; }
        public virtual DbSet<catTipoContrato> catTipoContrato { get; set; }
        public virtual DbSet<catTipoEmpresa> catTipoEmpresa { get; set; }
        public virtual DbSet<catTipoEstudio> catTipoEstudio { get; set; }
        public virtual DbSet<catTipoSangre> catTipoSangre { get; set; }
        public virtual DbSet<catUnidadesAcademicas> catUnidadesAcademicas { get; set; }
        public virtual DbSet<catUsuarios> catUsuarios { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblAlergiasPersonal> tblAlergiasPersonal { get; set; }
        public virtual DbSet<tblCompetenciasConocimientosPersonal> tblCompetenciasConocimientosPersonal { get; set; }
        public virtual DbSet<tblCompetenciasTIPersonal> tblCompetenciasTIPersonal { get; set; }
        public virtual DbSet<tblDatosLaboralesAdministrativos> tblDatosLaboralesAdministrativos { get; set; }
        public virtual DbSet<tblDatosLaboralesDocente> tblDatosLaboralesDocente { get; set; }
        public virtual DbSet<tblDeportePersonal> tblDeportePersonal { get; set; }
        public virtual DbSet<tblEmergencia> tblEmergencia { get; set; }
        public virtual DbSet<tblEnfermedadPersonal> tblEnfermedadPersonal { get; set; }
        public virtual DbSet<tblIdiomaDialectoPersonal> tblIdiomaDialectoPersonal { get; set; }
        public virtual DbSet<tblPasatiempo> tblPasatiempo { get; set; }
        public virtual DbSet<tblPersonalAsociaciones> tblPersonalAsociaciones { get; set; }
        public virtual DbSet<tblPremiosDocente> tblPremiosDocente { get; set; }
        public virtual DbSet<tblUsuarioRol> tblUsuarioRol { get; set; }
        public virtual DbSet<tblPersonal> tblPersonal { get; set; }
        public virtual DbSet<catCurso> catCurso { get; set; }
        public virtual DbSet<tblCursos> tblCursos { get; set; }
        public virtual DbSet<tblDocumentacionPersonal> tblDocumentacionPersonal { get; set; }
        public virtual DbSet<catDocumentos> catDocumentos { get; set; }
        public virtual DbSet<tblPortafolioPersonal> tblPortafolioPersonal { get; set; }
        public virtual DbSet<catPeriodo> catPeriodo { get; set; }
        public virtual DbSet<catTipoActividad> catTipoActividad { get; set; }
        public virtual DbSet<tblParticipacionDocente> tblParticipacionDocente { get; set; }
        public virtual DbSet<tblParticipacionInstitucionalExterna> tblParticipacionInstitucionalExterna { get; set; }
        public virtual DbSet<tblParticipacionInstitucionalInterna> tblParticipacionInstitucionalInterna { get; set; }
        public virtual DbSet<tblExperienciaLaboralExterna> tblExperienciaLaboralExterna { get; set; }
        public virtual DbSet<tblExperienciaLaboralInterna> tblExperienciaLaboralInterna { get; set; }
        public virtual DbSet<tblInformeTecnico> tblInformeTecnico { get; set; }
        public virtual DbSet<tblCapituloLibro> tblCapituloLibro { get; set; }
        public virtual DbSet<tblProgresoProdep> tblProgresoProdep { get; set; }
    }
}
