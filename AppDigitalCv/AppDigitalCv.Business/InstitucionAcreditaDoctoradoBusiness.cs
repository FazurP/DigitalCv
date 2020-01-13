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
    public class InstitucionAcreditaDoctoradoBusiness : IInstitucionAcreditaDoctoradoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly InstitucionAcreditaDoctoradoRepository institucionAcreditaDoctoradoRepository;

        public InstitucionAcreditaDoctoradoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            institucionAcreditaDoctoradoRepository = new InstitucionAcreditaDoctoradoRepository(unitOfWork);
        }

        public List<InstitucionAcreditaDoctoradoDomainModel> GetAllInstitucionesAcreditanDoctorados()
        {

            List<InstitucionAcreditaDoctoradoDomainModel> institucionAcreditaDoctoradoDomainModels = new List<InstitucionAcreditaDoctoradoDomainModel>();

            List<CatInstitucionAcreditaDoctorado> catInstitucionesDoctorados = institucionAcreditaDoctoradoRepository.GetAll().ToList();

            foreach (CatInstitucionAcreditaDoctorado item in catInstitucionesDoctorados)
            {
                InstitucionAcreditaDoctoradoDomainModel institucionAcreditaDoctoradoDomainModel = new InstitucionAcreditaDoctoradoDomainModel();

                institucionAcreditaDoctoradoDomainModel.id = item.id;
                institucionAcreditaDoctoradoDomainModel.strDescripcion = item.strDescripcion;
                institucionAcreditaDoctoradoDomainModel.strValor = item.strValor;

                institucionAcreditaDoctoradoDomainModels.Add(institucionAcreditaDoctoradoDomainModel);
            }

            InstitucionAcreditaDoctoradoDomainModel institucionAcreditaDoctoradoDomainModel1 = new InstitucionAcreditaDoctoradoDomainModel();

            institucionAcreditaDoctoradoDomainModel1.id = 0;
            institucionAcreditaDoctoradoDomainModel1.strDescripcion = "Seleccionar";
            institucionAcreditaDoctoradoDomainModel1.strValor = "Seleccionar";

            institucionAcreditaDoctoradoDomainModels.Insert(0, institucionAcreditaDoctoradoDomainModel1);

            return institucionAcreditaDoctoradoDomainModels;
        }
    }
}
