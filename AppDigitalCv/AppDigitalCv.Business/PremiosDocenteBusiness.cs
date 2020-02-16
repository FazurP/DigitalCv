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
    public class PremiosDocenteBusiness : IPremiosDocenteBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PremiosDocenteRepository premiosDocenteRepository;
        private readonly DocumentosRepository documentosRepository;
        

        public PremiosDocenteBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            premiosDocenteRepository = new PremiosDocenteRepository(unitOfWork);
            documentosRepository = new DocumentosRepository(unitOfWork);
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
            if (premiosDocenteDM.id > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblPremiosDocente  tblPremios= premiosDocenteRepository.SingleOrDefault(p => p.id.Equals(premiosDocenteDM.id));
                if (tblPremios != null)
                {
                    tblPremios.strInstitucion = premiosDocenteDM.StrInstitucion;
                    tblPremios.strNombrePremio = premiosDocenteDM.StrNombrePremio;
                    tblPremios.strActividadDesempeniada = premiosDocenteDM.StrActividadDesempeniada;
                    premiosDocenteRepository.Update(tblPremios);
                    respuesta = true;
                }
            }
            else
            {
                tblPremiosDocente tblPremios = new tblPremiosDocente();
                catDocumentos catDocumentos = new catDocumentos();

                tblPremios.idDocumento = premiosDocenteDM.IdDocumento;
                tblPremios.idPersonal = premiosDocenteDM.IdPersonal;
                tblPremios.dteFechaObtencionPremio = DateTime.Parse(premiosDocenteDM.DteFechaObtencionPremio);
                tblPremios.strInstitucion = premiosDocenteDM.StrInstitucion;
                tblPremios.strNombrePremio = premiosDocenteDM.StrNombrePremio;
                tblPremios.strActividadDesempeniada = premiosDocenteDM.StrActividadDesempeniada;

                catDocumentos.strUrl = premiosDocenteDM.Documentos.StrUrl;

                catDocumentos.tblPremiosDocente.Add(tblPremios);

                documentosRepository.Insert(catDocumentos);
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
            premiosDocenteRepository.Insert(tblPremios);
            respuesta = true;
            return respuesta;
        }

        /// <summary>
        /// Este metodo se encarga de obtener todos los premios del docente por idPersonal
        /// </summary>
        /// <param name="idPersonal">el identificador de personal</param>
        /// <returns>regresa una lista de premios del tipo domain model</returns>
        public List<PremiosDocenteDomainModel> GetPremiosDocenteById(int idPersonal)
        {
            List<PremiosDocenteDomainModel> premiosDM = new List<PremiosDocenteDomainModel>();
            Expression<Func<tblPremiosDocente, bool>> predicado = p => p.idPersonal.Equals(idPersonal);
            List<tblPremiosDocente> premios= premiosDocenteRepository.GetAll(predicado).ToList();

            foreach (tblPremiosDocente p in premios)
            {
                PremiosDocenteDomainModel premioDocenteDM = new PremiosDocenteDomainModel();
                premioDocenteDM.id = p.id;
                premioDocenteDM.IdPersonal = p.idPersonal.Value;
                premioDocenteDM.IdDocumento = p.idDocumento.Value;
                premioDocenteDM.DteFechaObtencionPremio = p.dteFechaObtencionPremio.ToString();
                premioDocenteDM.StrInstitucion = p.strInstitucion;
                premioDocenteDM.StrNombrePremio = p.strNombrePremio;
                premioDocenteDM.StrActividadDesempeniada = p.strActividadDesempeniada;
                premioDocenteDM.Documentos = new DocumentosDomainModel { StrUrl = p.catDocumentos.strUrl };

                premiosDM.Add(premioDocenteDM);
            }

            return premiosDM;

        }



        public PremiosDocenteDomainModel GetPremioDocenteById(int id,int idPersonal)
        {
            Expression<Func<tblPremiosDocente, bool>> predicado = p => p.id == id && p.idPersonal == idPersonal;
            tblPremiosDocente  premio= premiosDocenteRepository.SingleOrDefault(predicado);
            PremiosDocenteDomainModel premiosDDM = new PremiosDocenteDomainModel();
            premiosDDM.id = premio.id;
            premiosDDM.IdPersonal = premio.idPersonal.Value;
            premiosDDM.IdDocumento = premio.idDocumento.Value;
            premiosDDM.DteFechaObtencionPremio = premio.dteFechaObtencionPremio.ToString();
            premiosDDM.StrInstitucion = premio.strInstitucion;
            premiosDDM.StrNombrePremio = premio.strNombrePremio;
            premiosDDM.StrActividadDesempeniada = premio.strActividadDesempeniada;
            premiosDDM.Documentos = new DocumentosDomainModel 
            {
                StrUrl = premio.catDocumentos.strUrl
            };
            return premiosDDM;
        }

        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente un premio del docente de la base de datos
        /// </summary>
        /// <param name="familiarDomainModel">recive una entidad del tipo familiarDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        public bool DeletePremiosDocente(PremiosDocenteDomainModel premiosDocenteDomainModel)
        {
            bool respuesta = false;
            Expression<Func<tblPremiosDocente, bool>> predicado = p => p.idPersonal.Equals(premiosDocenteDomainModel.IdPersonal) 
            && p.idDocumento.Equals(premiosDocenteDomainModel.IdDocumento);
            premiosDocenteRepository.Delete(predicado);
            respuesta = true;
            return respuesta;
        }

    }
}
