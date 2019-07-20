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

        public EstadiaEmpresaBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            estadiaEmpresaRepository = new EstadiaEmpresaRepository(unitofWork);
        }

        public bool AddUpdateEstadiaEmpresa(EstadiaEmpresaDomainModel estadiaEmpresaDM)
        {
            bool respuesta = false;

            if (estadiaEmpresaDM.id > 0)
            {

            }
            else
            {
                tblEstadiaEmpresa tblEstadiaEmpresa = new tblEstadiaEmpresa();
                tblEstadiaEmpresa.idDocumento = estadiaEmpresaDM.idDocumento;
                tblEstadiaEmpresa.idPersonal = estadiaEmpresaDM.idPersonal;
                tblEstadiaEmpresa.idProgramaEducativo = estadiaEmpresaDM.idProgramaEducativo;
                tblEstadiaEmpresa.idStatus = estadiaEmpresaDM.idStatus;
                tblEstadiaEmpresa.idTipoProducto = estadiaEmpresaDM.idTipoProducto;
                tblEstadiaEmpresa.strEstadoEstadia = estadiaEmpresaDM.strEstadoEstadia;
                tblEstadiaEmpresa.strLogrosBeneficiosObtenidos = estadiaEmpresaDM.strLogrosBeneficiosObtenidos;
                tblEstadiaEmpresa.strNombreEmpresaInstitucion = estadiaEmpresaDM.strNombreEmpresaInstitucion;
                tblEstadiaEmpresa.strNombreEstadia = estadiaEmpresaDM.strNombreEstadia;
                tblEstadiaEmpresa.strNumeroAlumnos = estadiaEmpresaDM.strNumeroAlumnos;
                tblEstadiaEmpresa.strNumeroHoras = estadiaEmpresaDM.strNumeroHoras;
                tblEstadiaEmpresa.strObjetivo = estadiaEmpresaDM.strObjetivo;
                tblEstadiaEmpresa.strPuntosCriticosResolver = estadiaEmpresaDM.strPuntosCriticosResolver;
                tblEstadiaEmpresa.strResumenProyecto = estadiaEmpresaDM.strResumenProyecto;
                tblEstadiaEmpresa.dteFechaInicio = estadiaEmpresaDM.dteFechaInicio;
                tblEstadiaEmpresa.dteFechaTermino = estadiaEmpresaDM.dteFechaTermino;
                tblEstadiaEmpresa.bitConsideraCurriculum = estadiaEmpresaDM.bitConsideraCurriculum;

                estadiaEmpresaRepository.Insert(tblEstadiaEmpresa);
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
                estadiaEmpresaDM.idStatus = item.idStatus.Value;
                estadiaEmpresaDM.idTipoProducto = item.idTipoProducto.Value;
                estadiaEmpresaDM.strEstadoEstadia = item.strEstadoEstadia;
                estadiaEmpresaDM.strLogrosBeneficiosObtenidos = item.strLogrosBeneficiosObtenidos;
                estadiaEmpresaDM.strNombreEmpresaInstitucion = item.strNombreEmpresaInstitucion;
                estadiaEmpresaDM.strNombreEstadia = item.strNombreEstadia;
                estadiaEmpresaDM.strNumeroAlumnos = item.strNumeroAlumnos;
                estadiaEmpresaDM.strNumeroHoras = item.strNumeroHoras;
                estadiaEmpresaDM.strObjetivo = item.strObjetivo;
                estadiaEmpresaDM.strPuntosCriticosResolver = item.strPuntosCriticosResolver;
                estadiaEmpresaDM.strResumenProyecto = item.strResumenProyecto;
                estadiaEmpresaDM.dteFechaInicio = item.dteFechaInicio.Value;
                estadiaEmpresaDM.dteFechaTermino = item.dteFechaTermino.Value;
                estadiaEmpresaDM.bitConsideraCurriculum = item.bitConsideraCurriculum.Value;

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
            estadiaEmpresaDM.idStatus = tblEstadiaEmpresa.idStatus.Value;
            estadiaEmpresaDM.idTipoProducto = tblEstadiaEmpresa.idTipoProducto.Value;
            estadiaEmpresaDM.strEstadoEstadia = tblEstadiaEmpresa.strEstadoEstadia;
            estadiaEmpresaDM.strLogrosBeneficiosObtenidos = tblEstadiaEmpresa.strLogrosBeneficiosObtenidos;
            estadiaEmpresaDM.strNombreEmpresaInstitucion = tblEstadiaEmpresa.strNombreEmpresaInstitucion;
            estadiaEmpresaDM.strNombreEstadia = tblEstadiaEmpresa.strNombreEstadia;
            estadiaEmpresaDM.strNumeroAlumnos = tblEstadiaEmpresa.strNumeroAlumnos;
            estadiaEmpresaDM.strNumeroHoras = tblEstadiaEmpresa.strNumeroHoras;
            estadiaEmpresaDM.strObjetivo = tblEstadiaEmpresa.strObjetivo;
            estadiaEmpresaDM.strPuntosCriticosResolver = tblEstadiaEmpresa.strPuntosCriticosResolver;
            estadiaEmpresaDM.strResumenProyecto = tblEstadiaEmpresa.strResumenProyecto;
            estadiaEmpresaDM.dteFechaInicio = tblEstadiaEmpresa.dteFechaInicio.Value;
            estadiaEmpresaDM.dteFechaTermino = tblEstadiaEmpresa.dteFechaTermino.Value;
            estadiaEmpresaDM.bitConsideraCurriculum = tblEstadiaEmpresa.bitConsideraCurriculum.Value;

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
