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
    public class ProductividadInnovadoraBusiness : IProductividadInnovadoraBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProduccionInnovadoraRepository produccionInnovadoraRepository;
        public ProductividadInnovadoraBusiness(IUnitOfWork _unitofWork)
        {
            unitOfWork = _unitofWork;
            produccionInnovadoraRepository = new ProduccionInnovadoraRepository(unitOfWork);
        }

        public bool AddUpdateProductividadInnovador(ProductividadInnovadoraDomainModel productividadInnovadoraDomainModel)
        {
            bool respuesta = false;

            if (productividadInnovadoraDomainModel.id > 0)
            {

            }
            else
            {
                tblProductividadInnovadora tblProductividad = new tblProductividadInnovadora();

                tblProductividad.idDocumento = productividadInnovadoraDomainModel.idDocumento;
                tblProductividad.idPais = productividadInnovadoraDomainModel.idPais;
                tblProductividad.idPersonal = productividadInnovadoraDomainModel.idPersonal;
                tblProductividad.idStatus = productividadInnovadoraDomainModel.idStatus;
                tblProductividad.strAutor = productividadInnovadoraDomainModel.strAutor;
                tblProductividad.strClasificacionInternacionalPatentes = productividadInnovadoraDomainModel.strClasificacionInternacionalPatentes;
                tblProductividad.strDescripcion = productividadInnovadoraDomainModel.strDescripcion;
                tblProductividad.strEstadoActual = productividadInnovadoraDomainModel.strEstadoActual;
                tblProductividad.strNumeroRegistro = productividadInnovadoraDomainModel.strNumeroRegistro;
                tblProductividad.strProposito = productividadInnovadoraDomainModel.strProposito;
                tblProductividad.strTipoProductividadInnovadora = productividadInnovadoraDomainModel.strTipoProductividadInnovadora;
                tblProductividad.strTitulo = productividadInnovadoraDomainModel.strTitulo;
                tblProductividad.strUso = productividadInnovadoraDomainModel.strUso;
                tblProductividad.strUsuario = productividadInnovadoraDomainModel.strUsuario;
                tblProductividad.dteFechaRegistro = productividadInnovadoraDomainModel.dteFechaRegistro;
                tblProductividad.bitConsideraCurriculum = productividadInnovadoraDomainModel.bitConsideraCurriculum;

                produccionInnovadoraRepository.Insert(tblProductividad);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
