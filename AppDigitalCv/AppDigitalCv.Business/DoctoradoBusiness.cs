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
                tblDoctorado.dteFechaInicio = historialAcademico.dteFechaInicio;

                catDocumentos.strUrl = historialAcademico.Documentos.DocumentoFile.FileName;

                catDocumentos.TblDoctorado.Add(tblDoctorado);

                documentosRepository.Insert(catDocumentos);

                respuesta = true;
            }

            return respuesta;
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
                doctoradoDomainModel.idDocumento = item.idDocumento.Value;
                doctoradoDomainModel.idFuentaFinaciamientoDoctorado = item.idFuenteFinanciamientoDoctorado.Value;
                doctoradoDomainModel.idInstitucionAcreditaDoctorado = item.idInstitucionAcreditaDoctorado.Value;
                doctoradoDomainModel.idPersonal = item.idPersonal.Value;
                doctoradoDomainModel.idStatusDoctorado = item.idStatusDoctorado.Value;
                doctoradoDomainModel.strNombre = item.strNombre;
                doctoradoDomainModel.bitReconocimientePNPC = item.bitReconomientoPNPC.Value;
                doctoradoDomainModel.Documentos = new DocumentosDomainModel { StrUrl = item.catDocumentos.strUrl};
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
    }
}
