using AppDigitalCv.Business.Enum;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppDigitalCv.Business
{
    public class AlergiasBusiness : IAlergiasBusiness
    {
        //Creacion de los objetos del repositorio
        private readonly IUnitOfWork unitOfWork;
        private readonly AlergiasRepository alergiaRepository;
        private readonly AlergiasPersonalRepository alergiasPersonalRepository;

        public AlergiasBusiness(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;
            alergiaRepository = new AlergiasRepository(unitOfWork);
            alergiasPersonalRepository = new AlergiasPersonalRepository(unitOfWork);

        }
        /// <summary>
        /// Este metodo obtiene las alergias que le corresponden a los alimentos
        /// </summary>
        /// <returns>una lista con las alergias</returns>
        public List<AlergiasDomainModel> GetAlergias()
        {
            List<AlergiasDomainModel> alergias = null;
            alergias = alergiaRepository.GetAll().Where(p => p.idTipoAlergia == (int)EnumAlergias.Alimentos).Select(p => new AlergiasDomainModel { IdAlergias = p.idAlergias, StrDescripcion = p.strDescripcion }).ToList<AlergiasDomainModel>();
            AlergiasDomainModel alergiasDM = new AlergiasDomainModel();
            alergiasDM.IdAlergias = 0;
            alergiasDM.StrDescripcion = "--Seleccionar--";
            alergias.Insert(0, alergiasDM);
            return alergias;
        }
        /// <summary>
        /// Este metodo obtiene las alergias que le corresponden a los alergenos
        /// </summary>
        /// <returns>una lista con las alergias</returns>
        public List<AlergiasDomainModel> GetAlergenos()
        {
            List<AlergiasDomainModel> alergias = null;
            alergias = alergiaRepository.GetAll().Where(p => p.idTipoAlergia == (int)EnumAlergias.Alergenos).Select(p => new AlergiasDomainModel { IdAlergias = p.idAlergias, StrDescripcion = p.strDescripcion }).ToList<AlergiasDomainModel>();
            AlergiasDomainModel alergiasDM = new AlergiasDomainModel();
            alergiasDM.IdAlergias = 0;
            alergiasDM.StrDescripcion = "--Seleccionar--";
            alergias.Insert(0, alergiasDM);
            return alergias;
        }
        /// <summary>
        /// Este metodo obtiene las alergias que le corresponden a los medicamentos
        /// </summary>
        /// <returns>una lista con las alergias</returns>
        public List<AlergiasDomainModel> GetMedicamentos()
        {
            List<AlergiasDomainModel> alergias = null;
            alergias = alergiaRepository.GetAll().Where(p => p.idTipoAlergia == (int)EnumAlergias.Medicamentos).Select(p => new AlergiasDomainModel { IdAlergias = p.idAlergias, StrDescripcion = p.strDescripcion }).ToList<AlergiasDomainModel>();
            AlergiasDomainModel alergiasDM = new AlergiasDomainModel();
            alergiasDM.IdAlergias = 0;
            alergiasDM.StrDescripcion = "--Seleccionar--";
            alergias.Insert(0, alergiasDM);
            return alergias;
        }
        /// <summary>
        /// Este metodo se encarga de registrar o actualizar las alergias
        /// </summary>
        /// <param name="alergiasPersonalDomainModel"></param>
        /// <returns>regresar un true o false si el proceso se llevo acabo.</returns>
        public bool AddUpdateAlergias(AlergiasPersonalDomainModel alergiasPersonalDomainModel)
        {

            bool respuesta = false;

            if (alergiasPersonalDomainModel.IdAlergiasPersonal > 0)
            {
                tblAlergiasPersonal alergias = alergiasPersonalRepository.SingleOrDefault(p => p.idAlergiasPersonal == alergiasPersonalDomainModel.IdAlergiasPersonal);

                if (alergias != null)
                {
                    alergias.idAlergia = alergiasPersonalDomainModel.IdAlergia;
                    alergias.idPersonal = alergiasPersonalDomainModel.IdPersonal;
                    alergias.dteFechaRegistro = DateTime.Now;

                    alergiasPersonalRepository.Update(alergias);

                    respuesta = true;
                }

            }
            else
            {
                if (alergiasPersonalRepository.Exists(p => p.idAlergia == alergiasPersonalDomainModel.IdAlergia))
                {
                    return false;
                }
                else
                {
                    tblAlergiasPersonal tblAlergiasPersonal = new tblAlergiasPersonal();
                    tblAlergiasPersonal.idAlergia = alergiasPersonalDomainModel.IdAlergia;
                    tblAlergiasPersonal.idPersonal = alergiasPersonalDomainModel.IdPersonal;
                    tblAlergiasPersonal.dteFechaRegistro = DateTime.Now;

                    alergiasPersonalRepository.Insert(tblAlergiasPersonal);

                    respuesta = true;
                }
            }

            return respuesta;

        }

    }
}
