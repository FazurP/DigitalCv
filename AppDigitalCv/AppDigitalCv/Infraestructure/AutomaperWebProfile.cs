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
            // Personal
            CreateMap<PersonalDomainModel, PersonalVM>();
            CreateMap<PersonalVM, PersonalDomainModel>();

            /* Direccion
            CreateMap<DireccionDomainModel, DireccionVM>();
            CreateMap<DireccionVM, DireccionDomainModel>();
    */

            CreateMap<PaisDomainModel, PaisVM>();
            CreateMap<PaisVM, PaisDomainModel>(); 
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