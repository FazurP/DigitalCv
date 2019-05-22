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
    public class AreaBusiness : IAreaBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly AreaRepository areaRepository;

        public AreaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            areaRepository = new AreaRepository(unitofWork);
        }

        public List<AreaDomainModel> GetAreas()
        {
            List<AreaDomainModel> areas = new List<AreaDomainModel>();
            areas = areaRepository.GetAll().Select(p => new AreaDomainModel
            {
                idArea = p.idArea,
                strDescripcion = p.strDescripcion,
                strObservacion = p.strObservacion
            }).ToList<AreaDomainModel>();
            AreaDomainModel areaDM = new AreaDomainModel();
            areaDM.idArea = 0;
            areaDM.strDescripcion = "--Seleccionar--";
            areas.Insert(0, areaDM);
            return areas;
        }
    }
}
