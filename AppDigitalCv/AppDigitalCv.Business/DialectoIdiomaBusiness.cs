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
    public class DialectoIdiomaBusiness : IDialectoIdiomaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DialectosRepository dialectoRepository;

        public DialectoIdiomaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            dialectoRepository = new DialectosRepository(unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de obtener todos los dialecto para cargarlos en la lista.
        /// </summary>
        /// <returns>una lista con los dialectos</returns>
        public List<DialectoDomainModel> GetDialecto()
        {
            List<DialectoDomainModel> dialectos = new List<DialectoDomainModel>();
            dialectos = dialectoRepository.GetAll().Select(p => new DialectoDomainModel { idDialecto = p.idDialecto, strDescripcion = p.strDescripcion }).ToList();
            DialectoDomainModel inicial = new DialectoDomainModel();
            inicial.idDialecto = 0;
            inicial.strDescripcion = "-- Seleccionar --";
            dialectos.Insert(0, inicial);
            return dialectos;
        }
        /// <summary>
        /// Este metodo de encarga de actualizar o insertar un dialecto personal
        /// </summary>
        /// <param name="idiomaDialectoDM"></param>
        /// <returns></returns>
        public bool AddUpdateDialecto(IdiomaDialectoDomainModel idiomaDialectoDM)
        {
            bool respuesta = false;

           
            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de obtener un dialecto personal mediante su id y el id de la persona.
        /// </summary>
        /// <param name="_idDialecto"></param>
        /// <param name="_idPersonal"></param>
        /// <returns>true o false</returns>
        public IdiomaDialectoDomainModel GetDialectoPersonales(int _idDialecto, int _idPersonal)
        {

            IdiomaDialectoDomainModel idiomaDialectoDM = new IdiomaDialectoDomainModel();
          

            return idiomaDialectoDM;

        }
        /// <summary>
        /// Este metodo se encarga de eliminar un dialecto mediante su id y el id de la persona
        /// </summary>
        /// <param name="idiomaDialectoDM"></param>
        /// <returns>true o false</returns>
        public bool DeleteDialectoDialectos(IdiomaDialectoDomainModel idiomaDialectoDM)
        {

            bool respuesta = false;
            
            respuesta = true;
            return respuesta;

        }


    }
}
