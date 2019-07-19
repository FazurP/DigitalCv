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
    public class TipoEstudioBusiness : ITipoEstudioBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly TipoEstudioRepository tipoEstudioRepository;

        public TipoEstudioBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            tipoEstudioRepository = new TipoEstudioRepository(unitofWork);
        }
    }
}
