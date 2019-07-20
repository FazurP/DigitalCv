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
    public class TipoEstudioBusiness : ITipoEstudioBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly TipoEstudioRepository tipoEstudioRepository;

        public TipoEstudioBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            tipoEstudioRepository = new TipoEstudioRepository(unitofWork);
        }

        public List<TipoEstudioDomainModel> GetTiposEstudios()
        {
            List<TipoEstudioDomainModel> tipoEstudios = new List<TipoEstudioDomainModel>();

            List<catTipoEstudio> catTipos = tipoEstudioRepository.GetAll().ToList();

            foreach (catTipoEstudio item in catTipos)
            {
                TipoEstudioDomainModel tipoEstudioDM = new TipoEstudioDomainModel();

                tipoEstudioDM.idTipoEstudio = item.idTipoEstudio;
                tipoEstudioDM.strDescripcion = item.strDescripcion;
                tipoEstudioDM.strObservacion = item.strObservacion;

                tipoEstudios.Add(tipoEstudioDM);
            }

            TipoEstudioDomainModel tipoEstudio = new TipoEstudioDomainModel();

            tipoEstudio.idTipoEstudio = 0;
            tipoEstudio.strDescripcion = "--Seleccionar--";

            tipoEstudios.Insert(0,tipoEstudio);

            return tipoEstudios;
        }
    }
}
