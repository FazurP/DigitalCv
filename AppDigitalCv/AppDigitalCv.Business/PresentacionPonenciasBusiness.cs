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
    public class PresentacionPonenciasBusiness : IPresentacionPonenciasBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PresentacionPonenciasRepository presentacionPonenciasRepository;

        public PresentacionPonenciasBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            presentacionPonenciasRepository = new PresentacionPonenciasRepository(unitOfWork);
        }

        public bool AddPonencia(PresentacionPonenciasDomainModel presentacionPonenciasDomainModel)
        {
            bool respuesta = false;

            if (presentacionPonenciasDomainModel != null)
            {
                TblPresentacionPonencias tblPresentacionPonencias = new TblPresentacionPonencias();

                tblPresentacionPonencias.idPersonal = presentacionPonenciasDomainModel.idPersonal;
                tblPresentacionPonencias.strAño = presentacionPonenciasDomainModel.strAño;
                tblPresentacionPonencias.strInstitucionLugarPresete = presentacionPonenciasDomainModel.strLugarInstitucionPresento;
                tblPresentacionPonencias.strNombre = presentacionPonenciasDomainModel.strNombre;

                presentacionPonenciasRepository.Insert(tblPresentacionPonencias);
                respuesta = true;
            }

            return respuesta;
        }

        public List<PresentacionPonenciasDomainModel> GetPresentacionesPonencias(int idPersonal)
        {
            List<PresentacionPonenciasDomainModel> presentacionPonenciasDomainModels = new List<PresentacionPonenciasDomainModel>();

            List<TblPresentacionPonencias> tblPresentacionPonencias = presentacionPonenciasRepository.GetAll().Where(p => p.idPersonal == idPersonal).ToList();

            foreach (TblPresentacionPonencias item in tblPresentacionPonencias)
            {
                PresentacionPonenciasDomainModel presentacionPonenciasDomainModel = new PresentacionPonenciasDomainModel();

                presentacionPonenciasDomainModel.id = item.id;
                presentacionPonenciasDomainModel.idPersonal = item.idPersonal.Value;
                presentacionPonenciasDomainModel.strAño = item.strAño;
                presentacionPonenciasDomainModel.strLugarInstitucionPresento = item.strInstitucionLugarPresete;
                presentacionPonenciasDomainModel.strNombre = item.strNombre;

                presentacionPonenciasDomainModels.Add(presentacionPonenciasDomainModel);
            }

            return presentacionPonenciasDomainModels;

        }

        public PresentacionPonenciasDomainModel GetPresentacionPonencia(int idPonencia) 
        {
            PresentacionPonenciasDomainModel presentacionPonenciasDomainModel = new PresentacionPonenciasDomainModel();
            TblPresentacionPonencias tblPresentacionPonencias = presentacionPonenciasRepository.SingleOrDefault(p => p.id == idPonencia);

            presentacionPonenciasDomainModel.id = tblPresentacionPonencias.id;
            presentacionPonenciasDomainModel.idPersonal = tblPresentacionPonencias.idPersonal.Value;
            presentacionPonenciasDomainModel.strAño = tblPresentacionPonencias.strAño;
            presentacionPonenciasDomainModel.strLugarInstitucionPresento = tblPresentacionPonencias.strInstitucionLugarPresete;
            presentacionPonenciasDomainModel.strNombre = tblPresentacionPonencias.strNombre;

            return presentacionPonenciasDomainModel;
        }

        public bool DeletePresentacionPonencia(int idPonencia) 
        {
            bool respuesta = false;

            if (idPonencia > 0)
            {
                presentacionPonenciasRepository.Delete(p => p.id == idPonencia);
                respuesta = true;
            }

            return respuesta;
        }
    }
}
