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
    public class DoctoradoBusiness : IDoctoradoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DoctoradoRepository doctoradoRepository;
        private readonly DocumentosRepository documentosRepository;

        public DoctoradoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            doctoradoRepository = new DoctoradoRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
        }

        public bool AddDoctorado(HistorialAcademicoDomainModel historialAcademico)
        {
            bool respuesta = false;

            if (historialAcademico != null)
            {
                TblDoctorado tblDoctorado = new TblDoctorado();
                catDocumentos catDocumentos = new catDocumentos();

                tblDoctorado.bitReconomientoPNPC = historialAcademico.bitReconocimientePNPC;
                tblDoctorado.idFuenteFinanciamientoDoctorado = historialAcademico.FuenteFinanciamiento;
                tblDoctorado.idInstitucionAcreditaDoctorado = historialAcademico.InstitucionAcredita;
                tblDoctorado.idPersonal = historialAcademico.idPersonal;
                tblDoctorado.idStatusDoctorado = historialAcademico.Status;
                tblDoctorado.strNombre = historialAcademico.strNombre;

                catDocumentos.strUrl = historialAcademico.Documentos.DocumentoFile.FileName;

                catDocumentos.TblDoctorado.Add(tblDoctorado);

                documentosRepository.Insert(catDocumentos);

                respuesta = true;
            }

            return respuesta;
        }
    }
}
