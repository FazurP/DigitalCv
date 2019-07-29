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
    public class ProyectoInvestigacionBusiness : IProyectoInvestigacionBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ProyectoInvestigacionRepository proyectoInvestigacionRepository;

        public ProyectoInvestigacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            proyectoInvestigacionRepository = new ProyectoInvestigacionRepository(unitofWork);
        }

        public bool AddUpdateProyectoInvestigacion(ProyectoInvestigacionDomainModel proyectoInvestigacionDM)
        {
            bool respuesta = false;

            if (proyectoInvestigacionDM.id > 0)
            {
                Expression<Func<tblProyectoInvestigacionAplicadaDesarrolloTecnologico, bool>> predicate = p => p.id == proyectoInvestigacionDM.id;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico tblProyectoInvestigacionAplicadaDesarrolloTecnologico = proyectoInvestigacionRepository.GetAll(predicate).FirstOrDefault();

                if (tblProyectoInvestigacionAplicadaDesarrolloTecnologico != null)
                {
                    tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strTituloProyecto = proyectoInvestigacionDM.strTituloProyecto;
                    tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strNombrePatrocinador = proyectoInvestigacionDM.strNombrePatrocinador;
                    tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strInvestigadoresParticipantes = proyectoInvestigacionDM.strInvestigadoresParticipantes;
                    tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strAlumnosParticipantes = proyectoInvestigacionDM.strAlumnosParticipantes;
                    tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strConvocatoria = proyectoInvestigacionDM.strConvocatoria;
                    tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strActividadesRealizadas = proyectoInvestigacionDM.strActividadesRealizadas;

                    proyectoInvestigacionRepository.Update(tblProyectoInvestigacionAplicadaDesarrolloTecnologico);
                    respuesta = true;
                }
            }
            else
            {
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico tblProyectoInvestigacionAplicadaDesarrolloTecnologico = new tblProyectoInvestigacionAplicadaDesarrolloTecnologico();
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.idDocumento = proyectoInvestigacionDM.idDocumento;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.idPersonal = proyectoInvestigacionDM.idPersonal;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.idStatus = proyectoInvestigacionDM.idStatus;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strActividadesRealizadas = proyectoInvestigacionDM.strActividadesRealizadas;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strAlumnosParticipantes = proyectoInvestigacionDM.strAlumnosParticipantes;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strConvocatoria = proyectoInvestigacionDM.strConvocatoria;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strInvestigadoresParticipantes = proyectoInvestigacionDM.strInvestigadoresParticipantes;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strNombrePatrocinador = proyectoInvestigacionDM.strNombrePatrocinador;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strTipoPatrocinador = proyectoInvestigacionDM.strTipoPatrocinador;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strTituloProyecto = proyectoInvestigacionDM.strTituloProyecto;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.dteFechaInicio = proyectoInvestigacionDM.dteFechaInicio;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.dteFechaTermino = proyectoInvestigacionDM.dteFechaTermino;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.bitProyectoTecnologico = proyectoInvestigacionDM.bitProyectoTecnologico;
                tblProyectoInvestigacionAplicadaDesarrolloTecnologico.bitConsideraCurriculum = proyectoInvestigacionDM.bitConsideraCurriculum;
                proyectoInvestigacionRepository.Insert(tblProyectoInvestigacionAplicadaDesarrolloTecnologico);
                respuesta = true;
            }

            return respuesta;
        }

        public List<ProyectoInvestigacionDomainModel> GetProyectosByIdPersonal(int _idPersonal)
        {
            List<ProyectoInvestigacionDomainModel> proyectos = new List<ProyectoInvestigacionDomainModel>();
            Expression<Func<tblProyectoInvestigacionAplicadaDesarrolloTecnologico, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblProyectoInvestigacionAplicadaDesarrolloTecnologico> tblProyectoInvestigacionAplicadaDesarrolloTecnologicos = proyectoInvestigacionRepository.
                GetAll(predicate).ToList();

            foreach (tblProyectoInvestigacionAplicadaDesarrolloTecnologico item in tblProyectoInvestigacionAplicadaDesarrolloTecnologicos)
            {
                ProyectoInvestigacionDomainModel proyectoInvestigacionDM = new ProyectoInvestigacionDomainModel();

                proyectoInvestigacionDM.id = item.id;
                proyectoInvestigacionDM.idDocumento = item.idDocumento.Value;
                proyectoInvestigacionDM.idPersonal = item.idPersonal.Value;
                proyectoInvestigacionDM.idStatus = item.idStatus.Value;
                proyectoInvestigacionDM.strActividadesRealizadas = item.strActividadesRealizadas;
                proyectoInvestigacionDM.strAlumnosParticipantes = item.strAlumnosParticipantes;
                proyectoInvestigacionDM.strConvocatoria = item.strConvocatoria;
                proyectoInvestigacionDM.strInvestigadoresParticipantes = item.strInvestigadoresParticipantes;
                proyectoInvestigacionDM.strNombrePatrocinador = item.strNombrePatrocinador;
                proyectoInvestigacionDM.strTipoPatrocinador = item.strTipoPatrocinador;
                proyectoInvestigacionDM.strTituloProyecto = item.strTituloProyecto;
                proyectoInvestigacionDM.dteFechaInicio = item.dteFechaInicio.Value;
                proyectoInvestigacionDM.dteFechaTermino = item.dteFechaTermino.Value;
                proyectoInvestigacionDM.bitConsideraCurriculum = item.bitConsideraCurriculum.Value;
                proyectoInvestigacionDM.bitProyectoTecnologico = item.bitProyectoTecnologico.Value;
                proyectos.Add(proyectoInvestigacionDM);

            }

            return proyectos;

        }

        public ProyectoInvestigacionDomainModel GetProyectoById(int _idProyecto)
        {
            Expression<Func<tblProyectoInvestigacionAplicadaDesarrolloTecnologico, bool>> predicate = p => p.id == _idProyecto;
            tblProyectoInvestigacionAplicadaDesarrolloTecnologico tblProyectoInvestigacionAplicadaDesarrolloTecnologico =
                proyectoInvestigacionRepository.GetAll(predicate).FirstOrDefault();

            ProyectoInvestigacionDomainModel proyectoInvestigacionDM = new ProyectoInvestigacionDomainModel();

            proyectoInvestigacionDM.id = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.id;
            proyectoInvestigacionDM.idDocumento = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.idDocumento.Value;
            proyectoInvestigacionDM.idPersonal = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.idPersonal.Value;
            proyectoInvestigacionDM.idStatus = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.idStatus.Value;
            proyectoInvestigacionDM.strActividadesRealizadas = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strActividadesRealizadas;
            proyectoInvestigacionDM.strAlumnosParticipantes = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strAlumnosParticipantes;
            proyectoInvestigacionDM.strConvocatoria = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strConvocatoria;
            proyectoInvestigacionDM.strInvestigadoresParticipantes = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strInvestigadoresParticipantes;
            proyectoInvestigacionDM.strNombrePatrocinador = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strNombrePatrocinador;
            proyectoInvestigacionDM.strTipoPatrocinador = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strTipoPatrocinador;
            proyectoInvestigacionDM.strTituloProyecto = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.strTituloProyecto;
            proyectoInvestigacionDM.dteFechaInicio = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.dteFechaInicio.Value;
            proyectoInvestigacionDM.dteFechaTermino = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.dteFechaTermino.Value;
            proyectoInvestigacionDM.bitConsideraCurriculum = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.bitConsideraCurriculum.Value;
            proyectoInvestigacionDM.bitProyectoTecnologico = tblProyectoInvestigacionAplicadaDesarrolloTecnologico.bitProyectoTecnologico.Value;

            return proyectoInvestigacionDM;
        }

        public bool DeleteProyecto(int _idProyecto)
        {
            bool respuesta = false;

            Expression<Func<tblProyectoInvestigacionAplicadaDesarrolloTecnologico, bool>> predicate = p => p.id == _idProyecto;

            proyectoInvestigacionRepository.Delete(predicate);
            respuesta = true;

            return respuesta;
        }

    }
}
