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
    public class EstadiaEmpresaBusiness : IEstadiaEmpresaBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly EstadiaEmpresaRepository estadiaEmpresaRepository;
        private readonly DocumentosRepository documentosRepository;

        public EstadiaEmpresaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            estadiaEmpresaRepository = new EstadiaEmpresaRepository(unitofWork);
            documentosRepository = new DocumentosRepository(unitofWork);
        }

        public bool AddUpdateEstadiaEmpresa(EstadiaEmpresaDomainModel estadiaEmpresaDM)
        {
            bool respuesta = false;

            if (estadiaEmpresaDM.id > 0)
            {
                Expression<Func<tblEstadiaEmpresa, bool>> predicate = p => p.id == estadiaEmpresaDM.id;
                tblEstadiaEmpresa tblEstadiaEmpresa = estadiaEmpresaRepository.GetAll(predicate).FirstOrDefault();

                if (tblEstadiaEmpresa != null)
                {
                    tblEstadiaEmpresa.strResumenProyecto = estadiaEmpresaDM.strResumenProyecto;
                    tblEstadiaEmpresa.strObjetivo = estadiaEmpresaDM.strObjetivo;
                    tblEstadiaEmpresa.strNombreEmpresaInstitucion = estadiaEmpresaDM.strNombreEmpresaInstitucion;
                    tblEstadiaEmpresa.strPuntosCriticosResolver = estadiaEmpresaDM.strPuntosCriticosResolver;
                    tblEstadiaEmpresa.strLogrosBeneficiosObtenidos = estadiaEmpresaDM.strLogrosBeneficiosObtenidos;
                    tblEstadiaEmpresa.strNombreAlumno = estadiaEmpresaDM.strNombreAlumno;
                    tblEstadiaEmpresa.strEstadoEstadia = estadiaEmpresaDM.strEstadoEstadia;

                    estadiaEmpresaRepository.Update(tblEstadiaEmpresa);
                    respuesta = true;
                }
            }
            else
            {
                tblEstadiaEmpresa tblEstadiaEmpresa = new tblEstadiaEmpresa();
                catDocumentos catDocumentos = new catDocumentos();
                tblEstadiaEmpresa.idDocumento = estadiaEmpresaDM.idDocumento;
                tblEstadiaEmpresa.idPersonal = estadiaEmpresaDM.idPersonal;
                tblEstadiaEmpresa.idProgramaEducativo = estadiaEmpresaDM.idProgramaEducativo;
                tblEstadiaEmpresa.strEstadoEstadia = estadiaEmpresaDM.strEstadoEstadia;
                tblEstadiaEmpresa.strLogrosBeneficiosObtenidos = estadiaEmpresaDM.strLogrosBeneficiosObtenidos;
                tblEstadiaEmpresa.strNombreEmpresaInstitucion = estadiaEmpresaDM.strNombreEmpresaInstitucion;
                tblEstadiaEmpresa.strObjetivo = estadiaEmpresaDM.strObjetivo;
                tblEstadiaEmpresa.strPuntosCriticosResolver = estadiaEmpresaDM.strPuntosCriticosResolver;
                tblEstadiaEmpresa.strResumenProyecto = estadiaEmpresaDM.strResumenProyecto;
                tblEstadiaEmpresa.dteFechaInicio = estadiaEmpresaDM.dteFechaInicio;
                tblEstadiaEmpresa.dteFechaTermino = estadiaEmpresaDM.dteFechaTermino;
                tblEstadiaEmpresa.strNombreAlumno = estadiaEmpresaDM.strNombreAlumno;
                catDocumentos.tblEstadiaEmpresa.Add(tblEstadiaEmpresa);
                catDocumentos.strUrl = estadiaEmpresaDM.documentos.StrUrl;
                documentosRepository.Insert(catDocumentos);
                respuesta = true;
            }
            return respuesta;
        }

        public List<EstadiaEmpresaDomainModel> GetAllEstadiaEmpresaByIdPersonal(int _idPersonal)
        {
            List<EstadiaEmpresaDomainModel> estadiaEmpresas = new List<EstadiaEmpresaDomainModel>();

            Expression<Func<tblEstadiaEmpresa, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblEstadiaEmpresa> tblEstadias = estadiaEmpresaRepository.GetAll(predicate).ToList();

            foreach (tblEstadiaEmpresa item in tblEstadias)
            {
                EstadiaEmpresaDomainModel estadiaEmpresaDM = new EstadiaEmpresaDomainModel();

                estadiaEmpresaDM.id = item.id;
                estadiaEmpresaDM.idDocumento = item.idDocumento.Value;
                estadiaEmpresaDM.idPersonal = item.idPersonal.Value;
                estadiaEmpresaDM.idProgramaEducativo = item.idProgramaEducativo.Value;
                estadiaEmpresaDM.strEstadoEstadia = item.strEstadoEstadia;
                estadiaEmpresaDM.strLogrosBeneficiosObtenidos = item.strLogrosBeneficiosObtenidos;
                estadiaEmpresaDM.strNombreEmpresaInstitucion = item.strNombreEmpresaInstitucion;
                estadiaEmpresaDM.strObjetivo = item.strObjetivo;
                estadiaEmpresaDM.strPuntosCriticosResolver = item.strPuntosCriticosResolver;
                estadiaEmpresaDM.strResumenProyecto = item.strResumenProyecto;
                estadiaEmpresaDM.dteFechaInicio = item.dteFechaInicio;
                estadiaEmpresaDM.dteFechaTermino = item.dteFechaTermino;
                estadiaEmpresaDM.strNombreAlumno = item.strNombreAlumno;
                estadiaEmpresaDM.documentos = new DocumentosDomainModel
                {
                    StrUrl = item.catDocumentos.strUrl
                };
                estadiaEmpresas.Add(estadiaEmpresaDM);
            }

            return estadiaEmpresas;
        }

        public EstadiaEmpresaDomainModel GetEstadiaEmpresaById(int _idEstadia)
        {
            EstadiaEmpresaDomainModel estadiaEmpresaDM = new EstadiaEmpresaDomainModel();

            Expression<Func<tblEstadiaEmpresa, bool>> predicate = p => p.id == _idEstadia;
            tblEstadiaEmpresa tblEstadiaEmpresa = estadiaEmpresaRepository.GetAll(predicate).FirstOrDefault();

            estadiaEmpresaDM.id = tblEstadiaEmpresa.id;
            estadiaEmpresaDM.idDocumento = tblEstadiaEmpresa.idDocumento.Value;
            estadiaEmpresaDM.idPersonal = tblEstadiaEmpresa.idPersonal.Value;
            estadiaEmpresaDM.idProgramaEducativo = tblEstadiaEmpresa.idProgramaEducativo.Value;
            estadiaEmpresaDM.strEstadoEstadia = tblEstadiaEmpresa.strEstadoEstadia;
            estadiaEmpresaDM.strLogrosBeneficiosObtenidos = tblEstadiaEmpresa.strLogrosBeneficiosObtenidos;
            estadiaEmpresaDM.strNombreEmpresaInstitucion = tblEstadiaEmpresa.strNombreEmpresaInstitucion;
            estadiaEmpresaDM.strObjetivo = tblEstadiaEmpresa.strObjetivo;
            estadiaEmpresaDM.strPuntosCriticosResolver = tblEstadiaEmpresa.strPuntosCriticosResolver;
            estadiaEmpresaDM.strResumenProyecto = tblEstadiaEmpresa.strResumenProyecto;
            estadiaEmpresaDM.dteFechaInicio = tblEstadiaEmpresa.dteFechaInicio;
            estadiaEmpresaDM.dteFechaTermino = tblEstadiaEmpresa.dteFechaTermino;
            estadiaEmpresaDM.strNombreAlumno = tblEstadiaEmpresa.strNombreAlumno;
            estadiaEmpresaDM.documentos = new DocumentosDomainModel
            {
                StrUrl = tblEstadiaEmpresa.catDocumentos.strUrl
            };

            return estadiaEmpresaDM;
        }

        public bool DeleteEstadia(int _idEstadia)
        {
            bool respuesta = false;

            Expression<Func<tblEstadiaEmpresa, bool>> predicate = p => p.id == _idEstadia;

            estadiaEmpresaRepository.Delete(predicate);

            return respuesta;
        }
    }
}
