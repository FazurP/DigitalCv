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
    public class ExperienciaLaboralInternaBusiness : IExperienciaLaboralInternaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ExperienciaLaboralInternaRepository experienciaLaboralInternaRepository;

        public ExperienciaLaboralInternaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            experienciaLaboralInternaRepository = new ExperienciaLaboralInternaRepository(unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de insertar o actualizar un objeto de la persona en la base de datos.
        /// </summary>
        /// <param name="experienciaLaboralInternaDM"></param>
        /// <returns>true o false</returns>
        public bool AddUpdateExperienciaLaboralInterna(ExperienciaLaboralInternaDomainModel experienciaLaboralInternaDM)
        {
            bool respuesta = false;

            if (experienciaLaboralInternaDM.id > 0)
            {
                tblExperienciaLaboralInterna tblExperienciaLaboralInterna = experienciaLaboralInternaRepository.
                    SingleOrDefault(p => p.id== experienciaLaboralInternaDM.id);

                if (tblExperienciaLaboralInterna != null)
                {
                    tblExperienciaLaboralInterna.id = experienciaLaboralInternaDM.id;
                    tblExperienciaLaboralInterna.strActividadDesempenada = experienciaLaboralInternaDM.strActividadDesempeñada;
                    tblExperienciaLaboralInterna.dteFechaInicio = experienciaLaboralInternaDM.dteFechaInicio;
                    tblExperienciaLaboralInterna.dteFechaFin = experienciaLaboralInternaDM.dteFechaTermino;

                    experienciaLaboralInternaRepository.Update(tblExperienciaLaboralInterna);
                    respuesta = true;
                }
            }
            else {

                tblExperienciaLaboralInterna tblExperienciaLaboralInterna = new tblExperienciaLaboralInterna();

                tblExperienciaLaboralInterna.id = experienciaLaboralInternaDM.id;
                tblExperienciaLaboralInterna.idArea = experienciaLaboralInternaDM.idArea;
                tblExperienciaLaboralInterna.idPersonal = experienciaLaboralInternaDM.idPersonal;
                tblExperienciaLaboralInterna.strActividadDesempenada = experienciaLaboralInternaDM.strActividadDesempeñada;
                tblExperienciaLaboralInterna.dteFechaInicio = experienciaLaboralInternaDM.dteFechaInicio;
                tblExperienciaLaboralInterna.dteFechaFin = experienciaLaboralInternaDM.dteFechaTermino;
                tblExperienciaLaboralInterna.strTipoProfesor = experienciaLaboralInternaDM.strTipoProfesor;
                tblExperienciaLaboralInterna.bitPuestoActual = experienciaLaboralInternaDM.bitPuestoActual;

                experienciaLaboralInternaRepository.Insert(tblExperienciaLaboralInterna);
                respuesta = true;
            }

            return respuesta;
        }
        /// <summary>
        /// Este metodo se encarga de obtener una lista de objetos de una persona desde la base de datos.
        /// </summary>
        /// <param name="_idPersonal"></param>
        /// <returns>una lista con los objetos</returns>
        public List<ExperienciaLaboralInternaDomainModel> GetExperienciasByPersonal(int _idPersonal)
        {
            List<ExperienciaLaboralInternaDomainModel> experienciaLaboralInternaDomainModels = new List<ExperienciaLaboralInternaDomainModel>();

            Expression<Func<tblExperienciaLaboralInterna, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblExperienciaLaboralInterna> tblExperiencias = experienciaLaboralInternaRepository.GetAll(predicate).ToList();

            foreach (tblExperienciaLaboralInterna tblExperiencia in tblExperiencias)
            {
                ExperienciaLaboralInternaDomainModel experienciaLaboralInternaDM = new ExperienciaLaboralInternaDomainModel();

                experienciaLaboralInternaDM.id = tblExperiencia.id;
                experienciaLaboralInternaDM.idArea = tblExperiencia.idArea.Value;
                experienciaLaboralInternaDM.idPersonal = tblExperiencia.idPersonal.Value;
                experienciaLaboralInternaDM.strActividadDesempeñada = tblExperiencia.strActividadDesempenada;
                experienciaLaboralInternaDM.dteFechaInicio = tblExperiencia.dteFechaInicio;
                experienciaLaboralInternaDM.dteFechaTermino = tblExperiencia.dteFechaFin;
                experienciaLaboralInternaDM.strTipoProfesor = tblExperiencia.strTipoProfesor;

                experienciaLaboralInternaDM.Area = new AreaDomainModel
                {
                    strDescripcion = tblExperiencia.catArea.strDescripcion
                };
               

                experienciaLaboralInternaDomainModels.Add(experienciaLaboralInternaDM);

            }

            return experienciaLaboralInternaDomainModels;
        }
        /// <summary>
        /// Este metodo se encarga de obtener un objeto de una persona desde la base de datos.
        /// </summary>
        /// <param name="_idPersonal"></param>
        /// <param name="_idExperiencia"></param>
        /// <returns>un objeto</returns>
        public ExperienciaLaboralInternaDomainModel GetExperiencia(int _idPersonal,int _idExperiencia)
        {
            ExperienciaLaboralInternaDomainModel experienciaLaboralInternaDM = new ExperienciaLaboralInternaDomainModel();

            Expression<Func<tblExperienciaLaboralInterna, bool>> predicate = p => p.idPersonal == _idPersonal && p.id
             == _idExperiencia;

            tblExperienciaLaboralInterna tblExperienciaLaboral = experienciaLaboralInternaRepository.GetAll(predicate).FirstOrDefault();

            experienciaLaboralInternaDM.id = tblExperienciaLaboral.id;
            experienciaLaboralInternaDM.idArea = tblExperienciaLaboral.idArea.Value;
            experienciaLaboralInternaDM.idPersonal = tblExperienciaLaboral.idPersonal.Value;
            experienciaLaboralInternaDM.strActividadDesempeñada = tblExperienciaLaboral.strActividadDesempenada;
            experienciaLaboralInternaDM.dteFechaInicio = tblExperienciaLaboral.dteFechaInicio;
            experienciaLaboralInternaDM.dteFechaTermino = tblExperienciaLaboral.dteFechaFin;
            experienciaLaboralInternaDM.strTipoProfesor = tblExperienciaLaboral.strTipoProfesor;
            experienciaLaboralInternaDM.Area = new AreaDomainModel
            {
                strDescripcion = tblExperienciaLaboral.catArea.strDescripcion
            };
           

            return experienciaLaboralInternaDM;
        }
        /// <summary>
        /// Este metodo se encarga de eliminar un objeto de una persona de la base de datos.
        /// </summary>
        /// <param name="_idPersonal"></param>
        /// <param name="_idExperiencia"></param>
        /// <returns>true o false</returns>
        public bool DeleteExperiencias(int _idPersonal, int _idExperiencia)
        {
            bool respuesta = false;
            Expression<Func<tblExperienciaLaboralInterna, bool>> predicare = p => p.idPersonal == _idPersonal
             && p.id == _idExperiencia;

            experienciaLaboralInternaRepository.Delete(predicare);

            respuesta = true;

            return respuesta;

        }
    }
}
