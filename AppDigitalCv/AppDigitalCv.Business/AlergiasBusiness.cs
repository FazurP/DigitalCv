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


        /// <summary>
        /// Este metodo se encarga de registrar o actualizar las alergias
        /// </summary>
        /// <param name="alergiasPersonalDomainModel"></param>
        /// <returns>regresar un true o false si el proceso se llevo acabo.</returns>
        public bool AddUpdateAlergias(AlergiasPersonalDomainModel alergiasPersonalDomainModel)
        {

            bool respuesta = false;

            if (alergiasPersonalDomainModel.idAlergiasPersonal > 0)
            {
                tblAlergiasPersonal alergias = alergiasPersonalRepository.SingleOrDefault(p => p.idAlergiasPersonal == alergiasPersonalDomainModel.idAlergiasPersonal);

                if (alergias != null)
                {
                    alergias.idAlergia = alergiasPersonalDomainModel.idAlergia;
                    alergias.idPersonal = alergiasPersonalDomainModel.idPersonal;
                    alergias.dteFechaRegistro = DateTime.Now;

                    alergiasPersonalRepository.Update(alergias);

                    respuesta = true;
                }

            }
            else
            {
                if (alergiasPersonalRepository.Exists(p => p.idAlergia == alergiasPersonalDomainModel.idAlergia))
                {
                    return false;
                }
                else
                {
                    tblAlergiasPersonal tblAlergiasPersonal = new tblAlergiasPersonal();
                    tblAlergiasPersonal.idAlergia = alergiasPersonalDomainModel.idAlergia;
                    tblAlergiasPersonal.idPersonal = alergiasPersonalDomainModel.idPersonal;
                    tblAlergiasPersonal.dteFechaRegistro = DateTime.Now;

                    alergiasPersonalRepository.Insert(tblAlergiasPersonal);

                    respuesta = true;
                }
            }

            return respuesta;

        }

        public AlergiasDomainModel GetAlergia(int idAlergia,int idPersona) {

            AlergiasDomainModel alergiasDM = new AlergiasDomainModel();

            Expression<Func<tblAlergiasPersonal, bool>> predicado = p => p.idPersonal.Equals(idPersona) && p.idAlergia.Equals(idAlergia);
            tblAlergiasPersonal tblAlergias = alergiasPersonalRepository.GetAll(predicado).FirstOrDefault<tblAlergiasPersonal>();

            alergiasDM.IdAlergia = tblAlergias.catAlergias.idAlergias;
            alergiasDM.IdtipoAlergia = tblAlergias.catAlergias.idTipoAlergia;
            alergiasDM.StrDescripcion = tblAlergias.catAlergias.strDescripcion;
            alergiasDM.StrObservacion = tblAlergias.catAlergias.strObservacion;

            return alergiasDM;


        }
        
    }
}
