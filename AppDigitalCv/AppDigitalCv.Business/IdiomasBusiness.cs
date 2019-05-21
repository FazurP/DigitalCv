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
    public class IdiomasBusiness : IIdiomaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IdiomaDialectoRepository idiomaDialectoRepository;

        public IdiomasBusiness(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;

            idiomaDialectoRepository = new IdiomaDialectoRepository(_unitOfWork);

        }

        public List<IdiomaDomainModel> GetIdiomasByIdPersonal(int _idPersonal) {
            List<IdiomaDomainModel> idiomasDM = new List<IdiomaDomainModel>();
            Expression<Func<tblIdiomaDialectoPersonal, bool>> predicado = p => p.idPersonal.Equals(_idPersonal) && p.idIdioma != null;
            List<tblIdiomaDialectoPersonal> tblIdiomas = idiomaDialectoRepository.GetAll(predicado).ToList<tblIdiomaDialectoPersonal>();

            
            foreach (tblIdiomaDialectoPersonal idioma in tblIdiomas)
            {
                IdiomaDomainModel idiomas = new IdiomaDomainModel();
            
            
                    idiomas.idIdioma = idioma.catIdioma.idIdioma;
                    idiomas.strDescripcion = idioma.catIdioma.strDescripcion;
                    idiomas.strObservacion = idioma.catIdioma.strObservacion;
                    idiomasDM.Add(idiomas);
                
            
               
            }

            return idiomasDM;
        }

        public IdiomaDomainModel GetIdioma(int idIdioma, int idPersona)
        {

            IdiomaDomainModel idiomaDM = new IdiomaDomainModel();

            Expression<Func<tblIdiomaDialectoPersonal, bool>> predicado = p => p.idPersonal.Equals(idPersona) && p.idIdioma.Equals(idIdioma);
            tblIdiomaDialectoPersonal tblIdioma = idiomaDialectoRepository.GetAll(predicado).FirstOrDefault<tblIdiomaDialectoPersonal>();

            idiomaDM.idIdioma = tblIdioma.catIdioma.idIdioma;
            idiomaDM.strDescripcion = tblIdioma.catIdioma.strDescripcion;
            idiomaDM.strObservacion = tblIdioma.catIdioma.strObservacion;

            return idiomaDM;


        }
    }
}
