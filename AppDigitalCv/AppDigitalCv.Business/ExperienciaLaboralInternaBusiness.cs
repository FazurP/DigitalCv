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

        public List<ExperienciaLaboralInternaDomainModel> GetExperienciasByPersonal()
        {
            List<ExperienciaLaboralInternaDomainModel> experienciaLaboralInternaDomainModels = new List<ExperienciaLaboralInternaDomainModel>();

            return experienciaLaboralInternaDomainModels;
        }
    }
}
