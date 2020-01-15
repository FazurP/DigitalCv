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
    public class InstitucionAcreditaLicenciaturaBusiness : IInstitucionAcreditaLicenciaturaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly InstitucionAcreditaLicenciaturaRepository institucionAcreditaLicenciaturaRepository;

        public InstitucionAcreditaLicenciaturaBusiness(IUnitOfWork _unitOfWork) 
        {
            unitOfWork = _unitOfWork;
            institucionAcreditaLicenciaturaRepository = new InstitucionAcreditaLicenciaturaRepository(unitOfWork);
        }

        public List<InstitucionAcreditaLicenciaturaDomainModel> GetAllInstitucionAcreditanLicenciaturas() 
        {
            List<InstitucionAcreditaLicenciaturaDomainModel> institucionAcreditaLicenciaturaDomainModels = new List<InstitucionAcreditaLicenciaturaDomainModel>();

            List<CatInstitucionAcreditaLicenciatura> catInstitucionAcreditaLicenciaturas = new List<CatInstitucionAcreditaLicenciatura>();

            catInstitucionAcreditaLicenciaturas = institucionAcreditaLicenciaturaRepository.GetAll().ToList();

            foreach (CatInstitucionAcreditaLicenciatura item in catInstitucionAcreditaLicenciaturas)
            {
                InstitucionAcreditaLicenciaturaDomainModel institucionAcreditaLicenciaturaDomainModel = new InstitucionAcreditaLicenciaturaDomainModel();

                institucionAcreditaLicenciaturaDomainModel.id = item.id;
                institucionAcreditaLicenciaturaDomainModel.strDescripcion = item.strDescripcion;
                institucionAcreditaLicenciaturaDomainModel.strValor = item.strValor;

                institucionAcreditaLicenciaturaDomainModels.Add(institucionAcreditaLicenciaturaDomainModel);
            }

            InstitucionAcreditaLicenciaturaDomainModel institucionAcreditaLicenciaturaDomainModel1 = new InstitucionAcreditaLicenciaturaDomainModel();
            institucionAcreditaLicenciaturaDomainModel1.id = 0;
            institucionAcreditaLicenciaturaDomainModel1.strDescripcion = "Seleccionar";
            institucionAcreditaLicenciaturaDomainModel1.strValor = "Seleccionar";

            institucionAcreditaLicenciaturaDomainModels.Insert(0, institucionAcreditaLicenciaturaDomainModel1);

            return institucionAcreditaLicenciaturaDomainModels;
        }
    }
}
