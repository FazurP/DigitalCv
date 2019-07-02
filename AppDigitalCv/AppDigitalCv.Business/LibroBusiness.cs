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

            }
            else {
                tblLibro tblLibro = new tblLibro();

                tblLibro.idPais = libroDM.idPais;
                tblLibro.idPersonal = libroDM.idPersonal;
                tblLibro.idPersonal = libroDM.idPersonal;
                tblLibro.idStatus = libroDM.idStatus;
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
                tblLibro.bitConsideraCurriculum = libroDM.bitConsideraCurriculum;

                libroRepository.Insert(tblLibro);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
