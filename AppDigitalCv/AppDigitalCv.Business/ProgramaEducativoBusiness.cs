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
    }
}
