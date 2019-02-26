using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class EmergenciaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmergenciaRepository emergenciaRepository;

        public EmergenciaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            emergenciaRepository = new EmergenciaRepository(unitOfWork);
        }


    }
}
