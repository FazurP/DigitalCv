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
    public class BachilleratoBusiness : IBachilleratoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly BachilleratoRepository bachilleratoRepository;
        private readonly DocumentosRepository documentosRepository;

        public BachilleratoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            bachilleratoRepository = new BachilleratoRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
        }

        public bool addBachillerato(HistorialAcademicoDomainModel historialAcademico)
        {
            bool respuesta = false;

            if (historialAcademico != null)
            {
                catDocumentos catDocumentos = new catDocumentos();
                TblBachillerato tblBachillerato = new TblBachillerato();

                tblBachillerato.strInstitucionAcreditaBachillerato = historialAcademico.strNombre;
                catDocumentos.strUrl = historialAcademico.Documentos.DocumentoFile.FileName;

                catDocumentos.TblBachillerato.Add(tblBachillerato);

                documentosRepository.Insert(catDocumentos);
                respuesta = true;
            }
            return respuesta;
        }
    }
}
