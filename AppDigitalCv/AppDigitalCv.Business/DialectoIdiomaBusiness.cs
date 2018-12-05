using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddUpdateDialecto(IdiomaDialectoDomainModel idiomaDialectoDM)
        {
            bool respuesta = false;

            if (idiomaDialectoDM.idIdiomaDialectoPersonal > 0)
            {
                tblIdiomaDialectoPersonal idiomaDialecto = idiomaDialectoRepository.SingleOrDefault(p => p.idIdiomaDialectoPersonal == idiomaDialectoDM.idIdiomaDialectoPersonal);

                if (idiomaDialecto != null)
                {
                    idiomaDialecto.idDialecto = idiomaDialectoDM.idDialecto;
                    idiomaDialecto.strComunicacionPorcentaje = idiomaDialectoDM.strComunicacionPorcentaje;
                    idiomaDialecto.strEntendimientoPorcentaje = idiomaDialectoDM.strEntendimientoPorcentaje;
                    idiomaDialecto.strEscrituraProcentaje = idiomaDialectoDM.strEscrituraProcentaje;
                    idiomaDialecto.strLecturaPorcentaje = idiomaDialecto.strLecturaPorcentaje;
                    idiomaDialecto.idPersonal = idiomaDialectoDM.idPersonal;

                    idiomaDialectoRepository.Update(idiomaDialecto);
                    respuesta = true;
                }
            }
            else
            {
                tblIdiomaDialectoPersonal idiomaDialecto = new tblIdiomaDialectoPersonal();
                idiomaDialecto.idDialecto = idiomaDialectoDM.idDialecto;
                idiomaDialecto.strComunicacionPorcentaje = idiomaDialectoDM.strComunicacionPorcentaje;
                idiomaDialecto.strEntendimientoPorcentaje = idiomaDialectoDM.strEntendimientoPorcentaje;
                idiomaDialecto.strEscrituraProcentaje = idiomaDialectoDM.strEscrituraProcentaje;
                idiomaDialecto.strLecturaPorcentaje = idiomaDialectoDM.strLecturaPorcentaje;
                idiomaDialecto.idPersonal = idiomaDialectoDM.idPersonal;

                var record = idiomaDialectoRepository.Insert(idiomaDialecto);
                respuesta = true;
            }
            return respuesta;
        }
    }
}
