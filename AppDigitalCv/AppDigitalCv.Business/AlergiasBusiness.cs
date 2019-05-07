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
    public class AlergiasBusiness : IAlergiasBusiness
    {
        //Creacion de los objetos del repositorio
        private readonly IUnitOfWork unitOfWork;
        private readonly AlergiasRepository alergiaRepository;

        public AlergiasBusiness(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;
            alergiaRepository = new AlergiasRepository(unitOfWork);

        }

        public List<AlergiasDomainModel> GetAlergias()
        {
            List<AlergiasDomainModel> alergias = null;
            alergias = alergiaRepository.GetAll().Where(p => p.idTipoAlergia == 1).Select(p => new AlergiasDomainModel { IdAlergia = p.idAlergias, StrDescripcion = p.strDescripcion }).ToList<AlergiasDomainModel>();
            AlergiasDomainModel alergiasDM = new AlergiasDomainModel();
            alergiasDM.IdAlergia = 0;
            alergiasDM.StrDescripcion = "--Seleccionar--";
            alergias.Insert(0, alergiasDM);
            return alergias;
        }

        public List<AlergiasDomainModel> GetAlergenos()
        {
            List<AlergiasDomainModel> alergias = null;
            alergias = alergiaRepository.GetAll().Where(p => p.idTipoAlergia == 2).Select(p => new AlergiasDomainModel { IdAlergia = p.idAlergias, StrDescripcion = p.strDescripcion }).ToList<AlergiasDomainModel>();
            AlergiasDomainModel alergiasDM = new AlergiasDomainModel();
            alergiasDM.IdAlergia = 0;
            alergiasDM.StrDescripcion = "--Seleccionar--";
            alergias.Insert(0, alergiasDM);
            return alergias;
        }

        public List<AlergiasDomainModel> GetMedicamentos()
        {
            List<AlergiasDomainModel> alergias = null;
            alergias = alergiaRepository.GetAll().Where(p => p.idTipoAlergia == 3).Select(p => new AlergiasDomainModel { IdAlergia = p.idAlergias, StrDescripcion = p.strDescripcion }).ToList<AlergiasDomainModel>();
            AlergiasDomainModel alergiasDM = new AlergiasDomainModel();
            alergiasDM.IdAlergia = 0;
            alergiasDM.StrDescripcion = "--Seleccionar--";
            alergias.Insert(0, alergiasDM);
            return alergias;
        }

    }
}
