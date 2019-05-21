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
        /// <summary>
        /// Este metodo se encarga de insertar o actualizar un idioma.
        /// </summary>
        /// <param name="idiomaDialectoDM"></param>
        /// <returns>true o false</returns>
        public bool AddUpdateIdioma(IdiomaDialectoDomainModel idiomaDialectoDM)
        {
            bool respuesta = false;

            if (idiomaDialectoDM.IdIdiomaDialectoPersonal > 0)
            {

                tblIdiomaDialectoPersonal idiomaDialecto = idiomaDialectoRepository.SingleOrDefault(p => p.idIdiomaDialectoPersonal == idiomaDialectoDM.IdIdiomaDialectoPersonal);

                if (idiomaDialecto != null)
                {
                    idiomaDialecto.idIdioma = idiomaDialectoDM.IdIdioma;
                    idiomaDialecto.strComunicacionPorcentaje = idiomaDialectoDM.StrComunicacionPorcentaje;
                    idiomaDialecto.strEntendimientoPorcentaje = idiomaDialectoDM.StrEntendimientoPorcentaje;
                    idiomaDialecto.strEscrituraProcentaje = idiomaDialectoDM.StrEscrituraProcentaje;
                    idiomaDialecto.strLecturaPorcentaje = idiomaDialectoDM.StrLecturaPorcentaje;
                    idiomaDialecto.idPersonal = idiomaDialectoDM.IdPersonal;

                    idiomaDialectoRepository.Update(idiomaDialecto);

                    respuesta = true;
                }
            }
            else{
                if (idiomaDialectoRepository.Exists(p => p.idIdioma == idiomaDialectoDM.IdIdioma && p.idPersonal == idiomaDialectoDM.IdPersonal))
                {
                    return false;
                }
                else
                {
                    tblIdiomaDialectoPersonal idiomaDialecto = new tblIdiomaDialectoPersonal();
                    idiomaDialecto.idIdioma = idiomaDialectoDM.IdIdioma;
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
        /// Este metodo se encarga de obtener un idioma mediante el idIdioma y idPersonal
        /// </summary>
        /// <param name="_idIdioma"></param>
        /// <param name="_idPersonal"></param>
        /// <returns>un objeto con el idioma</returns>
        public IdiomaDialectoDomainModel GetIdiomasPersonales(int _idIdioma, int _idPersonal)
        {

            IdiomaDialectoDomainModel idiomaDialectoDM = new IdiomaDialectoDomainModel();
            Expression<Func<tblIdiomaDialectoPersonal, bool>> predicado = p => p.idIdioma.Equals(_idIdioma) && p.idPersonal.Equals(_idPersonal);
            tblIdiomaDialectoPersonal tblIdioma = idiomaDialectoRepository.GetAll(predicado).FirstOrDefault<tblIdiomaDialectoPersonal>();

            idiomaDialectoDM.IdIdiomaDialectoPersonal = tblIdioma.idIdiomaDialectoPersonal;
            idiomaDialectoDM.IdIdioma = tblIdioma.idIdioma;
            idiomaDialectoDM.IdPersonal = tblIdioma.idPersonal;
            idiomaDialectoDM.StrComunicacionPorcentaje = tblIdioma.strComunicacionPorcentaje;
            idiomaDialectoDM.StrEntendimientoPorcentaje = tblIdioma.strEntendimientoPorcentaje;
            idiomaDialectoDM.StrEscrituraProcentaje = tblIdioma.strEscrituraProcentaje;
            idiomaDialectoDM.StrLecturaPorcentaje = tblIdioma.strLecturaPorcentaje;

            return idiomaDialectoDM;

        }
        /// <summary>
        /// Este metodo se encarga de eliminar un idioma
        /// </summary>
        /// <param name="idiomaDialectoDM"></param>
        /// <returns>true o false</returns>
        public bool DeleteIdiomasDialectos(IdiomaDialectoDomainModel idiomaDialectoDM)
        {

            bool respuesta = false;
            Expression<Func<tblIdiomaDialectoPersonal, bool>> predicado = p => p.idIdioma.Equals(idiomaDialectoDM.IdIdioma)
             && p.idPersonal.Equals(idiomaDialectoDM.IdPersonal);
            idiomaDialectoRepository.Delete(predicado);
            respuesta = true;
            return respuesta;

        }


    }
}
