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
    public class UnidadesAcademicasBusiness : IUnidadesAcademicasBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly UnidadesAcademicasRepository unidadesAcademicasRepository;

        public UnidadesAcademicasBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            unidadesAcademicasRepository = new UnidadesAcademicasRepository(unitofWork);
        }

        public List<UnidadesAcademicasDomainModel> GetUnidadesAcademicas()
        {
            List<UnidadesAcademicasDomainModel> unidadesAcademicas = new List<UnidadesAcademicasDomainModel>();
            unidadesAcademicas = unidadesAcademicasRepository.GetAll().Select(p => new UnidadesAcademicasDomainModel
            {
                idUnidadesAcademicas = p.idUnidadesAcademicas,
                strDescripcion = p.strDescripcion,
                strObservacion = p.strObservacion
            }).ToList<UnidadesAcademicasDomainModel>();
            UnidadesAcademicasDomainModel unidadesAcademicasDM = new UnidadesAcademicasDomainModel();
            unidadesAcademicasDM.idUnidadesAcademicas = 0;
            unidadesAcademicasDM.strDescripcion = "--Seleccionar--";
            unidadesAcademicas.Insert(0,unidadesAcademicasDM);
            return unidadesAcademicas;
        }
    }
}
