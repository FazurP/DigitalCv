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
    public class CapituloLibroBusiness : ICapituloLibro
    {
        private readonly IUnitOfWork unitofWork;
        private readonly CapituloLibroRepository capituloLibroRepository;

        public CapituloLibroBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            capituloLibroRepository = new CapituloLibroRepository(unitofWork);
        }

        public bool AddUpdateCapituloLibro(CapituloLibroDomainModel capituloLibroDomainModel) {

            bool respuesta = false;

            if (capituloLibroDomainModel.id > 0)
            {

            }
            else {
                tblCapituloLibro tblCapitulo = new tblCapituloLibro();

                tblCapitulo.idPais = capituloLibroDomainModel.idPais;
                tblCapitulo.idPersonal = capituloLibroDomainModel.idPersonal;
                tblCapitulo.idStatus = capituloLibroDomainModel.idStatus;
                tblCapitulo.paginaInicio = capituloLibroDomainModel.paginaInicio;
                tblCapitulo.paginaTermino = capituloLibroDomainModel.paginaTermino;
                tblCapitulo.strAutor = capituloLibroDomainModel.strAutor;
                tblCapitulo.strAutores = capituloLibroDomainModel.strAutores;
                tblCapitulo.strEdicion = capituloLibroDomainModel.strEdicion;
                tblCapitulo.strEditorial = capituloLibroDomainModel.strEditorial;
                tblCapitulo.strISBN = capituloLibroDomainModel.strISBN;
                tblCapitulo.strTiraje = capituloLibroDomainModel.strTiraje;
                tblCapitulo.strTitulo = capituloLibroDomainModel.strTitulo;
                tblCapitulo.strTituloCapitulo = capituloLibroDomainModel.strTituloCapitulo;
                tblCapitulo.dteFechaPublicacion = capituloLibroDomainModel.dteFechaPublicacion;
                tblCapitulo.enumEstadoActual = capituloLibroDomainModel.enumEstadoActual.ToString();
                tblCapitulo.enumProposito = capituloLibroDomainModel.enumProposito.ToString();
                tblCapitulo.bitLigarCurriculum = capituloLibroDomainModel.bitLigarCurriculum;

                capituloLibroRepository.Insert(tblCapitulo);
            }

            return respuesta;
        }

        public List<CapituloLibroDomainModel> GetCapitulosLibrosByPersonal(int _idPersonal) {
            List<CapituloLibroDomainModel> capituloLibroDomainModels = new List<CapituloLibroDomainModel>();

            Expression<Func<tblCapituloLibro, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblCapituloLibro> tblCapituloLibros = capituloLibroRepository.GetAll(predicate).ToList<tblCapituloLibro>();

            foreach (tblCapituloLibro item in tblCapituloLibros)
            {
                CapituloLibroDomainModel capitulo = new CapituloLibroDomainModel();

                capitulo.id = item.id;
                capitulo.idPais = item.idPais.Value;
                capitulo.idPersonal = item.idPersonal.Value;
                capitulo.idStatus = item.idStatus.Value;
                capitulo.paginaInicio = item.paginaInicio.Value;
                capitulo.paginaTermino = item.paginaTermino.Value;
                capitulo.strAutor = item.strAutor;
                capitulo.strAutores = item.strAutores;
                capitulo.strEdicion = item.strEdicion;
                capitulo.strEditorial = item.strEditorial;
                capitulo.strISBN = item.strISBN;
                capitulo.strTiraje = item.strTiraje;
                capitulo.strTitulo = item.strTitulo;
                capitulo.strTituloCapitulo = item.strTituloCapitulo;
                capitulo.enumProposito = item.enumProposito;
                capitulo.enumEstadoActual = item.enumEstadoActual;
                capitulo.dteFechaPublicacion = item.dteFechaPublicacion.Value;
                capitulo.bitLigarCurriculum = item.bitLigarCurriculum.Value;

                capituloLibroDomainModels.Add(capitulo);
            }

            return capituloLibroDomainModels;

        }
    }
}
