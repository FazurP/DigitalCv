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
            container.RegisterType<IIdiomaDialectoBusiness, IdiomaDialectoBusiness>();
            container.RegisterType<IDialectoIdiomaBusiness, DialectoIdiomaBusiness>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IEnfermedadBusiness, EnfermedadBusiness>();
            container.RegisterType<ITipoSangreBusiness,TipoSangreBusiness>();
            container.RegisterType<IEstadoSaludBusiness, EstadoSaludBusiness>();
            container.RegisterType<IFamiliarBusiness, FamiliarBusiness>();
            container.RegisterType<IPremiosDocenteBusiness, PremiosDocenteBusiness>();
            container.RegisterType<IDocumentosBusiness, DocumentosBusiness>();
            container.RegisterType<IAsociacionesBusiness, AsosiacionesBusiness>();
            container.RegisterType<ITipoEmpresaBusiness, TipoEmpresaBusiness>();
            container.RegisterType<IPersonalAsociacionesBusiness, PersonalAsociacionesBusiness>();
            container.RegisterType<ICompetenciaBusiness, CompetenciaBusiness>();
            container.RegisterType<ICompetenciasTiBusiness, CompetenciasTiBusiness>();
            container.RegisterType<IParentescoBusiness, ParentescoBusiness>();
            container.RegisterType<IEmergenciaBusiness, EmergenciaBusiness>();
            container.RegisterType<IDeporteBusiness, DeporteBusiness>();
            container.RegisterType<IFrecuenciaBusiness, FrecuenciaBusiness>();
            container.RegisterType<IDeportePersonalBusiness, DeportePersonalBusiness>();
            container.RegisterType<IAlergiasBusiness, AlergiasBusiness>();
            container.RegisterType<IAlergiasPersonalBusinnes, AlergiasPersonalBusiness>();
            container.RegisterType<IIdiomaBusiness, IdiomasBusiness>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}