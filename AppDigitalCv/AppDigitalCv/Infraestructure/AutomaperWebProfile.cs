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
            CreateMap<PersonalDomainModel, PersonalVM>();
            CreateMap<PersonalVM, PersonalDomainModel>();
            CreateMap<DocumentoPersonalVM, DocumentoPersonalDomainModel>();
            CreateMap<DocumentoPersonalDomainModel, DocumentoPersonalVM>();

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