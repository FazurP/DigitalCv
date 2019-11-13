using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class NacionalidadBusiness : INacionalidadBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly NacionalidadRepository nacionalidadRepository;

        public NacionalidadBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            nacionalidadRepository = new NacionalidadRepository(this.unitOfWork);
        }

        public List<NacionalidadDomainModel> GetAllNacionalidades()
        {
            List<NacionalidadDomainModel> nacionalidadDomainModels = new List<NacionalidadDomainModel>();
            List<CatNacionalidad> catNacionalidads = new List<CatNacionalidad>();

            catNacionalidads = nacionalidadRepository.GetAll().ToList();

            foreach (CatNacionalidad item in catNacionalidads)
            {
                NacionalidadDomainModel nacionalidadDomainModel = new NacionalidadDomainModel();

                nacionalidadDomainModel.id = item.id;
                nacionalidadDomainModel.strValor = item.strValor;

                nacionalidadDomainModels.Add(nacionalidadDomainModel);
            }

            NacionalidadDomainModel nacionalidadDomainModel1 = new NacionalidadDomainModel();

            nacionalidadDomainModel1.id = 0;
            nacionalidadDomainModel1.strValor = "Seleccionar";

            nacionalidadDomainModels.Insert(0,nacionalidadDomainModel1);

            return nacionalidadDomainModels;
        }
    }
}
