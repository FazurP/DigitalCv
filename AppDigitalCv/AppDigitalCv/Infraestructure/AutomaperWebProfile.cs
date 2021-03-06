﻿using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDigitalCv.Infraestructure
{
    public class AutomaperWebProfile:AutoMapper.Profile
    {

        public AutomaperWebProfile()
        {
            //Personal
            CreateMap<PersonalDomainModel, PersonalVM>();
            CreateMap<PersonalVM, PersonalDomainModel>();

            //Documentos
            CreateMap<DocumentoPersonalVM, DocumentoPersonalDomainModel>();
            CreateMap<DocumentoPersonalDomainModel, DocumentoPersonalVM>();

            //Cuentas
            CreateMap<AccountViewModel, AccountDomainModel>();
            CreateMap<AccountDomainModel, AccountViewModel>();

            //Direccion
            CreateMap<DireccionDomainModel, DireccionVM>();
            CreateMap<DireccionVM, DireccionDomainModel>();

            //Pais
            CreateMap<PaisDomainModel, PaisVM>();
            CreateMap<PaisVM, PaisDomainModel>();

            //Estado
            CreateMap<EstadoDomainModel, EstadoVM>();
            CreateMap<EstadoVM, EstadoDomainModel>();

            //Municipio
            CreateMap<MunicipioDomainModel, MunicipioVM>();
            CreateMap<MunicipioVM, MunicipioDomainModel>();

            //Colonia
            CreateMap<ColoniaDomainModel, ColoniaVM>();
            CreateMap<ColoniaVM, ColoniaDomainModel>();

            //Datos contacto
            CreateMap<DatosContactoVM, DatosContactoDomainModel>();
            CreateMap<DatosContactoDomainModel, DatosContactoVM>();

            //Estado Civil
            CreateMap<EstadoCivilVM, EstadoCivilDomainModel>();
            CreateMap<EstadoCivilDomainModel, EstadoCivilVM>();

            //Idioma
            CreateMap<IdiomaVM, IdiomaDomainModel>();
            CreateMap<IdiomaDomainModel, IdiomaVM>();

            //Dialecto
            CreateMap<DialectoVM, DialectoDomainModel>();
            CreateMap<DialectoDomainModel, DialectoVM>();

            //IdiomaDialecto
            CreateMap<IdiomaDialectoVM, IdiomaDialectoDomainModel>();
            CreateMap<IdiomaDialectoDomainModel, IdiomaDialectoVM>();
            //Estado de Salud
            CreateMap<EstadoSaludDomainModel, EstadoSaludVM>();
            CreateMap<EstadoSaludVM, EstadoSaludDomainModel>();
            //Familiar
            CreateMap<ParentescoVM, FamiliarDomainModel>();
            CreateMap<FamiliarDomainModel, ParentescoVM>();
            //Premios Docente
            CreateMap<PremiosDocenteDomainModel, PremiosDocenteVM>();
            CreateMap<PremiosDocenteVM, PremiosDocenteDomainModel>();
            //Dcoumentos
            CreateMap<DocumentosDomainModel, DocumentosVM>();
            CreateMap<DocumentosVM, DocumentosDomainModel>();
            //Asocianoes
            CreateMap<AsociacionesDomainModel, AsociacionesVM>();
            CreateMap<AsociacionesVM, AsociacionesDomainModel>();
            //Tipo de Empresa
            CreateMap<TipoEmpresaDomainModel, TipoEmpresaVM>();
            CreateMap<TipoEmpresaVM, TipoEmpresaDomainModel>();
            //personal asociaciones
            CreateMap<PersonalAsociacionesVM, PersonalAsociacionesDomainModel>();
            CreateMap<PersonalAsociacionesDomainModel, PersonalAsociacionesVM>();
            ///Familiares 
            CreateMap<FamiliaresVM, FamiliaresDomainModel>();
            CreateMap<FamiliaresDomainModel, FamiliaresVM>();
            //Competencias TI
            CreateMap<CompetenciasTiVM, CompetenciasTiDomainModel>();
            CreateMap<CompetenciasTiDomainModel, CompetenciasTiVM>();
            //Competencia TI
            CreateMap<CompetenciaTiVM, CompetenciaTiDomainModel>();
            CreateMap<CompetenciaTiDomainModel, CompetenciaTiVM>();
            //Emergencias
            CreateMap<EmergenciaViewModel, EmergenciaDomianModel>();
            CreateMap<EmergenciaDomianModel, EmergenciaViewModel>();
            //Deporte
            CreateMap<DeporteVM, DeporteDomainModel>();
            CreateMap<DeporteDomainModel, DeporteVM>();
            //frecuencia
            CreateMap<FrecuenciaDomainModel, FrecuenciaVM>();
            CreateMap<FrecuenciaVM, FrecuenciaDomainModel>();
            //pasatiempo
            CreateMap<PasatiempoVM, PasatiempoDomainModel>();
            CreateMap<PasatiempoDomainModel, PasatiempoVM>();
            //Deporte Personal
            CreateMap<DeportePersonalDomainModel, DeportePersonalVM>();
            CreateMap<DeportePersonalVM, DeportePersonalDomainModel>();
            //Alergias
            CreateMap<AlergiasVM, AlergiasDomainModel>();
            CreateMap<AlergiasDomainModel, AlergiasVM>();
            //Alergias Personal
            CreateMap<AlergiasPersonalVM, AlergiasPersonalDomainModel>();
            CreateMap<AlergiasPersonalDomainModel, AlergiasPersonalVM>();
            //Competencias
            CreateMap<CompetenciasVM, CompetenciasDomainModel>();
            CreateMap<CompetenciasDomainModel, CompetenciasVM>();
            //Competencias Personales
            CreateMap<CompetenciasPersonalVM, CompetenciasPersonalDomainModel>();
            CreateMap<CompetenciasPersonalDomainModel, CompetenciasPersonalVM>();

            //Area
            CreateMap<AreaVM, AreaDomainModel>();
            CreateMap<AreaDomainModel, AreaVM>();
            //Nivel Salarial
            CreateMap<NivelSalarialVM, NivelSalarialDomainModel>();
            CreateMap<NivelSalarialDomainModel, NivelSalarialVM>();
            //Salarios
            CreateMap<SalariosVM, SalariosDomainModel>();
            CreateMap<SalariosDomainModel, SalariosVM>();
            //Categoria
            CreateMap<CategoriaVM, CategoriaDomainModel>();
            CreateMap<CategoriaDomainModel, CategoriaVM>();
            //Tipo de Contrato
            CreateMap<TipoContratoVM, TipoContratoDomainModel>();
            CreateMap<TipoContratoDomainModel, TipoContratoVM>();
            //Cuerpo Academico
            CreateMap<CuerpoAcademicoVM, CuerpoAcademicoDomainModel>();
            CreateMap<CuerpoAcademicoDomainModel, CuerpoAcademicoVM>();
            //Edificio
            CreateMap<EdificioVM, EdificioDomainModel>();
            CreateMap<EdificioDomainModel, EdificioVM>();
            //Unidades Academicas
            CreateMap<UnidadesAcademicasVM, UnidadesAcademicasDomainModel>();
            CreateMap<UnidadesAcademicasDomainModel, UnidadesAcademicasVM>();
            //Programa Educativo
            CreateMap<ProgramaEducativoVM, ProgramaEducativoDomainModel>();
            CreateMap<ProgramaEducativoDomainModel, ProgramaEducativoVM>();
            //Institucion Superior
            CreateMap<InstitucionSuperiorVM, InstitucionSuperiorDomainModel>();
            CreateMap<InstitucionSuperiorDomainModel, InstitucionSuperiorVM>();
            //Tipo de Estudio
            CreateMap<TipoEstudioVM, TipoEstudioDomainModel>();
            CreateMap<TipoEstudioDomainModel, TipoEstudioVM>();
            //Datos Laborales Docente
            CreateMap<DatosLaboralesDocenteVM, DatosLaboralesDocenteDomainModel>();
            CreateMap<DatosLaboralesDocenteDomainModel, DatosLaboralesDocenteVM>();
            //Datos Laborales Administrativos
            CreateMap<DatosLaboralesAdministrativosVM, DatosLaboralesAdministrativosDomainModel>();
            CreateMap<DatosLaboralesAdministrativosDomainModel, DatosLaboralesAdministrativosVM>();


            //Curso
            CreateMap<CursoDomainModel, CursoVM>();
            CreateMap<CursoVM, CursoDomainModel>();
            //cursos
            CreateMap<CursosDomainModel, CursosVM>();
            CreateMap<CursosVM, CursosDomainModel>();
            //Institucion SUperior
            CreateMap<InstitucionSuperiorDomainModel, InstitucionSuperiorVM>();
            CreateMap<InstitucionSuperiorVM, InstitucionSuperiorDomainModel>();


            //DocumentacionPersonal
            CreateMap<DocumentacionPersonalVM, DocumentacionPersonalDomainModel>();
            CreateMap<DocumentacionPersonalDomainModel, DocumentacionPersonalVM>();
            //NumeroLicenciaManejo
            CreateMap<NumeroLicenciaManejoVM, NumeroLicenciaManejoDomainModel>();
            CreateMap<NumeroLicenciaManejoDomainModel, NumeroLicenciaManejoVM>();
            //NumeroPasaporte
            CreateMap<NumeroPasaporteVM, NumeroPasaporteDomainModel>();
            CreateMap<NumeroPasaporteDomainModel, NumeroPasaporteVM>();
            //NumeroVisaUSA
            CreateMap<NumeroVisaUsaVM, NumeroVisaUsaDomainModel>();
            CreateMap<NumeroVisaUsaDomainModel, NumeroVisaUsaVM>();
            //NumeroVisaCanada
            CreateMap<NumeroVisaCanadaVM, NumeroVisaCanadaDomainModel>();
            CreateMap<NumeroVisaCanadaDomainModel, NumeroVisaCanadaVM>();
            //NumeroSeguridadSocial
            CreateMap<NumeroSeguridadSocialVM, NumeroSeguridadSocialDomainModel>();
            CreateMap<NumeroSeguridadSocialDomainModel, NumeroSeguridadSocialVM>();
            //RegistroProfEstatal
            CreateMap<RegistroProfEstatalVM, RegistroProfEstatalDomainModel>();
            CreateMap<RegistroProfEstatalDomainModel, RegistroProfEstatalVM>();
            //NumeroCartillaMilitar
            CreateMap<NumeroCartillaMilitarVM, NumeroCartillaMilitarDomainModel>();
            CreateMap<NumeroCartillaMilitarDomainModel, NumeroCartillaMilitarVM>();
            //Ife
            CreateMap<IfeVM, IfeDomainModel>();
            CreateMap<IfeDomainModel, IfeVM>();
            //Comprobante
            CreateMap<ComprobanteDomicilioVM, ComprobanteDomicilioDomainModel>();
            CreateMap<ComprobanteDomicilioDomainModel, ComprobanteDomicilioVM>();
            //Solicitud
            CreateMap<SolicitudEmpleoVM, SolicitudEmpleoDomainModel>();
            CreateMap<SolicitudEmpleoDomainModel, SolicitudEmpleoVM>();

            //Documentacion Personal V2
            CreateMap<DocumentacionPersonalV2VM, DocumentacionPersonalV2DomainModel>();
            CreateMap<DocumentacionPersonalV2DomainModel, DocumentacionPersonalV2VM>();

            //ParticipacionInstitucionalExterna
            CreateMap<ParticipacionInstitucionalExternaVM, ParticipacionInstitucionalExternaDomainModel>();
            CreateMap<ParticipacionInstitucionalExternaDomainModel, ParticipacionInstitucionalExternaVM>();

            //Periodo
            CreateMap<PeriodoVM, PeriodoDomainModel>();
            CreateMap<PeriodoDomainModel, PeriodoVM>();

            //TipoActividad
            CreateMap<TipoActividadVM, TipoActividadDomainModel>();
            CreateMap<TipoActividadDomainModel, TipoActividadVM>();

            //ParticipacionInstitucionalInterna
            CreateMap<ParticipacionInstitucionalInternaDomainModel, ParticipacionInstitucionalInternaVM>();
            CreateMap<ParticipacionInstitucionalInternaVM, ParticipacionInstitucionalInternaDomainModel>();

            //Experiencia Laboral Externa
            CreateMap<ExperienciaLaboralExternaVM, ExperienciaLaboralExternaDomainModel>();
            CreateMap<ExperienciaLaboralExternaDomainModel, ExperienciaLaboralExternaVM>();

            //ExperienciaLaboralInterna
            CreateMap<ExperienciaLaboralInternaVM, ExperienciaLaboralInternaDomainModel>();
            CreateMap<ExperienciaLaboralInternaDomainModel, ExperienciaLaboralInternaVM>();
            //participacion docente
            CreateMap<ParticipacionDocenteVM, DatosContactoDomainModel>();
            CreateMap<DatosContactoDomainModel, ParticipacionDocenteVM>();
            //Capitulo Libro
            CreateMap<CapituloLibroVM, CapituloLibroDomainModel>();
            CreateMap<CapituloLibroDomainModel, CapituloLibroVM>();
            //ProgresoProdep
            CreateMap<ProgresoProdepVM, ProgresoProdepDomainModel>();
            CreateMap<ProgresoProdepDomainModel, ProgresoProdepVM>();

            //Informe Tecnico
            CreateMap<InformeTecnicoVM, InformeTecnicoDomainModel>();
            CreateMap<InformeTecnicoDomainModel, InformeTecnicoVM>();
            //Libro
            CreateMap<LibroVM, LibroDomainModel>();
            CreateMap<LibroDomainModel, LibroVM>();
            //ManualOperacion
            CreateMap<ManualOperacionVM, ManualOperacionDomainModel>();
            CreateMap<ManualOperacionDomainModel, ManualOperacionVM>();
            //ProductividadInnovadora
            CreateMap<ProductividadInnovadoraVM, ProductividadInnovadoraDomainModel>();
            CreateMap<ProductividadInnovadoraDomainModel, ProductividadInnovadoraVM>();
            //ProduccionArtistica
            CreateMap<ProduccionArtisticaVM, ProduccionArtisticaDomainModel>();
            CreateMap<ProduccionArtisticaDomainModel, ProduccionArtisticaVM>();
            //ProduccionesArtisticas
            CreateMap<ProduccionesArtisticasVM, ProduccionesArtisticasDomainModel>();
            CreateMap<ProduccionesArtisticasDomainModel, ProduccionesArtisticasVM>();

            //participacion docente
            CreateMap<ParticipacionDocenteDomainModel, ParticipacionDocenteVM>();
            CreateMap<ParticipacionDocenteVM, ParticipacionDocenteDomainModel>();

            //Prototipo
            CreateMap<PrototipoVM, PrototipoDomainModel>();
            CreateMap<PrototipoDomainModel, PrototipoVM>();

            //ProyectoInvestigacionAplicadaDesarrolloTecnologico
            CreateMap<ProyectoInvestigacionVM, ProyectoInvestigacionDomainModel>();
            CreateMap<ProyectoInvestigacionDomainModel, ProyectoInvestigacionVM>();

            //Direccion Individualizada 
            CreateMap<DireccionIndividualizadaVM, DireccionIndividualizadaDomainModel>();
            CreateMap<DireccionIndividualizadaDomainModel, DireccionIndividualizadaVM>();

            //EstadiaEmpresa    
            CreateMap<EstadiaEmpresaVM, EstadiaEmpresaDomainModel>();
            CreateMap<EstadiaEmpresaDomainModel, EstadiaEmpresaVM>();

            //TipoProducto
            CreateMap<TipoProductoVM, TipoProductoDomainModel>();
            CreateMap<TipoProductoDomainModel, TipoProductoDomainModel>();

            //Tutorias
            CreateMap<TutoriasVM, TutoriasDomainModel>();
            CreateMap<TutoriasDomainModel, TutoriasVM>();

            //CapacitacionCompetenciasProfesionales

            CreateMap<CapacitacionCompetenciasProfesionalesVM, CapacitacionCompetenciasProfesionalesDomainModel>();
            CreateMap<CapacitacionCompetenciasProfesionalesDomainModel, CapacitacionCompetenciasProfesionalesVM>();

            //InstitucionAcreditaCapacitacionProfesional

            CreateMap<InstitucionAcreditaCapacitacionProfesionalVM, InstitucionAcreditaCapacitacionProfesionalDomainModel>();
            CreateMap<InstitucionAcreditaCapacitacionProfesionalDomainModel, InstitucionAcreditaCapacitacionProfesionalVM>();

            //Competencias Profesionales
            CreateMap<CompetenciasProfesionalesVM, CompetenciasProfesionalesDomainModel>();
            CreateMap<CompetenciasProfesionalesDomainModel, CompetenciasProfesionalesVM>();

            CreateMap<NacionalidadVM, NacionalidadDomainModel>();
            CreateMap<NacionalidadDomainModel, NacionalidadVM>();

            //Hobbies Y Hobbie

            CreateMap<HobbieVM, HobbieDomainModel>();
            CreateMap<HobbieDomainModel, HobbieVM>();

            CreateMap<HobbiesVM, HobbiesDomainModel>();
            CreateMap<HobbiesDomainModel, HobbiesVM>();

            //New Idiomas

            CreateMap<IdiomasVM, IdiomasDomainModel>();
            CreateMap<IdiomasDomainModel, IdiomasVM>();

            //Nivel Conocimiento

            CreateMap<NivelConocimientoVM, NivelConocimientoDomainModel>();
            CreateMap<NivelConocimientoDomainModel, NivelConocimientoVM>();

            //Lenguas

            CreateMap<LenguasVM, LenguasDomainModel>();
            CreateMap<LenguasDomainModel, LenguasVM>();

            //Tipo de Documento

            CreateMap<TipoDocumentoVM, TipoDocumentoDomainModel>();
            CreateMap<TipoDocumentoDomainModel, TipoDocumentoVM>();

            //Encuesta de Salud

            CreateMap<EncuestaVM, EncuestaDomainModel>();
            CreateMap<EncuestaDomainModel, EncuestaVM>();

            CreateMap<Respuestas01VM, Respuestas01DomainModel>();
            CreateMap<Respuestas01DomainModel, Respuestas01VM>();

            CreateMap<Respuestas02VM, Respuestas02DomainModel>();
            CreateMap<Respuestas02DomainModel, Respuestas02VM>();

            CreateMap<Respuestas03VM, Respuestas03DomainModel>();
            CreateMap<Respuestas03DomainModel, Respuestas03VM>();

            CreateMap<Respuestas04VM, Respuestas04DomainModel>();
            CreateMap<Respuestas04DomainModel, Respuestas04VM>();

            CreateMap<Respuestas05VM, Respuestas05DomainModel>();
            CreateMap<Respuestas05DomainModel, Respuestas05VM>();

            CreateMap<Respuestas06VM, Respuestas06DomainModel>();
            CreateMap<Respuestas06DomainModel, Respuestas06VM>();

            CreateMap<Respuestas07VM, Respuestas07DomainModel>();
            CreateMap<Respuestas07DomainModel, Respuestas07VM>();

            CreateMap<Respuestas08VM, Respuestas08DomainModel>();
            CreateMap<Respuestas08DomainModel, Respuestas08VM>();

            CreateMap<Respuestas09VM, Respuestas09DomainModel>();
            CreateMap<Respuestas09DomainModel, Respuestas09VM>();

            CreateMap<Respuestas10VM, Respuestas10DomainModel>();
            CreateMap<Respuestas10DomainModel, Respuestas10VM>();

            CreateMap<Respuestas11VM, Respuestas11DomainModel>();
            CreateMap<Respuestas11DomainModel, Respuestas11VM>();

            CreateMap<Respuestas12VM, Respuestas12DomainModel>();
            CreateMap<Respuestas12DomainModel, Respuestas12VM>();

            CreateMap<Respuestas13VM, Respuestas13DomainModel>();
            CreateMap<Respuestas13DomainModel, Respuestas13VM>();

            CreateMap<Respuestas14VM, Respuestas14DomainModel>();
            CreateMap<Respuestas14DomainModel, Respuestas14VM>();

            CreateMap<Respuestas15VM, Respuestas15DomainModel>();
            CreateMap<Respuestas15DomainModel, Respuestas15VM>();

            CreateMap<Respuestas16VM, Respuestas16DomainModel>();
            CreateMap<Respuestas16DomainModel, Respuestas16VM>();

            CreateMap<Respuestas17VM, Respuestas17DomainModel>();
            CreateMap<Respuestas17DomainModel, Respuestas17VM>();

            CreateMap<FumadorVM, FumadorDomainModel>();
            CreateMap<FumadorDomainModel, FumadorVM>();

            CreateMap<OpcionesRespuesta04VM, OpcionesRespuesta04DomainModel>();
            CreateMap<OpcionesRespuesta04DomainModel, OpcionesRespuesta04VM>();

            CreateMap<RhVM, RhDomainModel>();
            CreateMap<RhDomainModel, RhVM>();

            CreateMap<GrupoSanguineoVM, GrupoSanguineoDomainModel>();
            CreateMap<GrupoSanguineoDomainModel, GrupoSanguineoVM>();

            CreateMap<AlergiaMedicamentoVM, AlergiaMedicamentoDomainModel>();
            CreateMap<AlergiaMedicamentoDomainModel, AlergiaMedicamentoVM>();

            CreateMap<AlergiaSustanciaVM, AlergiaSustanciaDomainModel>();
            CreateMap<AlergiaSustanciaDomainModel, AlergiaSustanciaVM>();

            CreateMap<AlergiaAlimentoVM, AlergiaAlimentoDomainModel>();
            CreateMap<AlergiaAlimentoDomainModel, AlergiaAlimentoVM>();

            CreateMap<EnfermedadesExantematicaVM, EnfermedadesExantematicaDomainModel>();
            CreateMap<EnfermedadesExantematicaDomainModel, EnfermedadesExantematicaVM>();

            CreateMap<LesionHuesosVM, LesionHuesosDomainModel>();
            CreateMap<LesionHuesosDomainModel, LesionHuesosVM>();

            CreateMap<LesionArticulacionesVM, LesionArticulacionesDomainModel>();
            CreateMap<LesionArticulacionesDomainModel, LesionArticulacionesVM>();

            CreateMap<LesionLigamentosVM, LesionLigamentosDomainModel>();
            CreateMap<LesionLigamentosDomainModel, LesionLigamentosVM>();

            CreateMap<ActividadesFisicasVM, ActividadesFisicasDomainModel>();
            CreateMap<ActividadesFisicasDomainModel, ActividadesFisicasVM>();

            CreateMap<EnfermedadesVM, EnfermedadesDomainModel>();
            CreateMap<EnfermedadesDomainModel, EnfermedadesVM>();

            CreateMap<TratamientoVM, TratamientoDomainModel>();
            CreateMap<TratamientoDomainModel, TratamientoVM>();

            CreateMap<StatusDoctoradoVM, StatusDoctoradoDomainModel>();
            CreateMap<StatusDoctoradoDomainModel, StatusDoctoradoVM>();

            CreateMap<DoctoradoVM, DoctoradoDomainModel>();
            CreateMap<DoctoradoDomainModel, DoctoradoVM>();

            CreateMap<InstitucionAcreditaDoctoradoVM, InstitucionAcreditaDoctoradoDomainModel>();
            CreateMap<InstitucionAcreditaDoctoradoDomainModel, InstitucionAcreditaDoctoradoVM>();

            CreateMap<InstitucionAcreditaLicenciaturaVM, InstitucionAcreditaLicenciaturaDomainModel>();
            CreateMap<InstitucionAcreditaLicenciaturaDomainModel, InstitucionAcreditaLicenciaturaVM>();

            CreateMap<StatusLicenciaturaVM, StatusLicenciaturaDomainModel>();
            CreateMap<StatusLicenciaturaDomainModel, StatusLicenciaturaVM>();

            CreateMap<LicenciaturaIngenieriaVM, LicenciaturaIngenieriaDomainModel>();
            CreateMap<LicenciaturaIngenieriaDomainModel, LicenciaturaIngenieriaVM>();

            CreateMap<HistorialAcademicoVM, HistorialAcademicoDomainModel>();
            CreateMap<HistorialAcademicoDomainModel, HistorialAcademicoVM>();

            CreateMap<MaestriaVM, MaestriaDomainModel>();
            CreateMap<MaestriaDomainModel, MaestriaVM>();

            CreateMap<InstitucionAcreditaMaestriaVM,InstitucionAcreditaMaestriaDomainModel>();
            CreateMap<InstitucionAcreditaMaestriaDomainModel,InstitucionAcreditaMaestriaVM>();

            CreateMap<StatusMaestriaVM,StatusMaestriaDomainModel>();
            CreateMap<StatusMaestriaDomainModel,StatusMaestriaVM>();

            CreateMap<FuenteFinaciamientoMaestriaVM,FuenteFinaciamientoMaestriaDomainModel>();
            CreateMap<FuenteFinaciamientoMaestriaDomainModel,FuenteFinaciamientoMaestriaVM>();

            CreateMap<BachilleratoVM, BachilleratoDomainModel>();
            CreateMap<BachilleratoDomainModel, BachilleratoVM>();

            CreateMap<InstitucionAcreditaBachilleratoVM, InstitucionAcreditaBachilleratoDomainModel>();
            CreateMap<InstitucionAcreditaBachilleratoDomainModel, InstitucionAcreditaBachilleratoVM>();

            CreateMap<InstitucionesSaludVM, InstitucionesSaludDomainModel>();
            CreateMap<InstitucionesSaludDomainModel, InstitucionesSaludVM>();

            CreateMap<SeguridadSocialVM, SeguridadSocialDomainModel>();
            CreateMap<SeguridadSocialDomainModel, SeguridadSocialVM>();

            CreateMap<TipoCapacitacionVM, TipoCapacitacionDomainModel>();
            CreateMap<TipoCapacitacionDomainModel, TipoCapacitacionVM>();

            CreateMap<CapacitacionesRecibidasVM,CapacitacionesRecibidasDomainModel>();
            CreateMap<CapacitacionesRecibidasDomainModel,CapacitacionesRecibidasVM>();

            CreateMap<CapacitacionesImpartidadVM, CapacitacionesImpartidadDomainModel>();
            CreateMap<CapacitacionesImpartidadDomainModel, CapacitacionesImpartidadVM>();

            CreateMap<PresentacionPonenciasVM, PresentacionPonenciasDomainModel>();
            CreateMap<PresentacionPonenciasDomainModel, PresentacionPonenciasVM>();

            CreateMap<DocumentosProfesionalesVM, DocumentosProfesionalesDomainModel>();
            CreateMap<DocumentosProfesionalesDomainModel, DocumentosProfesionalesVM>();
        }

        public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomaperWebProfile>();
            });
        }
        
    }
}