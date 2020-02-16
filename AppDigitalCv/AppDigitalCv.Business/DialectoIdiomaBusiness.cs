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
        private readonly LenguasRepository lenguasRepository;

        public DialectoIdiomaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            dialectoRepository = new DialectosRepository(unitOfWork);
            lenguasRepository = new LenguasRepository(unitOfWork);
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
        public bool AddUpdateDialecto(LenguasDomainModel lenguas)
        {
            bool respuesta = false;

            if (lenguas.id > 0)
            {
                TblLenguas tblLenguas = lenguasRepository.GetAll().Where(p => p.id == lenguas.id).FirstOrDefault();

                if (tblLenguas != null)
                {
                    tblLenguas.strComunicacion = lenguas.strComunicacion;
                    tblLenguas.strEntendimiento = lenguas.strEntendimiento;
                    tblLenguas.strEscritura = lenguas.strEscritura;
                    tblLenguas.strLectura = lenguas.strLectura;

                    lenguasRepository.Update(tblLenguas);
                    respuesta = true;
                }
            }
            else 
            {
                TblLenguas tblLenguas = new TblLenguas();

                tblLenguas.idLengua = lenguas.idLengua;
                tblLenguas.idPersonal = lenguas.idPersonal;
                tblLenguas.strComunicacion = lenguas.strComunicacion;
                tblLenguas.strEntendimiento = lenguas.strEntendimiento;
                tblLenguas.strEscritura = lenguas.strEscritura;
                tblLenguas.strLectura = lenguas.strLectura;

                lenguasRepository.Insert(tblLenguas);
                respuesta = true;
            }
           
            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de obtener un dialecto personal mediante su id y el id de la persona.
        /// </summary>
        /// <param name="_idDialecto"></param>
        /// <param name="_idPersonal"></param>
        /// <returns>true o false</returns>
        public LenguasDomainModel GetDialectoPersonales(int _idDialecto, int _idPersonal)
        {

            LenguasDomainModel lenguasDM = new LenguasDomainModel();
            TblLenguas lenguas = new TblLenguas();

            lenguas = lenguasRepository.GetAll().Where(p => p.id == _idDialecto && p.idPersonal == _idPersonal).FirstOrDefault();

            lenguasDM.id = lenguas.id;
            lenguasDM.idLengua = lenguas.idLengua.Value;
            lenguasDM.idPersonal = lenguas.idPersonal.Value;
            lenguasDM.strComunicacion = lenguas.strComunicacion;
            lenguasDM.strEntendimiento = lenguas.strEntendimiento;
            lenguasDM.strEscritura = lenguas.strEscritura;
            lenguasDM.strLectura = lenguas.strLectura;
            lenguasDM.Dialecto = new DialectoDomainModel { strDescripcion=lenguas.CatLenguas.strDescripcion};

            return lenguasDM;

        }
        /// <summary>
        /// Este metodo se encarga de eliminar un dialecto mediante su id y el id de la persona
        /// </summary>
        /// <param name="idiomaDialectoDM"></param>
        /// <returns>true o false</returns>
        public bool DeleteDialectoDialectos(LenguasDomainModel lenguasDomainModel)
        {

            bool respuesta = false;

            TblLenguas lenguas = lenguasRepository.GetAll().Where(p => p.id == lenguasDomainModel.id).FirstOrDefault();

            if (lenguas != null)
            {
                lenguasRepository.Delete(p => p.id == lenguasDomainModel.id);
                respuesta = true;
            }
           
            return respuesta;

        }


    }
}
