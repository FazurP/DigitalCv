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
    public class HistorialAcademicoBusiness : IHistorialAcademicoBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DoctoradoRepository doctoradoRepository;
        private readonly MaestriaRepository maestriaRepository;
        private readonly LecenciaturaIngenieriaRepository licenciaturaIngRepository;
        private readonly BachilleratoRepository bachilleratoRepository;

        public HistorialAcademicoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            doctoradoRepository = new DoctoradoRepository(unitOfWork);
            maestriaRepository = new MaestriaRepository(unitOfWork);
            licenciaturaIngRepository = new LecenciaturaIngenieriaRepository(unitOfWork);
            bachilleratoRepository = new BachilleratoRepository(unitOfWork);
        }

        public List<HistorialAcademicoDomainModel> GetHistorialesAcademicos(int _idPersona)
        {
            List<HistorialAcademicoDomainModel> historialAcademicoDomainModels = new List<HistorialAcademicoDomainModel>();

            List<DoctoradoDomainModel> doctoradoDomainModels = new List<DoctoradoDomainModel>();
            List<MaestriaDomainModel> maestriaDomainModels = new List<MaestriaDomainModel>();
            List<LicenciaturaIngenieriaDomainModel> licenciaturaIngenieriaDomainModels = new List<LicenciaturaIngenieriaDomainModel>();
            List<BachilleratoDomainModel> bachilleratoDomainModels = new List<BachilleratoDomainModel>();

            List<TblDoctorado> tblDoctorados = doctoradoRepository.GetAll().Where(p => p.idPersonal == _idPersona).ToList();
            List<TblMaetria> tblMaetrias = maestriaRepository.GetAll().Where(p => p.idPersonal == _idPersona).ToList();
            List<TblLicenciaturaIngenieria> tblLicenciaturaIngenierias = licenciaturaIngRepository.GetAll(p => p.idPersonal == _idPersona).ToList();

            foreach (TblDoctorado item in tblDoctorados)
            {
                HistorialAcademicoDomainModel tblDoctorado = new HistorialAcademicoDomainModel();

                tblDoctorado.Doctorado = new DoctoradoDomainModel
                {
                    bitReconocimientePNPC = item.bitReconomientoPNPC.Value,
                    id = item.id,

                    idFuentaFinaciamientoDoctorado = item.idFuenteFinanciamientoDoctorado.Value,
                    idInstitucionAcreditaDoctorado = item.idInstitucionAcreditaDoctorado.Value,
                    idPersonal = item.idPersonal.Value,
                    idStatusDoctorado = item.idStatusDoctorado.Value,
                    strNombre = item.strNombre,
                    FuenteFinanciamientoDoctorado = new FuenteFinanciamientoDoctoradoDomainModel
                    {
                        id = item.CatFuenteFinanciamientoDoctorado.id,
                        strDescripcion = item.CatFuenteFinanciamientoDoctorado.strDescripcion,
                        strValor = item.CatFuenteFinanciamientoDoctorado.strValor
                    },
                    InstitucionAcreditaDoctorado = new InstitucionAcreditaDoctoradoDomainModel
                    {
                        id = item.CatInstitucionAcreditaDoctorado.id,
                        strDescripcion = item.CatInstitucionAcreditaDoctorado.strDescripcion,
                        strValor = item.CatInstitucionAcreditaDoctorado.strDescripcion
                    },
                    StatusDoctorado = new StatusDoctoradoDomainModel
                    {
                        id = item.CatStatusDoctorado.id,
                        strDescripcion = item.CatStatusDoctorado.strDescripcion,
                        strValor = item.CatStatusDoctorado.strValor
                    }
                };

                historialAcademicoDomainModels.Add(tblDoctorado);
            }

            foreach (TblMaetria item in tblMaetrias)
            {
                HistorialAcademicoDomainModel tblMaetria = new HistorialAcademicoDomainModel();

                tblMaetria.Maestria = new MaestriaDomainModel
                {
                    bitReconocidoPNPC = item.bitReconocidoPNPC.Value,
                    id = item.id,
                   
                    idFuenteFinanciamientoMaestria = item.idFuentaFinanciamientoMaestria.Value,
                    idInstitucionAcreditaMaestria = item.idInstitucionAcreditaMaestria.Value,
                    idPersonal = item.idPersonal.Value,
                    idStatusMaestria = item.idStatusMaestria.Value,
                    strNombre = item.strNombre,
                  
                    FuenteFinaciamientoMaestria = new FuenteFinaciamientoMaestriaDomainModel
                    {
                        id = item.CatFuentaFinaciamientoMaestria.id,
                        strDescripcion = item.CatFuentaFinaciamientoMaestria.strDescripcion,
                        strValor = item.CatFuentaFinaciamientoMaestria.strValor
                    },
                    InstitucionAcreditaMaestria = new InstitucionAcreditaMaestriaDomainModel
                    {
                        id = item.CatInstitucionAcreditaMaestria.id,
                        strDescripcion = item.CatInstitucionAcreditaMaestria.strDescripcion,
                        strValor = item.CatInstitucionAcreditaMaestria.strValor
                    },
                    StatusMaestria = new StatusMaestriaDomainModel
                    {
                        id = item.CatStatusMaestria.id,
                        strDescripcion = item.CatStatusMaestria.strDescripcion,
                        strValor = item.CatStatusMaestria.strValor
                    }

                };

                historialAcademicoDomainModels.Add(tblMaetria);

            }

            foreach (TblLicenciaturaIngenieria item in tblLicenciaturaIngenierias)
            {
                TblLicenciaturaIngenieria tblLicenciaturaIngenieria = new TblLicenciaturaIngenieria();
            }

            return historialAcademicoDomainModels;
        }
    }
}
