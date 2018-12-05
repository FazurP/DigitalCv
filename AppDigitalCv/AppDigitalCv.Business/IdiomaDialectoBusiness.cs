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
    public class IdiomaDialectoBusiness : IIdiomaDialectoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IdiomaDialectoRepository idiomaDialectoRepository;
        private readonly IdiomasRepository idiomaRepository;

        public IdiomaDialectoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            idiomaDialectoRepository = new IdiomaDialectoRepository(unitOfWork);
            idiomaRepository = new IdiomasRepository(unitOfWork);
        }

        public List<IdiomaDomainModel> GetIdioma()
        {
            List<IdiomaDomainModel> idiomas = new List<IdiomaDomainModel>();
            idiomas = idiomaRepository.GetAll().Select(p => new IdiomaDomainModel { idIdioma = p.idIdioma, strDescripcion = p.strDescripcion }).ToList();
            IdiomaDomainModel inicial = new IdiomaDomainModel();
            inicial.idIdioma = 0;
            inicial.strDescripcion = "-- Seleccionar --";
            idiomas.Insert(0, inicial);
            return idiomas;
        }

        public List<IdiomaDialectoDomainModel> GetIdiomaDialecto()
        {
            throw new NotImplementedException();
        }

        public bool AddUpdateIdioma(IdiomaDialectoDomainModel idiomaDialectoDM)
        {
            bool respuesta = false;

            if (idiomaDialectoDM.idIdiomaDialectoPersonal > 0)
            {

                tblIdiomaDialectoPersonal idiomaDialecto = idiomaDialectoRepository.SingleOrDefault(p => p.idIdiomaDialectoPersonal == idiomaDialectoDM.idIdiomaDialectoPersonal);

                if (idiomaDialecto != null)
                {
                    idiomaDialecto.idIdioma = idiomaDialectoDM.idIdioma;
                    idiomaDialecto.strComunicacionPorcentaje = idiomaDialectoDM.strComunicacionPorcentaje;
                    idiomaDialecto.strEntendimientoPorcentaje = idiomaDialectoDM.strEntendimientoPorcentaje;
                    idiomaDialecto.strEscrituraProcentaje = idiomaDialectoDM.strEscrituraProcentaje;
                    idiomaDialecto.strLecturaPorcentaje = idiomaDialecto.strLecturaPorcentaje;
                    idiomaDialecto.idPersonal = idiomaDialectoDM.idPersonal;

                    idiomaDialectoRepository.Update(idiomaDialecto);

                    respuesta = true;
                }
            }
            else{

                tblIdiomaDialectoPersonal idiomaDialecto = new tblIdiomaDialectoPersonal();
                idiomaDialecto.idIdioma = idiomaDialectoDM.idIdioma;
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
