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
    public class TipoActividadBusiness : ITipoActividad
    {
        private readonly IUnitOfWork unitofWork;
        private readonly TipoActividadRepository tipoActividadRepository;

        public TipoActividadBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            tipoActividadRepository = new TipoActividadRepository(unitofWork);
        }

        public List<TipoActividadDomainModel> GetTiposActividades()
        {
            List<TipoActividadDomainModel> tipoActividades = new List<TipoActividadDomainModel>();

            tipoActividades = tipoActividadRepository.GetAll().Select(p => new TipoActividadDomainModel
            {
                id = p.id,
                strDescripcion = p.strDescripcion
            }).ToList();

            TipoActividadDomainModel tipoActividadDM = new TipoActividadDomainModel();

            tipoActividadDM.id = 0;
            tipoActividadDM.strDescripcion = "Seleccionar";

            tipoActividades.Insert(0,tipoActividadDM);

            return tipoActividades;
        }
    }
}
