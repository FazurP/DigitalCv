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
    public class DireccionIndividualizadaBusiness : IDireccionIndividualizadaBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly DireccionIndividualizadaRepository direccionIndividualizadaRepository;

        public DireccionIndividualizadaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            direccionIndividualizadaRepository = new DireccionIndividualizadaRepository(unitofWork);
        }
    }
}
