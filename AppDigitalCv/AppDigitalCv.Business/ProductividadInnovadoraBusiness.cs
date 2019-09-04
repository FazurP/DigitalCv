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
                Expression<Func<tblProductividadInnovadora, bool>> predicate = p => p.id == productividadInnovadoraDomainModel.id;
                tblProductividadInnovadora tblProductividad = produccionInnovadoraRepository.GetAll(predicate).FirstOrDefault();
                if (tblProductividad != null)
                {
                    tblProductividad.strAutor = productividadInnovadoraDomainModel.strAutor;
                    tblProductividad.strTitulo = productividadInnovadoraDomainModel.strTitulo;
                    tblProductividad.strDescripcion = productividadInnovadoraDomainModel.strDescripcion;
                    tblProductividad.strUso = productividadInnovadoraDomainModel.strUso;
                    tblProductividad.strNumeroRegistro = productividadInnovadoraDomainModel.strNumeroRegistro;
                    tblProductividad.strUsuario = productividadInnovadoraDomainModel.strUsuario;

                    produccionInnovadoraRepository.Update(tblProductividad);
                    respuesta = true;
                }
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

        public List<ProductividadInnovadoraDomainModel> GetProductividades(int _idPersonal)
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
                productividadInnovadoraDM.strNombreDocumento = item.catDocumentos.strUrl;

                productividad.Add(productividadInnovadoraDM);

            }

            return productividad;
        }

        public ProductividadInnovadoraDomainModel GetProductividad(int _idProductividad)
        {
            ProductividadInnovadoraDomainModel productividadInnovadoraDM = new ProductividadInnovadoraDomainModel();

            Expression<Func<tblProductividadInnovadora, bool>> predicate = p => p.id == _idProductividad;
            tblProductividadInnovadora tblProductividad = produccionInnovadoraRepository.GetAll(predicate).FirstOrDefault<tblProductividadInnovadora>();

            productividadInnovadoraDM.id = tblProductividad.id;
            productividadInnovadoraDM.idDocumento = tblProductividad.idDocumento.Value;
            productividadInnovadoraDM.idPais = tblProductividad.idPais.Value;
            productividadInnovadoraDM.idPersonal = tblProductividad.idPersonal.Value;
            productividadInnovadoraDM.idStatus = tblProductividad.idStatus.Value;
            productividadInnovadoraDM.strAutor = tblProductividad.strAutor;
            productividadInnovadoraDM.strClasificacionInternacionalPatentes = tblProductividad.strClasificacionInternacionalPatentes;
            productividadInnovadoraDM.strDescripcion = tblProductividad.strDescripcion;
            productividadInnovadoraDM.strEstadoActual = tblProductividad.strEstadoActual;
            productividadInnovadoraDM.strNumeroRegistro = tblProductividad.strNumeroRegistro;
            productividadInnovadoraDM.strProposito = tblProductividad.strProposito;
            productividadInnovadoraDM.strTipoProductividadInnovadora = tblProductividad.strTipoProductividadInnovadora;
            productividadInnovadoraDM.strTitulo = tblProductividad.strTitulo;
            productividadInnovadoraDM.strUso = tblProductividad.strUso;
            productividadInnovadoraDM.strUsuario = tblProductividad.strUsuario;
            productividadInnovadoraDM.dteFechaRegistro = tblProductividad.dteFechaRegistro.Value;
            productividadInnovadoraDM.bitConsideraCurriculum = tblProductividad.bitConsideraCurriculum.Value;

            return productividadInnovadoraDM;
        }

        public bool DeleteProductividad(int _idProductividad)
        {
            bool respuesta = false;
            Expression<Func<tblProductividadInnovadora, bool>> predicate = p => p.id == _idProductividad;
            produccionInnovadoraRepository.Delete(predicate);
            respuesta = true;

            return respuesta;

        }

    }
}
