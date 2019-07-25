using AppDigitalCv.Business.Interface;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class TutoriasBusiness : ITutoriasBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly TutoriasRepository tutoriaRepository;

        public TutoriasBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            tutoriaRepository = new TutoriasRepository(unitofWork);
        }

        
    }
}
