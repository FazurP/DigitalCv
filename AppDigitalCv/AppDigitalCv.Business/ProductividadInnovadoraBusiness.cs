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

        public List<ProductividadInnovadoraDomainModel> GetProductividad(int _idPersonal)
        {
            List<ProductividadInnovadoraDomainModel> productividad = new List<ProductividadInnovadoraDomainModel>();

            Expression<Func<tblProductividadInnovadora, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblProductividadInnovadora> tblProductividad = produccionInnovadoraRepository.GetAll(predicate).ToList();

            foreach (tblProductividadInnovadora item in tblProductividad)
            {
                ProductividadInnovadoraDomainModel productividadInnovadoraDM = new ProductividadInnovadoraDomainModel();

                productividadInnovadoraDM.id = item.id;
                productividadInnovadoraDM.idDocumento = item.idDocumento.Value;
                productividadInnovadoraDM.idPais = item.idPais.Value;
                productividadInnovadoraDM.idPersonal = item.idPersonal.Value;
                productividadInnovadoraDM.idStatus = item.idStatus.Value;
                productividadInnovadoraDM.strAutor = item.strAutor;
                productividadInnovadoraDM.strClasificacionInternacionalPatentes = item.strClasificacionInternacionalPatentes;
                productividadInnovadoraDM.strDescripcion = item.strDescripcion;
                productividadInnovadoraDM.strEstadoActual = item.strEstadoActual;
                productividadInnovadoraDM.strNumeroRegistro = item.strNumeroRegistro;
                productividadInnovadoraDM.strProposito = item.strProposito;
                productividadInnovadoraDM.strTipoProductividadInnovadora = item.strTipoProductividadInnovadora;
                productividadInnovadoraDM.strTitulo = item.strTitulo;
                productividadInnovadoraDM.strUso = item.strUso;
                productividadInnovadoraDM.strUsuario = item.strUsuario;
                productividadInnovadoraDM.dteFechaRegistro = item.dteFechaRegistro.Value;
                productividadInnovadoraDM.bitConsideraCurriculum = item.bitConsideraCurriculum.Value;

                productividad.Add(productividadInnovadoraDM);

            }

            return productividad;
        }
    }
}
