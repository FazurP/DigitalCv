using AppDigitalCv.Business;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Repository.Infraestructure;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AppDigitalCv
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //Tenemos que modificar en todos los unityconfig


            ///si tienes constructores en el metodo bussiness sobre cargados 
            //container.RegisterType<PersonalBusiness>(new Unity.Injection.InjectionConstructor(0));
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPersonalBusiness, PersonalBusiness>();
            container.RegisterType<IAccountBusiness, AccountBusiness>();
            container.RegisterType<IDireccionBusiness, DireccionBusiness>();
            container.RegisterType<IDatosContacto, DatosContactoBusiness>();
            container.RegisterType<ITelefono, TelefonoBusiness>();
            container.RegisterType<IEstadoCivilBusiness, EstadoCivilBusiness>();
            container.RegisterType<IDialectoIdiomaBusiness, DialectoIdiomaBusiness>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IEnfermedadBusiness, EnfermedadBusiness>();
            container.RegisterType<IEstadoSaludBusiness, EstadoSaludBusiness>();
            container.RegisterType<IFamiliarBusiness, FamiliarBusiness>();
            container.RegisterType<IPremiosDocenteBusiness, PremiosDocenteBusiness>();
            container.RegisterType<IDocumentosBusiness, DocumentosBusiness>();
            container.RegisterType<IAsociacionesBusiness, AsosiacionesBusiness>();
            container.RegisterType<IPersonalAsociacionesBusiness, PersonalAsociacionesBusiness>();
            container.RegisterType<IParentescoBusiness, ParentescoBusiness>();
            container.RegisterType<IEmergenciaBusiness, EmergenciaBusiness>();
            container.RegisterType<IDeporteBusiness, DeporteBusiness>();
            container.RegisterType<IFrecuenciaBusiness, FrecuenciaBusiness>();
            container.RegisterType<IDeportePersonalBusiness, DeportePersonalBusiness>();
            container.RegisterType<IAlergiasBusiness, AlergiasBusiness>();
            container.RegisterType<IAlergiasPersonalBusinnes, AlergiasPersonalBusiness>();
            container.RegisterType<IIdiomaBusiness, IdiomasBusiness>();
            container.RegisterType<IDialectoBusiness, DialectoBusiness>();
            container.RegisterType<ICompetenciasBusiness, CompetenciasBusiness>();
            container.RegisterType<ICompetenciaPersonalBusiness, CompetenciasPersonalBusiness>();

            container.RegisterType<ICategoriaBusiness, CategoriaBusiness>();
            container.RegisterType<IUnidadesAcademicasBusiness, UnidadesAcademicasBusiness>();
            container.RegisterType<IEdificioBusiness, EdificioBusiness>();
            container.RegisterType<IProgramaEducativoBusiness,ProgramaEducativoBusiness>();
            container.RegisterType<IAreaBusiness, AreaBusiness>();
            container.RegisterType<IInstitucionSuperiorBusiness, InstitucionSuperiorBusiness>();
            container.RegisterType<IDocumentacionPersonalBusiness, DocumentacionPersonalBusiness>();
            container.RegisterType<IDocumentacionPersonalV2Business, DocumentacionPersonalV2Business>();
            container.RegisterType<IPeriodoBusiness,PeriodoBusiness>();
            container.RegisterType<IParticipacionInstitucionalExternaBusiness, ParticipacionInstitucionalExternaBusiness>();
            container.RegisterType<ITipoActividad, TipoActividadBusiness>();
            container.RegisterType<IParticipacionInstitucionalInternaBusiness, ParticipacionInstitucionalInternaBusiness>();
            container.RegisterType<IExperienciaLaboralExterna, ExperienciaLaboralExternaBusiness>();
            container.RegisterType<IExperienciaLaboralInternaBusiness, ExperienciaLaboralInternaBusiness>();
            container.RegisterType<IParticipacionDocenteBusiness, ParticipacionDocenteBusiness>();
            container.RegisterType<ICapituloLibro, CapituloLibroBusiness>();
            container.RegisterType<IPaisBusiness, PaisBusiness>();
            container.RegisterType<IProgresoProdep, ProgresoProdepBusiness>();
            container.RegisterType<IInformeTecnicoBusiness, InformeTecnicoBusiness>();
            container.RegisterType<ILibroBusiness, LibroBusiness>();
            container.RegisterType<IManualOperacionBusiness, ManualOperacionBusiness>();
            container.RegisterType<IProductividadInnovadoraBusiness, ProductividadInnovadoraBusiness>();
            container.RegisterType<IProduccionesArtisticasBusiness, ProduccionesArtisticasBusiness>();
            container.RegisterType<IProduccionArtistica, ProduccionArtisticaBusiness>();
            container.RegisterType<IPrototipoBusiness, PrototipoBusiness>();
            container.RegisterType<IProyectoInvestigacionBusiness, ProyectoInvestigacionBusiness>();
            container.RegisterType<IDireccionIndividualizadaBusiness, DireccionIndividualizadaBusiness>();
            container.RegisterType<ITipoEstudioBusiness, TipoEstudioBusiness>();
            container.RegisterType<IEstadiaEmpresaBusiness, EstadiaEmpresaBusiness>();
            container.RegisterType<ITipoProductoBusiness,TipoProductoBusiness>();
            container.RegisterType<ITutoriasBusiness, TutoriasBusiness>();
            container.RegisterType<INacionalidadBusiness,NacionalidadBusiness>();
            container.RegisterType<IHobbiesBusiness, HobbiesBusiness>();
            container.RegisterType<IHobbieBusiness, HobbieBusiness>();
            container.RegisterType<IIdiomasBusiness, IdiomaBusiness>();
            container.RegisterType<INivelConocimientoBusiness, NivelConocimientoBusiness>();
            container.RegisterType<ITipoDocumentoBusiness, TipoDocumentoBusiness>();
            container.RegisterType<IEncuestaSaludBusiness, EncuestaSaludBusiness>();
            container.RegisterType<IInstitucionAcreditaDoctoradoBusiness,InstitucionAcreditaDoctoradoBusiness>();
            container.RegisterType<IInstitucionAcreditaLicenciaturaBusiness, InstitucionAcreditaLicenciaturaBusiness>();
            container.RegisterType<IStatusDoctoradoBusiness, StatusDoctoradoBusiness>();
            container.RegisterType<IFuenteFinaciamientoDoctoradoBusiness, FuenteFinaciamientoDoctoradoBusiness>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}