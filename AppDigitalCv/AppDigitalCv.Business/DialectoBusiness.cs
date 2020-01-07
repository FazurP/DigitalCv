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
    public class DialectoBusiness : IDialectoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly LenguasRepository lenguasRepository;

        public DialectoBusiness(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;
            lenguasRepository = new LenguasRepository(unitOfWork);


        }
        /// <summary>
        /// Este metodo de encarga de obtener todos los dialectos que le correspondan al personal
        /// </summary>
        /// <param name="_idPersonal"></param>
        /// <returns>una lista con los dialectos</returns>
        public List<LenguasDomainModel> GetDialectosByIdPersonal(int _idPersonal)
        {
            List<LenguasDomainModel> lenguasDM = new List<LenguasDomainModel>();
            List<TblLenguas> lenguas = new List<TblLenguas>();


            lenguas = lenguasRepository.GetAll().Where(p => p.idPersonal == _idPersonal).ToList();

            foreach (TblLenguas item in lenguas)
            {
                LenguasDomainModel lenguaDM = new LenguasDomainModel();

                lenguaDM.id = item.id;
                lenguaDM.idLengua = item.idLengua.Value;
                lenguaDM.idPersonal = item.idPersonal.Value;
                lenguaDM.strComunicacion = item.strComunicacion;
                lenguaDM.strEntendimiento = item.strEntendimiento;
                lenguaDM.strEscritura = item.strEscritura;
                lenguaDM.strLectura = item.strLectura;
                lenguaDM.Dialecto = new DialectoDomainModel { strDescripcion = item.CatLenguas.strDescripcion};

                lenguasDM.Add(lenguaDM);
            }


            return lenguasDM;
        }

        /// <summary>
        /// Este metodo se encarga de obtener solo un dialecto en especifico de una persona
        /// </summary>
        /// <param name="idDielecto"></param>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public DialectoDomainModel GetDialecto(int idDielecto, int idPersona)
        {

            DialectoDomainModel idiomaDM = new DialectoDomainModel();

         

            return idiomaDM;


        }


    }

}
