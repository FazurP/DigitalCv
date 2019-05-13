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
using System.Data.Entity;
namespace AppDigitalCv.Business
{
    public class AlergiasPersonalBusiness : IAlergiasPersonalBusinnes
    {

        private readonly IUnitOfWork unitOfWork;
       
        private readonly AlergiasPersonalRepository alergiasPersonalRepository;
        public AlergiasPersonalBusiness(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;
       
            alergiasPersonalRepository = new AlergiasPersonalRepository(unitOfWork);

        }
        /// <summary>
        /// Este metodo obtiene las alergias de la persona
        /// </summary>
        /// <param name="_idPersonal"></param>
        /// <returns>una lista con las alergias</returns>
        public List<AlergiasDomainModel> GetAlergiasByIdPersonal(int _idPersonal)
        {

            List<AlergiasDomainModel> alergiasDM = new List<AlergiasDomainModel>();

            Expression<Func<tblAlergiasPersonal, bool>> predicado = p => p.idPersonal.Equals(_idPersonal);
            List<tblAlergiasPersonal> alergias = alergiasPersonalRepository.GetAll(predicado).ToList<tblAlergiasPersonal>();


            foreach (tblAlergiasPersonal alergia in alergias)
            {
                AlergiasDomainModel alergiaDM = new AlergiasDomainModel();
                alergiaDM.IdAlergia = alergia.catAlergias.idAlergias;
                alergiaDM.IdtipoAlergia = alergia.catAlergias.idTipoAlergia;
                alergiaDM.StrDescripcion = alergia.catAlergias.strDescripcion;
                alergiaDM.StrObservacion = alergia.catAlergias.strObservacion;
                alergiasDM.Add(alergiaDM);
            }

            return alergiasDM;
        }
        /// <summary>
        /// Este metodo Obtiene una alergias personal
        /// </summary>
        /// <param name="_idAlergia"></param>
        /// <param name="_idPersonal"></param>
        /// <returns>el objeto de la alergia</returns>
        public AlergiasPersonalDomainModel GetAlergiasPersonales(int _idAlergia, int _idPersonal) {

            AlergiasPersonalDomainModel alergiasPersonalDM = new AlergiasPersonalDomainModel();
            Expression<Func<tblAlergiasPersonal, bool>> predicado = p => p.idAlergia.Equals(_idAlergia) && p.idPersonal.Equals(_idPersonal);
            tblAlergiasPersonal tblAlergias = alergiasPersonalRepository.GetAll(predicado).FirstOrDefault<tblAlergiasPersonal>();


            alergiasPersonalDM.idAlergia = tblAlergias.idAlergia;
            alergiasPersonalDM.idAlergiasPersonal = tblAlergias.idAlergiasPersonal;
            alergiasPersonalDM.idPersonal = tblAlergias.idPersonal;
            alergiasPersonalDM.dteFechaRegistro = tblAlergias.dteFechaRegistro.Value;

            return alergiasPersonalDM;

        }
        /// <summary>
        /// Este metodo elimina la alergia personal
        /// </summary>
        /// <param name="alergiasPersonalDM"></param>
        /// <returns>true o false</returns>
        public bool DeleteAlergias(AlergiasPersonalDomainModel alergiasPersonalDM) {

            bool respuesta = false;
            Expression<Func<tblAlergiasPersonal, bool>> predicado = p => p.idAlergia.Equals(alergiasPersonalDM.idAlergia)
             && p.idPersonal.Equals(alergiasPersonalDM.idPersonal);
            alergiasPersonalRepository.Delete(predicado);
            respuesta = true;
            return respuesta;

        }
    }
}
