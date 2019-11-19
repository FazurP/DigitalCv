using AppDigitalCv.Domain;
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

            CreateMap<NivelConocimientoVM,NivelConocimientoDomainModel>();
            CreateMap<NivelConocimientoDomainModel, NivelConocimientoVM>();
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