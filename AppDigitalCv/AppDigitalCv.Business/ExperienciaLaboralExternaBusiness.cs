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
    public class ExperienciaLaboralExternaBusiness : IExperienciaLaboralExterna
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ExperienciaLaboralExternaRepository experienciaLaboralExternaRepository;

        public ExperienciaLaboralExternaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            experienciaLaboralExternaRepository = new ExperienciaLaboralExternaRepository(unitofWork);
        }

        public bool AddUpdateExperiencia(ExperienciaLaboralExternaDomainModel experienciaLaboralExternaDM)
        {
            bool respuesta = false;

            if (experienciaLaboralExternaDM.id > 0)
            {
                Expression<Func<tblExperienciaLaboralExterna, bool>> predicate = p => p.idPersonal == experienciaLaboralExternaDM
                 .idPersonal && p.idDocumento == experienciaLaboralExternaDM.idDocumento;
                tblExperienciaLaboralExterna tblExperiencia = experienciaLaboralExternaRepository.SingleOrDefault(predicate);

                if (tblExperiencia != null)
                {
                    tblExperiencia.strInstitucionEmpresa = experienciaLaboralExternaDM.strInstitucionEmpresa;
                    tblExperiencia.strActividades = experienciaLaboralExternaDM.strActividades;
                    tblExperiencia.strMotivoConclucion = experienciaLaboralExternaDM.strMotivoConclusion;
                    tblExperiencia.strPuestoDesempeñado = experienciaLaboralExternaDM.strPuestoDesempeñado;
                    tblExperiencia.dteFechaInicio = experienciaLaboralExternaDM.dteFechaInicio;
                    tblExperiencia.dteFechaFinal = experienciaLaboralExternaDM.dteFechaFinal;
                    experienciaLaboralExternaRepository.Update(tblExperiencia);

                    respuesta = true;

                }
            }
            else
            {
                tblExperienciaLaboralExterna tblExperiencia = new tblExperienciaLaboralExterna();
                tblExperiencia.id = experienciaLaboralExternaDM.id;
                tblExperiencia.idDocumento = experienciaLaboralExternaDM.idDocumento;
                tblExperiencia.idPeriodo = experienciaLaboralExternaDM.idPeriodo;
                tblExperiencia.idPersonal = experienciaLaboralExternaDM.idPersonal;
                tblExperiencia.idTipoPersonal = experienciaLaboralExternaDM.idTipoPersonal;
                tblExperiencia.strActividades = experienciaLaboralExternaDM.strActividades;
                tblExperiencia.strInstitucionEmpresa = experienciaLaboralExternaDM.strInstitucionEmpresa;
                tblExperiencia.strMotivoConclucion = experienciaLaboralExternaDM.strMotivoConclusion;
                tblExperiencia.strPuestoDesempeñado = experienciaLaboralExternaDM.strPuestoDesempeñado;
                tblExperiencia.dteFechaInicio = experienciaLaboralExternaDM.dteFechaInicio;
                tblExperiencia.dteFechaFinal = experienciaLaboralExternaDM.dteFechaFinal;
                experienciaLaboralExternaRepository.Insert(tblExperiencia);
                respuesta = true;
            }

            return respuesta;
        }

        public List<ExperienciaLaboralExternaDomainModel> GetExperienciaLaboralByPersonal (int idPersonal)
        {
            List<ExperienciaLaboralExternaDomainModel> experienciaLaboralExterna = new List<ExperienciaLaboralExternaDomainModel>();

            Expression<Func<tblExperienciaLaboralExterna, bool>> predicate = p => p.idPersonal == idPersonal;
            List<tblExperienciaLaboralExterna> tblExperiencia = experienciaLaboralExternaRepository.GetAll(predicate).ToList();

            foreach (tblExperienciaLaboralExterna experiencia in tblExperiencia)
            {
                ExperienciaLaboralExternaDomainModel experienciaLaboralExternaDM = new ExperienciaLaboralExternaDomainModel();

                experienciaLaboralExternaDM.id = experiencia.id;
                experienciaLaboralExternaDM.idDocumento = experiencia.idDocumento.Value;
                experienciaLaboralExternaDM.idPeriodo = experiencia.idPeriodo.Value;
                experienciaLaboralExternaDM.idPersonal = experiencia.idPersonal.Value;
                experienciaLaboralExternaDM.idTipoPersonal = experiencia.idTipoPersonal.Value;
                experienciaLaboralExternaDM.strActividades = experiencia.strActividades;
                experienciaLaboralExternaDM.strInstitucionEmpresa = experiencia.strInstitucionEmpresa;
                experienciaLaboralExternaDM.strMotivoConclusion = experiencia.strMotivoConclucion;
                experienciaLaboralExternaDM.strPuestoDesempeñado = experiencia.strPuestoDesempeñado;
                experienciaLaboralExternaDM.dteFechaInicio = experiencia.dteFechaInicio.Value;
                experienciaLaboralExternaDM.dteFechaFinal = experiencia.dteFechaFinal.Value;

                experienciaLaboralExterna.Add(experienciaLaboralExternaDM);

            }

            return experienciaLaboralExterna;
        }

        public ExperienciaLaboralExternaDomainModel GetExperienciaLaboral(int idDocumento,int idPersonal)
        {

            ExperienciaLaboralExternaDomainModel experienciaLaboralDM = new ExperienciaLaboralExternaDomainModel();

            Expression<Func<tblExperienciaLaboralExterna, bool>> predicate = p => p.idDocumento == idDocumento && p.idPersonal
             == idPersonal;

            tblExperienciaLaboralExterna tblExperiencia = experienciaLaboralExternaRepository.
                GetAll(predicate).FirstOrDefault<tblExperienciaLaboralExterna>();

            experienciaLaboralDM.id = tblExperiencia.id;
            experienciaLaboralDM.idDocumento = tblExperiencia.idDocumento.Value;
            experienciaLaboralDM.idPeriodo = tblExperiencia.idPeriodo.Value;
            experienciaLaboralDM.idPersonal = tblExperiencia.idPersonal.Value;
            experienciaLaboralDM.idTipoPersonal = tblExperiencia.idTipoPersonal.Value;
            experienciaLaboralDM.strActividades = tblExperiencia.strActividades;
            experienciaLaboralDM.strInstitucionEmpresa = tblExperiencia.strInstitucionEmpresa;
            experienciaLaboralDM.strMotivoConclusion = tblExperiencia.strMotivoConclucion;
            experienciaLaboralDM.strPuestoDesempeñado = tblExperiencia.strPuestoDesempeñado;
            experienciaLaboralDM.dteFechaInicio = tblExperiencia.dteFechaInicio.Value;
            experienciaLaboralDM.dteFechaFinal = tblExperiencia.dteFechaFinal.Value;

            return experienciaLaboralDM;

        }

        public ExperienciaLaboralExternaDomainModel GetExperienciaLaboralEdit(int idDocumento, int idPersonal)
        {
            ExperienciaLaboralExternaDomainModel experienciaLaboralDM = new ExperienciaLaboralExternaDomainModel();
            Expression<Func<tblExperienciaLaboralExterna, bool>> predicate = p => p.idDocumento == idDocumento &&
             p.idPersonal == idPersonal;

            tblExperienciaLaboralExterna tblExperiencia = experienciaLaboralExternaRepository.GetAll(predicate).FirstOrDefault();

            experienciaLaboralDM.id = tblExperiencia.id;
            experienciaLaboralDM.documento = tblExperiencia.catDocumentos.strUrl;
            experienciaLaboralDM.periodo = tblExperiencia.catPeriodo.strDescripcion;
            experienciaLaboralDM.strActividades = tblExperiencia.strActividades;
            experienciaLaboralDM.strInstitucionEmpresa = tblExperiencia.strInstitucionEmpresa;
            experienciaLaboralDM.strMotivoConclusion = tblExperiencia.strMotivoConclucion;
            experienciaLaboralDM.strPuestoDesempeñado = tblExperiencia.strPuestoDesempeñado;
            experienciaLaboralDM.dteFechaInicio = tblExperiencia.dteFechaInicio.Value;
            experienciaLaboralDM.dteFechaFinal = tblExperiencia.dteFechaFinal.Value;

            return experienciaLaboralDM;
        }
    }
}
