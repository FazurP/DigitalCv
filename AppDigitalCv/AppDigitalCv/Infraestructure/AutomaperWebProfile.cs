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
            CreateMap<DeporteVM,DeporteDomainModel>();
            CreateMap<DeporteDomainModel,DeporteVM>();
            //frecuencia
            CreateMap<FrecuenciaDomainModel, FrecuenciaVM>();
            CreateMap<FrecuenciaVM, FrecuenciaDomainModel>();
            //pasatiempo
            CreateMap<PasatiempoVM,PasatiempoDomainModel>();
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