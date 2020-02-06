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

        public List<MaestriaDomainModel> GetMaestrias(int idPersonal)
        {
            List<MaestriaDomainModel> maestriaDomainModels = new List<MaestriaDomainModel>();
            List<TblMaetria> tblMaetrias = new List<TblMaetria>();

            tblMaetrias = maestriaRepository.GetAll().Where(p => p.idPersonal == idPersonal).ToList();

            foreach (TblMaetria item in tblMaetrias)
            {
                MaestriaDomainModel maestriaDomainModel = new MaestriaDomainModel();

                maestriaDomainModel.id = item.id;
                maestriaDomainModel.idDocumento = item.idDocumento.Value;
                maestriaDomainModel.idFuenteFinanciamientoMaestria = item.idFuentaFinanciamientoMaestria.Value;
                maestriaDomainModel.idInstitucionAcreditaMaestria = item.idInstitucionAcreditaMaestria.Value;
                maestriaDomainModel.idPersonal = item.idPersonal.Value;
                maestriaDomainModel.idStatusMaestria = item.idStatusMaestria.Value;
                maestriaDomainModel.strNombre = item.strNombre;
                maestriaDomainModel.bitReconocidoPNPC = item.bitReconocidoPNPC.Value;
                maestriaDomainModel.Documentos = new DocumentosDomainModel
                {
                    StrUrl = item.catDocumentos.strUrl
                };
                maestriaDomainModel.FuenteFinaciamientoMaestria = new FuenteFinaciamientoMaestriaDomainModel
                {
                    id = item.CatFuentaFinaciamientoMaestria.id,
                    strDescripcion = item.CatFuentaFinaciamientoMaestria.strDescripcion,
                    strValor =item.CatFuentaFinaciamientoMaestria.strValor
                };
                maestriaDomainModel.InstitucionAcreditaMaestria = new InstitucionAcreditaMaestriaDomainModel
                {
                    id = item.CatInstitucionAcreditaMaestria.id,
                    strDescripcion = item.CatFuentaFinaciamientoMaestria.strDescripcion,
                    strValor = item.CatInstitucionAcreditaMaestria.strValor
                };
                maestriaDomainModel.StatusMaestria = new StatusMaestriaDomainModel
                {
                    id = item.CatStatusMaestria.id,
                    strDescripcion = item.CatStatusMaestria.strDescripcion,
                    strValor =item.CatStatusMaestria.strValor
                };

                maestriaDomainModels.Add(maestriaDomainModel);

            }

            return maestriaDomainModels;
        }
        public MaestriaDomainModel GetMaestria(int _id)
        {
            MaestriaDomainModel maestriaDomainModel = new MaestriaDomainModel();
            TblMaetria tblMaetria = maestriaRepository.SingleOrDefault(p => p.id == _id);

            maestriaDomainModel.bitReconocidoPNPC = tblMaetria.bitReconocidoPNPC.Value;
            maestriaDomainModel.id = tblMaetria.id;
            maestriaDomainModel.idDocumento = tblMaetria.idDocumento.Value;
            maestriaDomainModel.idFuenteFinanciamientoMaestria = tblMaetria.idFuentaFinanciamientoMaestria.Value;
            maestriaDomainModel.idInstitucionAcreditaMaestria = tblMaetria.idInstitucionAcreditaMaestria.Value;
            maestriaDomainModel.idPersonal = tblMaetria.idPersonal.Value;
            maestriaDomainModel.idStatusMaestria = tblMaetria.idStatusMaestria.Value;
            maestriaDomainModel.strNombre = tblMaetria.strNombre;
            maestriaDomainModel.Documentos = new DocumentosDomainModel
            {
                StrUrl = tblMaetria.catDocumentos.strUrl
            };
            maestriaDomainModel.FuenteFinaciamientoMaestria = new FuenteFinaciamientoMaestriaDomainModel
            {
                strValor = tblMaetria.CatFuentaFinaciamientoMaestria.strValor
            };
            maestriaDomainModel.InstitucionAcreditaMaestria = new InstitucionAcreditaMaestriaDomainModel
            {
                strValor = tblMaetria.CatInstitucionAcreditaMaestria.strValor
            };
            maestriaDomainModel.StatusMaestria = new StatusMaestriaDomainModel
            {
                strValor = tblMaetria.CatStatusMaestria.strValor
            };

            return maestriaDomainModel;
        }

        public bool DeleteMaestria(HistorialAcademicoDomainModel historialAcademicoDomainModel)
        {
            bool respuesta = false;

            if (historialAcademicoDomainModel.Maestria.id > 0)
            {
                maestriaRepository.Delete(p => p.id == historialAcademicoDomainModel.Maestria.id);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
