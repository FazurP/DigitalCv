using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;

namespace AppDigitalCv.Business
{
    public class ParticipacionDocenteBusiness: IParticipacionDocenteBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly ParticipacionDocenteRepository IparticipacionDocenteRepository;

        public ParticipacionDocenteBusiness(IUnitOfWork unitOfWork, ParticipacionDocenteRepository iparticipacionDocenteRepository)
        {
            this.unitOfWork = unitOfWork;
            IparticipacionDocenteRepository = iparticipacionDocenteRepository;
        }

        /// <summary>
        /// Este metodo se encarga de agregar o actualizar los datos de participacion docebte de una persona
        /// </summary>
        /// <param name="participacionDocenteDM">recibe un objeto del tipo datos de  participaion docente</param>
        /// <returns>regresa un valor booleano</returns>
        public bool AddUpdateParticipacionDocente(ParticipacionDocenteDomainModel participacionDocenteDM)
        {
            bool respuesta = false;
            if (participacionDocenteDM.Id > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblParticipacionDocente tblParticipacionD = IparticipacionDocenteRepository.SingleOrDefault(p=> p.id == participacionDocenteDM.Id);
                if (tblParticipacionD != null)
                {
                    tblParticipacionD.id = participacionDocenteDM.Id;
                    tblParticipacionD.idCatDocumento = participacionDocenteDM.IdCatDocumento;
                    tblParticipacionD.idPersonal = participacionDocenteDM.IdPersonal;
                    tblParticipacionD.strEvento = participacionDocenteDM.StrEvento;
                    tblParticipacionD.strLugar = participacionDocenteDM.StrLugar;
                    tblParticipacionD.strNombreInstitucionEmpresa = participacionDocenteDM.StrNombreInstitucionEmpresa;
                    tblParticipacionD.strNombrePonencia = participacionDocenteDM.StrNombrePonencia;
                    tblParticipacionD.strParticipacion = participacionDocenteDM.StrParticipacion;
                    tblParticipacionD.strTipoEvento = participacionDocenteDM.StrTipoEvento;
                    tblParticipacionD.strTipoParticipacion = participacionDocenteDM.StrTipoParticipacion;
                    tblParticipacionD.bitPonencia = participacionDocenteDM.BitPonencia;
                    tblParticipacionD.dteFecha = DateTime.Parse( participacionDocenteDM.DteFecha);

                    IparticipacionDocenteRepository.Update(tblParticipacionD);
                    respuesta = true;

                }
            }
            else
            {

                tblParticipacionDocente tblParticipacionD = new tblParticipacionDocente();
                tblParticipacionD.id = participacionDocenteDM.Id;
                //tblParticipacionD.idCatDocumento = participacionDocenteDM.IdCatDocumento;
                tblParticipacionD.idPersonal = participacionDocenteDM.IdPersonal;
                tblParticipacionD.strEvento = participacionDocenteDM.StrEvento;
                tblParticipacionD.strLugar = participacionDocenteDM.StrLugar;
                tblParticipacionD.strNombreInstitucionEmpresa = participacionDocenteDM.StrNombreInstitucionEmpresa;
                tblParticipacionD.strNombrePonencia = participacionDocenteDM.StrNombrePonencia;
                tblParticipacionD.strParticipacion = participacionDocenteDM.StrParticipacion;
                tblParticipacionD.strTipoEvento = participacionDocenteDM.StrTipoEvento;
                tblParticipacionD.strTipoParticipacion = participacionDocenteDM.StrTipoParticipacion;
                tblParticipacionD.bitPonencia = participacionDocenteDM.BitPonencia;
                tblParticipacionD.dteFecha = DateTime.Parse(participacionDocenteDM.DteFecha);
                ///insertamos el documento
                catDocumentos catDocumentos = new catDocumentos();
                catDocumentos.strUrl = participacionDocenteDM.CatDocumentosDM.StrUrl;
                tblParticipacionD.catDocumentos = catDocumentos;
                IparticipacionDocenteRepository.Insert(tblParticipacionD);
               
                respuesta = true;
            }
            return respuesta;
        }
    }
}
