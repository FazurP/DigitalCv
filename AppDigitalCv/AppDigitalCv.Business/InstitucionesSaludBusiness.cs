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
    public class InstitucionesSaludBusiness : IInstitucionesSaludBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly InstitucionesSaludRepository institucionesSaludRepository;

        public InstitucionesSaludBusiness(IUnitOfWork _unitOfWork) 
        {
            unitOfWork = _unitOfWork;
            institucionesSaludRepository = new InstitucionesSaludRepository(unitOfWork);
        }

        public List<InstitucionesSaludDomainModel> GetAllInstitucionesSalud() 
        {
            List<InstitucionesSaludDomainModel> institucionesSaludDomainModels = new List<InstitucionesSaludDomainModel>();
            List<CatInstitucionesSalud> CatInstitucionesSalud = institucionesSaludRepository.GetAll().ToList();

            foreach (CatInstitucionesSalud item in CatInstitucionesSalud)
            {
                InstitucionesSaludDomainModel institucionesSaludDomainModel = new InstitucionesSaludDomainModel();

                institucionesSaludDomainModel.id = item.id;
                institucionesSaludDomainModel.strValor = item.strValor;

                institucionesSaludDomainModels.Add(institucionesSaludDomainModel);
            }

            InstitucionesSaludDomainModel institucionesSaludDomainModel1 = new InstitucionesSaludDomainModel();

            institucionesSaludDomainModel1.id = 0;
            institucionesSaludDomainModel1.strValor = "Seleccionar";

            institucionesSaludDomainModels.Insert(0,institucionesSaludDomainModel1);

            return institucionesSaludDomainModels;
        }

    }
}
