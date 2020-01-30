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
    public class MaestriaBusiness : IMaestriaBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly MaestriaRepository maestriaRepository;
        private readonly DocumentosRepository documentosRepository;

        public MaestriaBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            maestriaRepository = new MaestriaRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
        }

        public bool AddMaestria(HistorialAcademicoDomainModel historialAcademicoDomainModel)
        {
            bool respuesta = false;

            if (historialAcademicoDomainModel != null)
            {
                TblMaetria tblMaetria = new TblMaetria();

                tblMaetria.bitReconocidoPNPC = historialAcademicoDomainModel.bitReconocimientePNPC;
                tblMaetria.idFuentaFinanciamientoMaestria = historialAcademicoDomainModel.FuenteFinanciamiento;
                tblMaetria.idInstitucionAcreditaMaestria = historialAcademicoDomainModel.InstitucionAcredita;
                tblMaetria.idPersonal = historialAcademicoDomainModel.idPersonal;
                tblMaetria.idStatusMaestria = historialAcademicoDomainModel.Status;
                tblMaetria.strNombre = historialAcademicoDomainModel.strNombre;

                catDocumentos catDocumentos = new catDocumentos();

                catDocumentos.strUrl = historialAcademicoDomainModel.Documentos.DocumentoFile.FileName;
                catDocumentos.TblMaetria.Add(tblMaetria);
                documentosRepository.Insert(catDocumentos);
                respuesta = true;

            }
            
            return respuesta;
        }
    }
}
