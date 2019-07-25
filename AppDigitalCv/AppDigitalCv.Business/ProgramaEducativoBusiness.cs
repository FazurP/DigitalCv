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
    public class ProgramaEducativoBusiness : IProgramaEducativoBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ProgramaEducativoRepository programaEducativoRepository;

        public ProgramaEducativoBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            programaEducativoRepository = new ProgramaEducativoRepository(unitofWork);
        }

        public List<ProgramaEducativoDomainModel> GetProgramasEducativos()
        {
            List<ProgramaEducativoDomainModel> programasEducativos = new List<ProgramaEducativoDomainModel>();
            programasEducativos = programaEducativoRepository.GetAll().Select(p => new ProgramaEducativoDomainModel
            {
                idProgramaEducativo = p.idProgramaEducativo,
                strDescripcion = p.strDescripcion,
                strObservacion = p.strObservacion,
                idInstitucionSuperior = p.idInstitucionSuperior,
                idTipoEstudio = p.idTipoEstudio
                
            }).ToList<ProgramaEducativoDomainModel>();

            ProgramaEducativoDomainModel programaEducativoDM = new ProgramaEducativoDomainModel();
            programaEducativoDM.idProgramaEducativo = 0;
            programaEducativoDM.strDescripcion = "--Seleccionar--";
            programasEducativos.Insert(0,programaEducativoDM);
            return programasEducativos;
        }

        public List<ProgramaEducativoDomainModel> GetProgramasEducativosByTipoEstudio(int _idTipoEstudio)
        {
            List<ProgramaEducativoDomainModel> programas = new List<ProgramaEducativoDomainModel>();

            Expression<Func<catProgramaEducativo, bool>> predicate = p => p.idTipoEstudio == _idTipoEstudio;
            List<catProgramaEducativo> catProgramaEducativos = programaEducativoRepository.GetAll(predicate).ToList();

            foreach (catProgramaEducativo item in catProgramaEducativos)
            {
                ProgramaEducativoDomainModel programaEducativoDM = new ProgramaEducativoDomainModel();

                programaEducativoDM.idInstitucionSuperior = item.idInstitucionSuperior;
                programaEducativoDM.idProgramaEducativo = item.idProgramaEducativo;
                programaEducativoDM.idTipoEstudio = item.idTipoEstudio;
                programaEducativoDM.strDescripcion = item.strDescripcion;
                programaEducativoDM.strObservacion = item.strObservacion;

                programas.Add(programaEducativoDM);
            }

            return programas;
        }
    }
}
