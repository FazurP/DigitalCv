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
                tblExperienciaLaboralInterna.idPeriodo = experienciaLaboralInternaDM.idPeriodo;
                tblExperienciaLaboralInterna.idPersonal = experienciaLaboralInternaDM.idPersonal;
                tblExperienciaLaboralInterna.idProgramaEduactivo = experienciaLaboralInternaDM.idProgramaEducativo;
                tblExperienciaLaboralInterna.idTipoContrato = experienciaLaboralInternaDM.idTipoContrato;
                tblExperienciaLaboralInterna.strActividadDesempenada = experienciaLaboralInternaDM.strActividadDesempeñada;
                tblExperienciaLaboralInterna.dteFechaInicio = experienciaLaboralInternaDM.dteFechaInicio;
                tblExperienciaLaboralInterna.dteFechaFin = experienciaLaboralInternaDM.dteFechaTermino;

                experienciaLaboralInternaRepository.Insert(tblExperienciaLaboralInterna);
                respuesta = true;
            }

            return respuesta;
        }

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
                experienciaLaboralInternaDM.idPeriodo = tblExperiencia.idPeriodo.Value;
                experienciaLaboralInternaDM.idPersonal = tblExperiencia.idPersonal.Value;
                experienciaLaboralInternaDM.idProgramaEducativo = tblExperiencia.idProgramaEduactivo.Value;
                experienciaLaboralInternaDM.idTipoContrato = tblExperiencia.idTipoContrato.Value;
                experienciaLaboralInternaDM.strActividadDesempeñada = tblExperiencia.strActividadDesempenada;
                experienciaLaboralInternaDM.dteFechaInicio = tblExperiencia.dteFechaInicio.Value;
                experienciaLaboralInternaDM.dteFechaTermino = tblExperiencia.dteFechaFin.Value;

                experienciaLaboralInternaDomainModels.Add(experienciaLaboralInternaDM);

            }

            return experienciaLaboralInternaDomainModels;
        }

        public ExperienciaLaboralInternaDomainModel GetExperiencia(int _idPersonal,int _idExperiencia)
        {
            ExperienciaLaboralInternaDomainModel experienciaLaboralInternaDM = new ExperienciaLaboralInternaDomainModel();

            Expression<Func<tblExperienciaLaboralInterna, bool>> predicate = p => p.idPersonal == _idPersonal && p.id
             == _idExperiencia;

            tblExperienciaLaboralInterna tblExperienciaLaboral = experienciaLaboralInternaRepository.GetAll(predicate).FirstOrDefault();

            experienciaLaboralInternaDM.id = tblExperienciaLaboral.id;
            experienciaLaboralInternaDM.idArea = tblExperienciaLaboral.idArea.Value;
            experienciaLaboralInternaDM.idPeriodo = tblExperienciaLaboral.idPeriodo.Value;
            experienciaLaboralInternaDM.idPersonal = tblExperienciaLaboral.idPersonal.Value;
            experienciaLaboralInternaDM.idProgramaEducativo = tblExperienciaLaboral.idProgramaEduactivo.Value;
            experienciaLaboralInternaDM.idTipoContrato = tblExperienciaLaboral.idTipoContrato.Value;
            experienciaLaboralInternaDM.strActividadDesempeñada = tblExperienciaLaboral.strActividadDesempenada;
            experienciaLaboralInternaDM.dteFechaInicio = tblExperienciaLaboral.dteFechaInicio.Value;
            experienciaLaboralInternaDM.dteFechaTermino = tblExperienciaLaboral.dteFechaFin.Value;

            return experienciaLaboralInternaDM;
        }

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
