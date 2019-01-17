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
    public class PremiosDocenteBusiness : IPremiosDocenteBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PremiosDocenteRepository premiosDocenteRepository;
        

        public PremiosDocenteBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            premiosDocenteRepository = new PremiosDocenteRepository(unitOfWork);


        }

        /// <summary>
        ///este metodo sirve para agregar o editar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="premiosDocenteDM">recive una entidad PremiosDocente</param>
        /// <returns>regresa un valor bool con la respuesta de la transacción</returns>
        public bool AddUpdatePremiosDocente(PremiosDocenteDomainModel  premiosDocenteDM)
        {
            bool respuesta = false;
            string resultado = string.Empty;
            if (premiosDocenteDM.IdPersonal > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblPremiosDocente  tblPremios= premiosDocenteRepository.SingleOrDefault(p => p.idPersonal.Equals(premiosDocenteDM.IdPersonal));
                if (tblPremios != null)
                {
                    tblPremios.dteFechaObtencionPremio = DateTime.Parse( premiosDocenteDM.DteFechaObtencionPremio);
                    tblPremios.strInstitucion = premiosDocenteDM.StrInstitucion;
                    tblPremios.strNombrePremio = premiosDocenteDM.StrNombrePremio;
                    tblPremios.strActividadDesempeniada = premiosDocenteDM.StrActividadDesempeniada;
                    tblPremios.dteFechaInicioPremio = DateTime.Parse(premiosDocenteDM.DteFechaInicioPremio);
                    tblPremios.dteFechaFinPremio = DateTime.Parse(premiosDocenteDM.DteFechaFinPremio);
                    tblPremios.strTipoPremio = premiosDocenteDM.StrTipoPremio;
                    tblPremios.catDocumentos.strUrl = premiosDocenteDM.DocumentosDomainModel.StrUrl;
                    premiosDocenteRepository.Update(tblPremios);
                    respuesta = true;
                }
            }
            else
            {
                tblPremiosDocente tblPremios = new tblPremiosDocente();
                //catDocumentos catDocumento = new catDocumentos();
                //catDocumento.strUrl = premiosDocenteDM.DocumentosDomainModel.StrUrl;
                //tblPremios.catDocumentos = catDocumento;
                tblPremios.idDocumento = premiosDocenteDM.IdDocumento;
                tblPremios.idPersonal = premiosDocenteDM.IdPersonal;
                tblPremios.dteFechaObtencionPremio = DateTime.Parse(premiosDocenteDM.DteFechaObtencionPremio);
                tblPremios.strInstitucion = premiosDocenteDM.StrInstitucion;
                tblPremios.strNombrePremio = premiosDocenteDM.StrNombrePremio;
                tblPremios.strActividadDesempeniada = premiosDocenteDM.StrActividadDesempeniada;
                tblPremios.dteFechaInicioPremio = DateTime.Parse(premiosDocenteDM.DteFechaInicioPremio);
                tblPremios.dteFechaFinPremio = DateTime.Parse(premiosDocenteDM.DteFechaFinPremio);
                tblPremios.strTipoPremio = premiosDocenteDM.StrTipoPremio;
                premiosDocenteRepository.Insert(tblPremios);
                respuesta = true;
            }
            return respuesta;
        }


        /// <summary>
        ///este metodo sirve para agregar un registro de el contexto seleccionado
        /// </summary>
        /// <param name="premiosDocenteDM">recive una entidad PremiosDocente</param>
        /// <returns>regresa un valor bool con la respuesta de la transacción</returns>
        public bool AddPremiosDocente(PremiosDocenteDomainModel premiosDocenteDM)
        {
            bool respuesta = false;
            string resultado = string.Empty;
            tblPremiosDocente tblPremios = new tblPremiosDocente();
            tblPremios.idDocumento = premiosDocenteDM.IdDocumento;
            tblPremios.idPersonal = premiosDocenteDM.IdPersonal;
            tblPremios.dteFechaObtencionPremio = DateTime.Parse(premiosDocenteDM.DteFechaObtencionPremio);
            tblPremios.strInstitucion = premiosDocenteDM.StrInstitucion;
            tblPremios.strNombrePremio = premiosDocenteDM.StrNombrePremio;
            tblPremios.strActividadDesempeniada = premiosDocenteDM.StrActividadDesempeniada;
            tblPremios.dteFechaInicioPremio = DateTime.Parse(premiosDocenteDM.DteFechaInicioPremio);
            tblPremios.dteFechaFinPremio = DateTime.Parse(premiosDocenteDM.DteFechaFinPremio);
            tblPremios.strTipoPremio = premiosDocenteDM.StrTipoPremio;
            premiosDocenteRepository.Insert(tblPremios);
            respuesta = true;
            return respuesta;
        }




    }
}
