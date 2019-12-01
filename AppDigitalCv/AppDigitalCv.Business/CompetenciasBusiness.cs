using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class CompetenciasBusiness : ICompetenciasBusiness
    {

        private readonly IUnitOfWork unitOfWork;
       
        private readonly CompetenciasPersonalRepository competenciasPersonalRepository;

        public CompetenciasBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
           
            competenciasPersonalRepository = new CompetenciasPersonalRepository(unitOfWork);
        }
     

    }
}
