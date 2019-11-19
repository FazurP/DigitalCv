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
        private readonly IdiomasRepository idiomasRepository;

        public IdiomasBusiness(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;
            idiomasRepository = new IdiomasRepository(_unitOfWork);

        }

        public List<IdiomaDomainModel> GetAllIdiomas() 
        {

            List<IdiomaDomainModel> idiomaDomainModels = new List<IdiomaDomainModel>();
            List<catIdioma> idiomas = new List<catIdioma>();

            idiomas = idiomasRepository.GetAll().ToList();

            foreach (catIdioma item in idiomas)
            {
                IdiomaDomainModel idiomaDomainModel = new IdiomaDomainModel();

                idiomaDomainModel.idIdioma = item.idIdioma;
                idiomaDomainModel.strDescripcion = item.strDescripcion;
                idiomaDomainModel.strObservacion = item.strObservacion;

                idiomaDomainModels.Add(idiomaDomainModel);
            }

            IdiomaDomainModel idiomaDomainModel1 = new IdiomaDomainModel();

            idiomaDomainModel1.idIdioma = 0;
            idiomaDomainModel1.strDescripcion = "Seleccionar";

            idiomaDomainModels.Insert(0, idiomaDomainModel1);

            return idiomaDomainModels;

        }


        public List<IdiomaDomainModel> GetIdiomasByIdPersonal(int _idPersonal) {
            List<IdiomaDomainModel> idiomasDM = new List<IdiomaDomainModel>();
           

            return idiomasDM;
        }

        public IdiomaDomainModel GetIdioma(int idIdioma, int idPersona)
        {

            IdiomaDomainModel idiomaDM = new IdiomaDomainModel();

          

            return idiomaDM;


        }
    }
}
