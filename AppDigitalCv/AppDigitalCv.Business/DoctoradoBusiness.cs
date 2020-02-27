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
        private readonly DocumentosProfesionalesRepository documentosProfesionalesRepository;

        public DoctoradoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            doctoradoRepository = new DoctoradoRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
            documentosProfesionalesRepository = new DocumentosProfesionalesRepository(unitOfWork);
        }

        public int AddDoctorado(HistorialAcademicoDomainModel historialAcademico)
        {
            if (historialAcademico != null)
            {
                TblDoctorado tblDoctorado = new TblDoctorado();
                TblDocumentosProfesionales tblDocumentacionProfesional = new TblDocumentosProfesionales();              

                tblDoctorado.bitReconomientoPNPC = historialAcademico.bitReconocimientePNPC;
                tblDoctorado.idFuenteFinanciamientoDoctorado = historialAcademico.FuenteFinanciamiento;
                tblDoctorado.idInstitucionAcreditaDoctorado = historialAcademico.InstitucionAcredita;
                tblDoctorado.idPersonal = historialAcademico.idPersonal;
                tblDoctorado.idStatusDoctorado = historialAcademico.Status;
                tblDoctorado.strNombre = historialAcademico.strNombre;
                tblDoctorado.dteFechaInicio = historialAcademico.dteFechaInicio;

                doctoradoRepository.Insert(tblDoctorado);

                return tblDoctorado.id;
            }

            return 0;
        }

        public List<DoctoradoDomainModel> GetDoctorados(int idPersonal)
        {
            List<DoctoradoDomainModel> doctoradoDomainModels = new List<DoctoradoDomainModel>();

            List<TblDoctorado> tblDoctorados = new List<TblDoctorado>();

            tblDoctorados = doctoradoRepository.GetAll().Where(p => p.idPersonal == idPersonal).ToList();

            foreach (TblDoctorado item in tblDoctorados)
            {
                DoctoradoDomainModel doctoradoDomainModel = new DoctoradoDomainModel();

                doctoradoDomainModel.id = item.id;
                doctoradoDomainModel.idFuentaFinaciamientoDoctorado = item.idFuenteFinanciamientoDoctorado.Value;
                doctoradoDomainModel.idInstitucionAcreditaDoctorado = item.idInstitucionAcreditaDoctorado.Value;
                doctoradoDomainModel.idPersonal = item.idPersonal.Value;
                doctoradoDomainModel.idStatusDoctorado = item.idStatusDoctorado.Value;
                doctoradoDomainModel.strNombre = item.strNombre;
                doctoradoDomainModel.bitReconocimientePNPC = item.bitReconomientoPNPC.Value;
                doctoradoDomainModel.FuenteFinanciamientoDoctorado = new FuenteFinanciamientoDoctoradoDomainModel
                {
                    id = item.CatFuenteFinanciamientoDoctorado.id,
                    strDescripcion =item.CatFuenteFinanciamientoDoctorado.strDescripcion,
                    strValor =item.CatFuenteFinanciamientoDoctorado.strValor
                };
                doctoradoDomainModel.InstitucionAcreditaDoctorado = new InstitucionAcreditaDoctoradoDomainModel
                {
                    id = item.CatInstitucionAcreditaDoctorado.id,
                    strDescripcion = item.CatInstitucionAcreditaDoctorado.strDescripcion,
                    strValor =item.CatInstitucionAcreditaDoctorado.strValor
                };
                doctoradoDomainModel.StatusDoctorado = new StatusDoctoradoDomainModel
                {
                    id = item.CatStatusDoctorado.id,
                    strDescripcion = item.CatStatusDoctorado.strDescripcion,
                    strValor =item.CatStatusDoctorado.strValor
                };

                doctoradoDomainModels.Add(doctoradoDomainModel);
            }

            return doctoradoDomainModels;
        }

        public DoctoradoDomainModel GetDoctorado(int idDoctorado)
        {
            DoctoradoDomainModel doctoradoDomainModel = new DoctoradoDomainModel();

            TblDoctorado tblDoctorado = doctoradoRepository.SingleOrDefault(p => p.id == idDoctorado);

            doctoradoDomainModel.id = tblDoctorado.id;
            doctoradoDomainModel.idFuentaFinaciamientoDoctorado = tblDoctorado.idFuenteFinanciamientoDoctorado.Value;
            doctoradoDomainModel.idInstitucionAcreditaDoctorado = tblDoctorado.idInstitucionAcreditaDoctorado.Value;
            doctoradoDomainModel.idPersonal = tblDoctorado.idPersonal.Value;
            doctoradoDomainModel.idStatusDoctorado = tblDoctorado.idStatusDoctorado.Value;
            doctoradoDomainModel.strNombre = tblDoctorado.strNombre;
            doctoradoDomainModel.bitReconocimientePNPC = tblDoctorado.bitReconomientoPNPC.Value;         
            doctoradoDomainModel.FuenteFinanciamientoDoctorado = new FuenteFinanciamientoDoctoradoDomainModel
            {
                strValor = tblDoctorado.CatFuenteFinanciamientoDoctorado.strValor
            };
            doctoradoDomainModel.InstitucionAcreditaDoctorado = new InstitucionAcreditaDoctoradoDomainModel
            {
                strValor = tblDoctorado.CatInstitucionAcreditaDoctorado.strValor
            };
            doctoradoDomainModel.StatusDoctorado = new StatusDoctoradoDomainModel
            {
                strValor = tblDoctorado.CatStatusDoctorado.strValor
            };
            doctoradoDomainModel.DocumentosProfesionales = new List<DocumentosProfesionalesDomainModel>();
            foreach (var item in tblDoctorado.TblDocumentosProfesionales)
            {
                DocumentosProfesionalesDomainModel documentosProfesionalesDomainModel = new DocumentosProfesionalesDomainModel();

                documentosProfesionalesDomainModel.strNombre = item.strNombre;
                documentosProfesionalesDomainModel.id = item.id;

                doctoradoDomainModel.DocumentosProfesionales.Add(documentosProfesionalesDomainModel);
            }

            return doctoradoDomainModel;
        }
        public bool DeleteDoctorado(HistorialAcademicoDomainModel historialAcademicoDomainModel)
        {
            bool respuesta = false;

            if (historialAcademicoDomainModel.Doctorado.id > 0)
            {
                doctoradoRepository.Delete(p => p.id == historialAcademicoDomainModel.Doctorado.id);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
