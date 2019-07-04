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
    }
}
