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

        public DialectoBusiness(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;


        }
        /// <summary>
        /// Este metodo de encarga de obtener todos los dialectos que le correspondan al personal
        /// </summary>
        /// <param name="_idPersonal"></param>
        /// <returns>una lista con los dialectos</returns>
        public List<DialectoDomainModel> GetDialectosByIdPersonal(int _idPersonal)
        {
            List<DialectoDomainModel> dialectoDM = new List<DialectoDomainModel>();
          

            return dialectoDM;
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
