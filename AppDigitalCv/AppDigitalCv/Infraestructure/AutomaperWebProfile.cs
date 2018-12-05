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