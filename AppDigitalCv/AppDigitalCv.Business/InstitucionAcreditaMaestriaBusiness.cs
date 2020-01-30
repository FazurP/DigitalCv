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
    public class InstitucionAcreditaMaestriaBusiness : IInstitucionAcreditaMaestriaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly InstitucionAcreditaMaestriaRepository institucionAcreditaMaestriaRepository;

        public InstitucionAcreditaMaestriaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            institucionAcreditaMaestriaRepository = new InstitucionAcreditaMaestriaRepository(_unitOfWork);
        }

        public List<InstitucionAcreditaMaestriaDomainModel> GetAllInstitucionesAcreditanMaestria()
        {
            List<InstitucionAcreditaMaestriaDomainModel> institucionAcreditaMaestriaDomainModels = new List<InstitucionAcreditaMaestriaDomainModel>();

            List<CatInstitucionAcreditaMaestria> catInstitucionAcreditaMaestrias = new List<CatInstitucionAcreditaMaestria>();

            catInstitucionAcreditaMaestrias = institucionAcreditaMaestriaRepository.GetAll().ToList();

            foreach (CatInstitucionAcreditaMaestria item in catInstitucionAcreditaMaestrias)
            {
                InstitucionAcreditaMaestriaDomainModel institucionAcreditaMaestriaDomainModel = new InstitucionAcreditaMaestriaDomainModel();

                institucionAcreditaMaestriaDomainModel.id = item.id;
                institucionAcreditaMaestriaDomainModel.strDescripcion = item.strDescripcion;
                institucionAcreditaMaestriaDomainModel.strValor = item.strValor;

                institucionAcreditaMaestriaDomainModels.Add(institucionAcreditaMaestriaDomainModel);
            }

            InstitucionAcreditaMaestriaDomainModel institucionAcreditaMaestriaDomainModel1 = new InstitucionAcreditaMaestriaDomainModel();

            institucionAcreditaMaestriaDomainModel1.id = 0;
            institucionAcreditaMaestriaDomainModel1.strDescripcion = "Seleccionar";
            institucionAcreditaMaestriaDomainModel1.strValor = "Seleccionar";

            institucionAcreditaMaestriaDomainModels.Insert(0, institucionAcreditaMaestriaDomainModel1);

            return institucionAcreditaMaestriaDomainModels;
        }
    }
}
