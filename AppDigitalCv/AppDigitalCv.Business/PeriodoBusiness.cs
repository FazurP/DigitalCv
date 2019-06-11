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
    public class PeriodoBusiness : IPeriodoBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly PeriodoRepository periodoRepository;

        public PeriodoBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            periodoRepository = new PeriodoRepository(unitofWork);
        }

        public List<PeriodoDomainModel> GetPeriodos()
        {
            List<PeriodoDomainModel> periodos = new List<PeriodoDomainModel>();

            periodos = periodoRepository.GetAll().Select(p=> new PeriodoDomainModel { id = p.id,strDescripcion= p.strDescripcion}).ToList();

            PeriodoDomainModel periodo = new PeriodoDomainModel();
            periodo.id = 0;
            periodo.strDescripcion = "Seleccionar";

            periodos.Insert(0,periodo);

            return periodos;
        }
    }
}
