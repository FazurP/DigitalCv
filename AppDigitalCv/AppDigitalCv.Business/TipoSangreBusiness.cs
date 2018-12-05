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
    public class TipoSangreBusiness : ITipoSangreBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly TipoSangreRepository tipoSangreRepository;
        public TipoSangreBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            tipoSangreRepository = new TipoSangreRepository(unitOfWork);
        }


        public List<TipoSangreDomainModel> GetTipoSangre()
        {
            List<TipoSangreDomainModel> lista = null;
            lista = tipoSangreRepository.GetAll().Select(p => new TipoSangreDomainModel
            {
                IdTipoSangre = p.idTipoSangre,
                StrDescripcion = p.strDescripcion,
                StrObservacion = p.strObservacion
                             
            }).ToList();
            return lista;
        }


    }
}
