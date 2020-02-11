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
        /// <summary>
        /// Este metodo se encarga de insertar o actualizar datos de un CapituloLibro, en la base de datos.
        /// </summary>
        /// <param name="capituloLibroDomainModel">recibe los datos que se van a persistir</param>
        /// <returns>true o false</returns>
        public bool AddUpdateCapituloLibro(CapituloLibroDomainModel capituloLibroDomainModel) {

            bool respuesta = false;

            if (capituloLibroDomainModel.id > 0)
            {
                tblCapituloLibro tblCapituloLibro = capituloLibroRepository.GetAll
                    (p => p.id == capituloLibroDomainModel.id).FirstOrDefault<tblCapituloLibro>();

                if (tblCapituloLibro != null)
                {
                    tblCapituloLibro.strAutor = capituloLibroDomainModel.strAutor;
                    tblCapituloLibro.strAutores = capituloLibroDomainModel.strAutores;
                    tblCapituloLibro.strEdicion = capituloLibroDomainModel.strEdicion;
                    tblCapituloLibro.strEditorial = capituloLibroDomainModel.strEditorial;
                    tblCapituloLibro.strISBN = capituloLibroDomainModel.strISBN;
                    tblCapituloLibro.strTiraje = capituloLibroDomainModel.strTiraje;
                    tblCapituloLibro.strTitulo = capituloLibroDomainModel.strTitulo;
                    tblCapituloLibro.strTituloCapitulo = capituloLibroDomainModel.strTituloCapitulo;

                    capituloLibroRepository.Update(tblCapituloLibro);
                    respuesta = true;
                }
            }
            else {          
                    tblCapituloLibro tblCapitulo = new tblCapituloLibro();

                    tblCapitulo.idPais = capituloLibroDomainModel.idPais;
                    tblCapitulo.idPersonal = capituloLibroDomainModel.idPersonal;
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

                    capituloLibroRepository.Insert(tblCapitulo);
                    respuesta = true;          
            }

            return respuesta;
        }
        /// <summary>
        /// Este metodos se encarga de obtener una lista de CapitulosLibros del usuario
        /// </summary>
        /// <param name="_idPersonal">recibe el id del usuario</param>
        /// <returns>una lista de los capitulosLibros del usuario</returns>
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

                capituloLibroDomainModels.Add(capitulo);
            }

            return capituloLibroDomainModels;

        }
        /// <summary>
        /// Este metodo se encarga de obtener un CapituloLibro
        /// </summary>
        /// <param name="_idCapitulolibro">recibe el id del capituloLibro</param>
        /// <returns>un objeto con los datos del capituloLibro</returns>
        public CapituloLibroDomainModel GetCapituloLibro(int _idCapitulolibro) {
            CapituloLibroDomainModel capituloLibroDM = new CapituloLibroDomainModel();

            Expression<Func<tblCapituloLibro, bool>> predicate = p => p.id == _idCapitulolibro;

            tblCapituloLibro tblCapituloLibro = capituloLibroRepository.GetAll(predicate).FirstOrDefault<tblCapituloLibro>();

            capituloLibroDM.id = tblCapituloLibro.id;
            capituloLibroDM.idPais = tblCapituloLibro.idPais.Value;
            capituloLibroDM.idPersonal = tblCapituloLibro.idPersonal.Value;
            capituloLibroDM.paginaInicio = tblCapituloLibro.paginaInicio.Value;
            capituloLibroDM.paginaTermino = tblCapituloLibro.paginaTermino.Value;
            capituloLibroDM.strAutor = tblCapituloLibro.strAutor;
            capituloLibroDM.strAutores = tblCapituloLibro.strAutores;
            capituloLibroDM.strEdicion = tblCapituloLibro.strEdicion;
            capituloLibroDM.strEditorial = tblCapituloLibro.strEditorial;
            capituloLibroDM.strISBN = tblCapituloLibro.strISBN;
            capituloLibroDM.strTiraje = tblCapituloLibro.strTiraje;
            capituloLibroDM.strTitulo = tblCapituloLibro.strTitulo;
            capituloLibroDM.strTituloCapitulo = tblCapituloLibro.strTituloCapitulo;
            capituloLibroDM.enumProposito = tblCapituloLibro.enumProposito;
            capituloLibroDM.enumEstadoActual = tblCapituloLibro.enumEstadoActual;
            capituloLibroDM.dteFechaPublicacion = tblCapituloLibro.dteFechaPublicacion.Value;

            return capituloLibroDM;
        }
        /// <summary>
        /// Este metodo se encarga de eliminar un capituloLibro
        /// </summary>
        /// <param name="_idCapituloLibro">recibe el id del CapituloLibro</param>
        /// <returns>true o false</returns>
        public bool DeleteCapituloLibro(int _idCapituloLibro) {

            bool respuesta = false;

            Expression<Func<tblCapituloLibro, bool>> predicate = p => p.id == _idCapituloLibro;

            capituloLibroRepository.Delete(predicate);
            respuesta = true;

            return respuesta;

        }
    }
}
