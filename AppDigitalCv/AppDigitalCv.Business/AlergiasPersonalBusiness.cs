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

            //AlergiasDomainModel alergiasDomainModel = new AlergiasDomainModel();
            //alergiasDomainModel.StrDescripcion = tblAlergias.catAlergias.strDescripcion;

            //alergias.Add(alergiasDomainModel);

            //return alergias;
        }
    }
}
