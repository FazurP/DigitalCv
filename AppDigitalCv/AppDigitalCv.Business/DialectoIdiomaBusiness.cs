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
        private readonly IdiomaDialectoRepository idiomaDialectoRepository;
        private readonly DialectosRepository dialectoRepository;

        public DialectoIdiomaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            idiomaDialectoRepository = new IdiomaDialectoRepository(unitOfWork);
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

            if (idiomaDialectoDM.IdIdiomaDialectoPersonal > 0)
            {
                tblIdiomaDialectoPersonal idiomaDialecto = idiomaDialectoRepository.SingleOrDefault(p => p.idIdiomaDialectoPersonal == idiomaDialectoDM.IdIdiomaDialectoPersonal);

                if (idiomaDialecto != null)
                {
                    idiomaDialecto.idDialecto = idiomaDialectoDM.IdDialecto;
                    idiomaDialecto.strComunicacionPorcentaje = idiomaDialectoDM.StrComunicacionPorcentaje;
                    idiomaDialecto.strEntendimientoPorcentaje = idiomaDialectoDM.StrEntendimientoPorcentaje;
                    idiomaDialecto.strEscrituraProcentaje = idiomaDialectoDM.StrEscrituraProcentaje;
                    idiomaDialecto.strLecturaPorcentaje = idiomaDialectoDM.StrLecturaPorcentaje;
                    idiomaDialecto.idPersonal = idiomaDialectoDM.IdPersonal;

                    idiomaDialectoRepository.Update(idiomaDialecto);
                    respuesta = true;
                }
            }
            else
            {
                if (idiomaDialectoRepository.Exists(p => p.idDialecto == idiomaDialectoDM.IdDialecto && p.idPersonal == idiomaDialectoDM.IdPersonal))
                {
                    return false;
                }
                else { 
                tblIdiomaDialectoPersonal idiomaDialecto = new tblIdiomaDialectoPersonal();
                idiomaDialecto.idDialecto = idiomaDialectoDM.IdDialecto;
                idiomaDialecto.strComunicacionPorcentaje = idiomaDialectoDM.StrComunicacionPorcentaje;
                idiomaDialecto.strEntendimientoPorcentaje = idiomaDialectoDM.StrEntendimientoPorcentaje;
                idiomaDialecto.strEscrituraProcentaje = idiomaDialectoDM.StrEscrituraProcentaje;
                idiomaDialecto.strLecturaPorcentaje = idiomaDialectoDM.StrLecturaPorcentaje;
                idiomaDialecto.idPersonal = idiomaDialectoDM.IdPersonal;

                var record = idiomaDialectoRepository.Insert(idiomaDialecto);
                respuesta = true;
                }
            }
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
            Expression<Func<tblIdiomaDialectoPersonal, bool>> predicado = p => p.idDialecto.Equals(_idDialecto) && p.idPersonal.Equals(_idPersonal);
            tblIdiomaDialectoPersonal tblIdioma = idiomaDialectoRepository.GetAll(predicado).FirstOrDefault<tblIdiomaDialectoPersonal>();

            idiomaDialectoDM.IdIdiomaDialectoPersonal = tblIdioma.idIdiomaDialectoPersonal;
            idiomaDialectoDM.IdDialecto = tblIdioma.idDialecto;
            idiomaDialectoDM.IdPersonal = tblIdioma.idPersonal;
            idiomaDialectoDM.StrComunicacionPorcentaje = tblIdioma.strComunicacionPorcentaje;
            idiomaDialectoDM.StrEntendimientoPorcentaje = tblIdioma.strEntendimientoPorcentaje;
            idiomaDialectoDM.StrEscrituraProcentaje = tblIdioma.strEscrituraProcentaje;
            idiomaDialectoDM.StrLecturaPorcentaje = tblIdioma.strLecturaPorcentaje;

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
            Expression<Func<tblIdiomaDialectoPersonal, bool>> predicado = p => p.idDialecto.Equals(idiomaDialectoDM.IdDialecto)
             && p.idPersonal.Equals(idiomaDialectoDM.IdPersonal);
            idiomaDialectoRepository.Delete(predicado);
            respuesta = true;
            return respuesta;

        }


    }
}
