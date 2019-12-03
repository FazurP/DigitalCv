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
    
        public virtual DbSet<catAlergias> catAlergias { get; set; }
        public virtual DbSet<catArea> catArea { get; set; }
        public virtual DbSet<catCategoria> catCategoria { get; set; }
        public virtual DbSet<CatColonia> CatColonia { get; set; }
        public virtual DbSet<catCompetenciaTI> catCompetenciaTI { get; set; }
        public virtual DbSet<catCuerpoAcademico> catCuerpoAcademico { get; set; }
        public virtual DbSet<catDeporte> catDeporte { get; set; }
        public virtual DbSet<catDireccion> catDireccion { get; set; }
        public virtual DbSet<catEdificio> catEdificio { get; set; }
        public virtual DbSet<catEnfermedad> catEnfermedad { get; set; }
        public virtual DbSet<CatEstado> CatEstado { get; set; }
        public virtual DbSet<catEstadoCivil> catEstadoCivil { get; set; }
        public virtual DbSet<catFrecuencia> catFrecuencia { get; set; }
        public virtual DbSet<catIdioma> catIdioma { get; set; }
        public virtual DbSet<catInstitucionSuperior> catInstitucionSuperior { get; set; }
        public virtual DbSet<CatMunicipio> CatMunicipio { get; set; }
        public virtual DbSet<catNivelSalarial> catNivelSalarial { get; set; }
        public virtual DbSet<CatPais> CatPais { get; set; }
        public virtual DbSet<catProgramaEducativo> catProgramaEducativo { get; set; }
        public virtual DbSet<catRoles> catRoles { get; set; }
        public virtual DbSet<catSalarios> catSalarios { get; set; }
        public virtual DbSet<catStatus> catStatus { get; set; }
        public virtual DbSet<catTipoAlergias> catTipoAlergias { get; set; }
        public virtual DbSet<catTipoContrato> catTipoContrato { get; set; }
        public virtual DbSet<catTipoEstudio> catTipoEstudio { get; set; }
        public virtual DbSet<catTipoSangre> catTipoSangre { get; set; }
        public virtual DbSet<catUnidadesAcademicas> catUnidadesAcademicas { get; set; }
        public virtual DbSet<catUsuarios> catUsuarios { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblAlergiasPersonal> tblAlergiasPersonal { get; set; }
        public virtual DbSet<tblCompetenciasTIPersonal> tblCompetenciasTIPersonal { get; set; }
        public virtual DbSet<tblDatosLaboralesAdministrativos> tblDatosLaboralesAdministrativos { get; set; }
        public virtual DbSet<tblDatosLaboralesDocente> tblDatosLaboralesDocente { get; set; }
        public virtual DbSet<tblDeportePersonal> tblDeportePersonal { get; set; }
        public virtual DbSet<tblEmergencia> tblEmergencia { get; set; }
        public virtual DbSet<tblEnfermedadPersonal> tblEnfermedadPersonal { get; set; }
        public virtual DbSet<tblPersonalAsociaciones> tblPersonalAsociaciones { get; set; }
        public virtual DbSet<tblUsuarioRol> tblUsuarioRol { get; set; }
        public virtual DbSet<catCurso> catCurso { get; set; }
        public virtual DbSet<tblCursos> tblCursos { get; set; }
        public virtual DbSet<catDocumentos> catDocumentos { get; set; }
        public virtual DbSet<tblPortafolioPersonal> tblPortafolioPersonal { get; set; }
        public virtual DbSet<catPeriodo> catPeriodo { get; set; }
        public virtual DbSet<catTipoActividad> catTipoActividad { get; set; }
        public virtual DbSet<tblParticipacionDocente> tblParticipacionDocente { get; set; }
        public virtual DbSet<tblParticipacionInstitucionalExterna> tblParticipacionInstitucionalExterna { get; set; }
        public virtual DbSet<tblParticipacionInstitucionalInterna> tblParticipacionInstitucionalInterna { get; set; }
        public virtual DbSet<tblExperienciaLaboralExterna> tblExperienciaLaboralExterna { get; set; }
        public virtual DbSet<tblExperienciaLaboralInterna> tblExperienciaLaboralInterna { get; set; }
        public virtual DbSet<tblCapituloLibro> tblCapituloLibro { get; set; }
        public virtual DbSet<tblProgresoProdep> tblProgresoProdep { get; set; }
        public virtual DbSet<tblInformeTecnico> tblInformeTecnico { get; set; }
        public virtual DbSet<tblLibro> tblLibro { get; set; }
        public virtual DbSet<tblManualOperacion> tblManualOperacion { get; set; }
        public virtual DbSet<tblProductividadInnovadora> tblProductividadInnovadora { get; set; }
        public virtual DbSet<catProduccionArtistica> catProduccionArtistica { get; set; }
        public virtual DbSet<tblProduccionArtistica> tblProduccionArtistica { get; set; }
        public virtual DbSet<tblPrototipo> tblPrototipo { get; set; }
        public virtual DbSet<tblProyectoInvestigacionAplicadaDesarrolloTecnologico> tblProyectoInvestigacionAplicadaDesarrolloTecnologico { get; set; }
        public virtual DbSet<tblDireccionIndividualizada> tblDireccionIndividualizada { get; set; }
        public virtual DbSet<catTipoProducto> catTipoProducto { get; set; }
        public virtual DbSet<tblEstadiaEmpresa> tblEstadiaEmpresa { get; set; }
        public virtual DbSet<tblTutoria> tblTutoria { get; set; }
        public virtual DbSet<administradores> administradores { get; set; }
        public virtual DbSet<administrar> administrar { get; set; }
        public virtual DbSet<Organizaciones_Salud> Organizaciones_Salud { get; set; }
        public virtual DbSet<TblDireccion> TblDireccion { get; set; }
        public virtual DbSet<TblFavoritos> TblFavoritos { get; set; }
        public virtual DbSet<TblUsuario> TblUsuario { get; set; }
        public virtual DbSet<CatCapacitacionesCompetenciasProfesionales> CatCapacitacionesCompetenciasProfesionales { get; set; }
        public virtual DbSet<CatCategoriaProfesor> CatCategoriaProfesor { get; set; }
        public virtual DbSet<CatFuentaFinaciamientoMaestria> CatFuentaFinaciamientoMaestria { get; set; }
        public virtual DbSet<CatFuenteFinanciamientoDoctorado> CatFuenteFinanciamientoDoctorado { get; set; }
        public virtual DbSet<CatInstitucionAcreditaBachillerato> CatInstitucionAcreditaBachillerato { get; set; }
        public virtual DbSet<CatInstitucionAcreditaCapacitacionProfesional> CatInstitucionAcreditaCapacitacionProfesional { get; set; }
        public virtual DbSet<CatInstitucionAcreditaDoctorado> CatInstitucionAcreditaDoctorado { get; set; }
        public virtual DbSet<CatInstitucionAcreditaLicenciatura> CatInstitucionAcreditaLicenciatura { get; set; }
        public virtual DbSet<CatInstitucionAcreditaMaestria> CatInstitucionAcreditaMaestria { get; set; }
        public virtual DbSet<CatIntitucionAcreditaOtra> CatIntitucionAcreditaOtra { get; set; }
        public virtual DbSet<CatStatusDoctorado> CatStatusDoctorado { get; set; }
        public virtual DbSet<CatStatusLicenciatura> CatStatusLicenciatura { get; set; }
        public virtual DbSet<CatStatusMaestria> CatStatusMaestria { get; set; }
        public virtual DbSet<TblBachillerato> TblBachillerato { get; set; }
        public virtual DbSet<TblCapacitacionCompetenciasProfesionales> TblCapacitacionCompetenciasProfesionales { get; set; }
        public virtual DbSet<TblDatosLaborales> TblDatosLaborales { get; set; }
        public virtual DbSet<TblDoctorado> TblDoctorado { get; set; }
        public virtual DbSet<TblLicenciaturaIngenieria> TblLicenciaturaIngenieria { get; set; }
        public virtual DbSet<TblMaetria> TblMaetria { get; set; }
        public virtual DbSet<TblMemoriasExtenso> TblMemoriasExtenso { get; set; }
        public virtual DbSet<TblOtraCapacitacion> TblOtraCapacitacion { get; set; }
        public virtual DbSet<CatTipoUsuario> CatTipoUsuario { get; set; }
        public virtual DbSet<tblDatosContacto> tblDatosContacto { get; set; }
        public virtual DbSet<tblTelefono> tblTelefono { get; set; }
        public virtual DbSet<tblPremiosDocente> tblPremiosDocente { get; set; }
        public virtual DbSet<catAsociaciones> catAsociaciones { get; set; }
        public virtual DbSet<catFamiliar> catFamiliar { get; set; }
        public virtual DbSet<catParentesco> catParentesco { get; set; }
        public virtual DbSet<CatNacionalidad> CatNacionalidad { get; set; }
        public virtual DbSet<tblPersonal> tblPersonal { get; set; }
        public virtual DbSet<CatHobbies> CatHobbies { get; set; }
        public virtual DbSet<tblHobbies> tblHobbies { get; set; }
        public virtual DbSet<CatNivelConocimiento> CatNivelConocimiento { get; set; }
        public virtual DbSet<TblIdioma> TblIdioma { get; set; }
        public virtual DbSet<CatLenguas> CatLenguas { get; set; }
        public virtual DbSet<TblLenguas> TblLenguas { get; set; }
        public virtual DbSet<CatTipoDocumento> CatTipoDocumento { get; set; }
        public virtual DbSet<tblDocumentacionPersonal> tblDocumentacionPersonal { get; set; }
        public virtual DbSet<tblCompetenciasConocimientosPersonal> tblCompetenciasConocimientosPersonal { get; set; }
        public virtual DbSet<CatActividadesFisicas> CatActividadesFisicas { get; set; }
        public virtual DbSet<CatAlergiaAlimento> CatAlergiaAlimento { get; set; }
        public virtual DbSet<CatAlergiaMedicamento> CatAlergiaMedicamento { get; set; }
        public virtual DbSet<CatAlergiaSustancia> CatAlergiaSustancia { get; set; }
        public virtual DbSet<CatEnfermades> CatEnfermades { get; set; }
        public virtual DbSet<CatEnfermedadesExantemática> CatEnfermedadesExantemática { get; set; }
        public virtual DbSet<CatFumador> CatFumador { get; set; }
        public virtual DbSet<CatGrupoSanguineo> CatGrupoSanguineo { get; set; }
        public virtual DbSet<CatLesionArticulaciones> CatLesionArticulaciones { get; set; }
        public virtual DbSet<CatLesionHuesos> CatLesionHuesos { get; set; }
        public virtual DbSet<CatLesionLigamentos> CatLesionLigamentos { get; set; }
        public virtual DbSet<CatOpcionesRespuesta04> CatOpcionesRespuesta04 { get; set; }
        public virtual DbSet<CatRespuestas01> CatRespuestas01 { get; set; }
        public virtual DbSet<CatRespuestas02> CatRespuestas02 { get; set; }
        public virtual DbSet<CatRespuestas03> CatRespuestas03 { get; set; }
        public virtual DbSet<CatRespuestas04> CatRespuestas04 { get; set; }
        public virtual DbSet<CatRespuestas05> CatRespuestas05 { get; set; }
        public virtual DbSet<CatRespuestas06> CatRespuestas06 { get; set; }
        public virtual DbSet<CatRespuestas07> CatRespuestas07 { get; set; }
        public virtual DbSet<CatRespuestas08> CatRespuestas08 { get; set; }
        public virtual DbSet<CatRespuestas09> CatRespuestas09 { get; set; }
        public virtual DbSet<CatRespuestas10> CatRespuestas10 { get; set; }
        public virtual DbSet<CatRespuestas11> CatRespuestas11 { get; set; }
        public virtual DbSet<CatRespuestas12> CatRespuestas12 { get; set; }
        public virtual DbSet<CatRespuestas13> CatRespuestas13 { get; set; }
        public virtual DbSet<CatRespuestas14> CatRespuestas14 { get; set; }
        public virtual DbSet<CatRespuestas15> CatRespuestas15 { get; set; }
        public virtual DbSet<CatRespuestas16> CatRespuestas16 { get; set; }
        public virtual DbSet<CatRespuestas17> CatRespuestas17 { get; set; }
        public virtual DbSet<CatRH> CatRH { get; set; }
        public virtual DbSet<CatTratamiento> CatTratamiento { get; set; }
        public virtual DbSet<TblEncuesta> TblEncuesta { get; set; }
    }
}
