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
    public class InformeTecnicoBusiness : IInformeTecnicoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly InformeTecnicoRepository informeTecnicoRepository;
        public InformeTecnicoBusiness(IUnitOfWork _unitofWork) {
            unitOfWork = _unitofWork;
            informeTecnicoRepository = new InformeTecnicoRepository(unitOfWork);
        }

        public bool AddUpdateInformeTecnico(InformeTecnicoDomainModel informeTecnicoDomainModel) {
            bool respuesta = false;
            if (informeTecnicoDomainModel.id > 0)
            {
                Expression<Func<tblInformeTecnico, bool>> predicate = p => p.id == informeTecnicoDomainModel.id;
                tblInformeTecnico tblInformeTecnico = informeTecnicoRepository.GetAll(predicate).FirstOrDefault<tblInformeTecnico>();

                if (tblInformeTecnico != null)
                {
                    tblInformeTecnico.strAlcance = informeTecnicoDomainModel.strAlcance;
                    tblInformeTecnico.strAutor = informeTecnicoDomainModel.strAutor;
                    tblInformeTecnico.strInstitucionBeneficiaria = informeTecnicoDomainModel.strInstitucionBeneficiaria;
                    tblInformeTecnico.strNombreProyecto = informeTecnicoDomainModel.strNombreProyecto;

                    informeTecnicoRepository.Update(tblInformeTecnico);
                    respuesta = true;
                }
            }
            else {

                tblInformeTecnico tblInformeTecnico = new tblInformeTecnico();

                tblInformeTecnico.id = informeTecnicoDomainModel.id;
                tblInformeTecnico.idDocumento = informeTecnicoDomainModel.idDocumento;
                tblInformeTecnico.idPais = informeTecnicoDomainModel.idPais;
                tblInformeTecnico.idPersonal = informeTecnicoDomainModel.idPersonal;
                tblInformeTecnico.idStatus = informeTecnicoDomainModel.idStatus;
                tblInformeTecnico.numeroPaginas = informeTecnicoDomainModel.numeroPaginas;
                tblInformeTecnico.strAlcance = informeTecnicoDomainModel.strAlcance;
                tblInformeTecnico.strAutor = informeTecnicoDomainModel.strAutor;
                tblInformeTecnico.strInstitucionBeneficiaria = informeTecnicoDomainModel.strInstitucionBeneficiaria;
                tblInformeTecnico.strNombreProyecto = informeTecnicoDomainModel.strNombreProyecto;
                tblInformeTecnico.dteElaboracionInforme = informeTecnicoDomainModel.dteElaboracionInforme;
                tblInformeTecnico.dteFechaInicio = informeTecnicoDomainModel.dteFechaInicio;
                tblInformeTecnico.enumEstadoActual = informeTecnicoDomainModel.enumEstadoActual;
                tblInformeTecnico.enumProposito = informeTecnicoDomainModel.enumProposito;
                tblInformeTecnico.bitLigarCurriculum = informeTecnicoDomainModel.bitLigarCurriculum;

                informeTecnicoRepository.Insert(tblInformeTecnico);
                respuesta = true;
            }
            return respuesta;
        }

        public List<InformeTecnicoDomainModel> GetInformesByUsuario(int _idPersonal) {
            List<InformeTecnicoDomainModel> informeTecnicos = new List<InformeTecnicoDomainModel>();

            Expression<Func<tblInformeTecnico, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblInformeTecnico> tblInformeTecnicos = informeTecnicoRepository.GetAll(predicate).ToList();

            foreach (tblInformeTecnico tblInformeTecnico in tblInformeTecnicos)
            {
                InformeTecnicoDomainModel informeTecnicoDM = new InformeTecnicoDomainModel();

                informeTecnicoDM.id = tblInformeTecnico.id;
                informeTecnicoDM.idDocumento = tblInformeTecnico.idDocumento.Value;
                informeTecnicoDM.idPais = tblInformeTecnico.idPais.Value;
                informeTecnicoDM.idPersonal = tblInformeTecnico.idPersonal.Value;
                informeTecnicoDM.idStatus = tblInformeTecnico.idStatus.Value;
                informeTecnicoDM.numeroPaginas = tblInformeTecnico.numeroPaginas.Value;
                informeTecnicoDM.strAlcance = tblInformeTecnico.strAlcance;
                informeTecnicoDM.strAutor = tblInformeTecnico.strAutor;
                informeTecnicoDM.strInstitucionBeneficiaria = tblInformeTecnico.strInstitucionBeneficiaria;
                informeTecnicoDM.strNombreProyecto = tblInformeTecnico.strNombreProyecto;
                informeTecnicoDM.bitLigarCurriculum = tblInformeTecnico.bitLigarCurriculum.Value;
                informeTecnicoDM.dteElaboracionInforme = tblInformeTecnico.dteElaboracionInforme.Value;
                informeTecnicoDM.dteFechaInicio = tblInformeTecnico.dteFechaInicio.Value;
                informeTecnicoDM.enumEstadoActual = tblInformeTecnico.enumEstadoActual;
                informeTecnicoDM.enumProposito = tblInformeTecnico.enumProposito;

                informeTecnicos.Add(informeTecnicoDM);
            }

            return informeTecnicos;
        }

        public InformeTecnicoDomainModel GetInformeTecnico(int _idInforme) {
            InformeTecnicoDomainModel informeTecnicoDM = new InformeTecnicoDomainModel();

            Expression<Func<tblInformeTecnico, bool>> predicate = p => p.id == _idInforme;
            tblInformeTecnico tblInformeTecnico = informeTecnicoRepository.GetAll(predicate).FirstOrDefault<tblInformeTecnico>();

            informeTecnicoDM.id = tblInformeTecnico.id;
            informeTecnicoDM.idDocumento = tblInformeTecnico.idDocumento.Value;
            informeTecnicoDM.idPais = tblInformeTecnico.idPais.Value;
            informeTecnicoDM.idPersonal = tblInformeTecnico.idPersonal.Value;
            informeTecnicoDM.idStatus = tblInformeTecnico.idStatus.Value;
            informeTecnicoDM.numeroPaginas = tblInformeTecnico.numeroPaginas.Value;
            informeTecnicoDM.strAlcance = tblInformeTecnico.strAlcance;
            informeTecnicoDM.strAutor = tblInformeTecnico.strAutor;
            informeTecnicoDM.strInstitucionBeneficiaria = tblInformeTecnico.strInstitucionBeneficiaria;
            informeTecnicoDM.strNombreProyecto = tblInformeTecnico.strNombreProyecto;
            informeTecnicoDM.bitLigarCurriculum = tblInformeTecnico.bitLigarCurriculum.Value;
            informeTecnicoDM.dteElaboracionInforme = tblInformeTecnico.dteElaboracionInforme.Value;
            informeTecnicoDM.dteFechaInicio = tblInformeTecnico.dteFechaInicio.Value;
            informeTecnicoDM.enumEstadoActual = tblInformeTecnico.enumEstadoActual;
            informeTecnicoDM.enumProposito = tblInformeTecnico.enumProposito;

            return informeTecnicoDM;

        }

        public bool DeleteInformeTecnico(int _idInforme) {

            bool respuesta = false;

            Expression<Func<tblInformeTecnico, bool>> predicate = p => p.id == _idInforme;

            informeTecnicoRepository.Delete(predicate);
            respuesta = true;

            return respuesta;

        }
    }
}
