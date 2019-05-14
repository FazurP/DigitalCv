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
            return respuesta;
        }
    }
}
