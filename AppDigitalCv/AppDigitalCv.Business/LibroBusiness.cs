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
    public class LibroBusiness : ILibroBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly LibroRepository libroRepository;

        public LibroBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            libroRepository = new LibroRepository(unitofWork);
        }

        public bool AddUpdateLibro(LibroDomainModel libroDM)
        {
            bool respuesta = false;

            if (libroDM.id > 0)
            {
                Expression<Func<tblLibro, bool>> predicate = p => p.id == libroDM.id;
                tblLibro tblLibro = libroRepository.GetAll(predicate).FirstOrDefault();
                if (tblLibro !=  null)
                {
                    tblLibro.strAutores = libroDM.strAutores;
                    tblLibro.strTituloLibro = libroDM.strTituloLibro;
                    tblLibro.strEditorial = libroDM.strEditorial;
                    tblLibro.strEdicion = libroDM.strEdicion;
                    tblLibro.strTiraje = libroDM.strTiraje;
                    tblLibro.strISBN = libroDM.strISBM;

                    libroRepository.Update(tblLibro);
                    respuesta = true;
                }
            }
            else {
                tblLibro tblLibro = new tblLibro();

                tblLibro.idPais = libroDM.idPais;
                tblLibro.idPersonal = libroDM.idPersonal;
                tblLibro.idPersonal = libroDM.idPersonal;
                tblLibro.Paginas = libroDM.Paginas;
                tblLibro.strAutores = libroDM.strAutores;
                tblLibro.strEdicion = libroDM.strEdicion;
                tblLibro.strEditorial = libroDM.strEditorial;
                tblLibro.strEstadoActual = libroDM.strEstadoActual;
                tblLibro.strISBN = libroDM.strISBM;
                tblLibro.strProposito = libroDM.strProposito;
                tblLibro.strTipoParticipacion = libroDM.strTipoParticipacion;
                tblLibro.strTiraje = libroDM.strTiraje;
                tblLibro.strTituloLibro = libroDM.strTituloLibro;
                tblLibro.FechaPublicacion = libroDM.FechaPublicacion;

                libroRepository.Insert(tblLibro);
                respuesta = true;
            }

            return respuesta;
        }

        public List<LibroDomainModel> GetLibrosByPersonal(int _idPersonal)
        {
            List<LibroDomainModel> libros = new List<LibroDomainModel>();

            Expression<Func<tblLibro, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblLibro> tblLibros = libroRepository.GetAll(predicate).ToList<tblLibro>();

            foreach (tblLibro tblLibro in tblLibros)
            {
                LibroDomainModel libroDM = new LibroDomainModel();

                libroDM.id = tblLibro.id;
                libroDM.idPais = tblLibro.idPais.Value;
                libroDM.idPersonal = tblLibro.idPersonal.Value;
                libroDM.Paginas = tblLibro.Paginas.Value;
                libroDM.strAutores = tblLibro.strAutores;
                libroDM.strEdicion = tblLibro.strEdicion;
                libroDM.strEditorial = tblLibro.strEditorial;
                libroDM.strEstadoActual = tblLibro.strEstadoActual;
                libroDM.strISBM = tblLibro.strISBN;
                libroDM.strProposito = tblLibro.strProposito;
                libroDM.strTipoParticipacion = tblLibro.strTipoParticipacion;
                libroDM.strTiraje = tblLibro.strTiraje;
                libroDM.strTituloLibro = tblLibro.strTituloLibro;
                libroDM.FechaPublicacion = tblLibro.FechaPublicacion.Value;

                libros.Add(libroDM);
            }

            return libros;

        }

        public LibroDomainModel GetLibro(int _idLibro)
        {
            LibroDomainModel libro = new LibroDomainModel();

            Expression<Func<tblLibro, bool>> predicate = p => p.id == _idLibro;
            tblLibro tblLibro = libroRepository.GetAll(predicate).FirstOrDefault<tblLibro>();

            libro.id = tblLibro.id;
            libro.idPais = tblLibro.idPais.Value;
            libro.idPersonal = tblLibro.idPersonal.Value;
            libro.Paginas = tblLibro.Paginas.Value;
            libro.strAutores = tblLibro.strAutores;
            libro.strEdicion = tblLibro.strEdicion;
            libro.strEditorial = tblLibro.strEditorial;
            libro.strEstadoActual = tblLibro.strEstadoActual;
            libro.strISBM = tblLibro.strISBN;
            libro.strProposito = tblLibro.strProposito;
            libro.strTipoParticipacion = tblLibro.strTipoParticipacion;
            libro.strTiraje = tblLibro.strTiraje;
            libro.strTituloLibro = tblLibro.strTituloLibro;
            libro.FechaPublicacion = tblLibro.FechaPublicacion.Value;

            return libro;
        }

        public bool DeleteLibro(int _idLibro)
        {
            bool respuesta = false;

            Expression<Func<tblLibro, bool>> predicate = p => p.id == _idLibro;
            libroRepository.Delete(predicate);
            respuesta = true;

            return respuesta;
        }
    }
}
