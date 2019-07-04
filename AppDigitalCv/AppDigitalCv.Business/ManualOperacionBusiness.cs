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
    public class ManualOperacionBusiness : IManualOperacionBusiness
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ManualOperacionRepository manualOperacionRepository;
        public ManualOperacionBusiness(IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            manualOperacionRepository = new ManualOperacionRepository(unitofWork);
        }

        public bool AddUpdateManualOperacion(ManualOperacionDomainModel manualOperacionDM)
        {
            bool respuesta = false;

            if (manualOperacionDM.id > 0)
            {

            }
            else
            {
                    tblManualOperacion tblManual = new tblManualOperacion();

                    tblManual.idPais = manualOperacionDM.idPais;
                    tblManual.idPersonal = manualOperacionDM.idPersonal;
                    tblManual.idStatus = manualOperacionDM.idStatus;
                    tblManual.strDescripcion = manualOperacionDM.strDescripcion;
                    tblManual.strInstitucionBeneficiaria = manualOperacionDM.strInstitucionBeneficiaria;
                    tblManual.strNombre = manualOperacionDM.strNombre;
                    tblManual.dteFechaPublicacion = manualOperacionDM.dteFechaPublicacion;

                    manualOperacionRepository.Insert(tblManual);
                    respuesta = true;
                
            }

            return respuesta;
        }

        public List<ManualOperacionDomainModel> GetManualesByPersonal(int _idPersonal)
        {
            List<ManualOperacionDomainModel> manualesOperacion= new List<ManualOperacionDomainModel>();

            Expression<Func<tblManualOperacion, bool>> predicate = p => p.idPersonal == _idPersonal;
            List<tblManualOperacion> tblManual = manualOperacionRepository.GetAll(predicate).ToList();

            foreach (tblManualOperacion tblManualOperacion in tblManual)
            {
                ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();

                manualOperacionDM.id = tblManualOperacion.id;
                manualOperacionDM.idPais = tblManualOperacion.idPais.Value;
                manualOperacionDM.idPersonal = tblManualOperacion.idPersonal.Value;
                manualOperacionDM.idStatus = tblManualOperacion.idStatus.Value;
                manualOperacionDM.strAutor = tblManualOperacion.strAutor;
                manualOperacionDM.strDescripcion = tblManualOperacion.strDescripcion;
                manualOperacionDM.strInstitucionBeneficiaria = tblManualOperacion.strInstitucionBeneficiaria;
                manualOperacionDM.strNombre = tblManualOperacion.strNombre;
                manualOperacionDM.dteFechaPublicacion = tblManualOperacion.dteFechaPublicacion.Value;

                manualesOperacion.Add(manualOperacionDM);
            }

            return manualesOperacion;
        }

        public ManualOperacionDomainModel GetManualOperacion(int _idManual)
        {
            ManualOperacionDomainModel manualOperacionDM = new ManualOperacionDomainModel();

            Expression<Func<tblManualOperacion, bool>> predicate = p => p.id == _idManual;

            tblManualOperacion tblManualOperacion = manualOperacionRepository.GetAll(predicate).FirstOrDefault();

            manualOperacionDM.id = tblManualOperacion.id;
            manualOperacionDM.idPais = tblManualOperacion.idPais.Value;
            manualOperacionDM.idPersonal = tblManualOperacion.idPersonal.Value;
            manualOperacionDM.idStatus = tblManualOperacion.idStatus.Value;
            manualOperacionDM.strAutor = tblManualOperacion.strAutor;
            manualOperacionDM.strDescripcion = tblManualOperacion.strDescripcion;
            manualOperacionDM.strInstitucionBeneficiaria = tblManualOperacion.strInstitucionBeneficiaria;
            manualOperacionDM.strNombre = tblManualOperacion.strNombre;
            manualOperacionDM.dteFechaPublicacion = tblManualOperacion.dteFechaPublicacion.Value;

            return manualOperacionDM;
        }

        public bool DeleteManualOperacion(int _idManual)
        {
            bool respuesta = false;

            Expression<Func<tblManualOperacion, bool>> predicate = p => p.id == _idManual;

            manualOperacionRepository.Delete(predicate);
            respuesta = true;

            return respuesta;
        }
    }
}
