﻿using AppDigitalCv.Business.Interface;
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
    public class DatosContactoBusiness : IDatosContacto
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly DatosContactoRepository  datosContactoRepository;
        //puedes agregar otro repository de otra tabla  de la misma forma
        
        public DatosContactoBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            datosContactoRepository = new DatosContactoRepository(unitOfWork);
            
        }


        /// <summary>
        /// Este Metodo se encarga de agregar o actualizar un registro a la base de datos
        /// </summary>
        /// <param name="datosContactoDM">recibe un objeto del tipo datosContactoDM</param>
        /// <returns>regresa un valor booleano</returns>
        public bool AddUpdateDatosContacto(DatosContactoDomainModel datosContactoDM)
        {
            bool respuesta = false;
            tblPersonal personal = null;
            if (datosContactoDM.IdDatosContacto  > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblDatosContacto datosContacto = datosContactoRepository.SingleOrDefault(p=> p.idDatosContacto == datosContactoDM.IdDatosContacto);
               
                if (datosContacto != null)
                {
                    tblTelefono tblTelefono = new tblTelefono();

                    tblTelefono.strTelefonoCasa = datosContactoDM.TelefonoCasa;
                    tblTelefono.strTelefonoCelular = datosContactoDM.TelefonoCelular;
                    tblTelefono.strTelefonoRecados = datosContactoDM.TelefonoRecados;

                    datosContacto.tblTelefono.Add(tblTelefono);

                    datosContacto.idDatosContacto = datosContactoDM.IdDatosContacto;
                    datosContacto.idPersonal = datosContactoDM.IdPersonal;
                    datosContacto.strEmailPersonal1 = datosContactoDM.MailPersonal;
                    datosContacto.strNombreFacebook = datosContactoDM.NombreFacebook;
                    datosContacto.strNombreTwitter = datosContactoDM.NombreTwitter;
                    datosContacto.strNombre = datosContactoDM.strNombre;
                    datosContacto.strApellidoPaterno = datosContactoDM.strApellidoPaterno;
                    datosContacto.strApellidoMaterno = datosContactoDM.strApellidoMaterno;
                    datosContacto.strDireccion = datosContactoDM.strDireccion;
                    datosContacto.bitContactoEmergencia = datosContactoDM.bitContactoEmergencia;
                    //asociasion de la tabla principal
                    datosContacto.tblPersonal = personal;
                    //actualizamos los datos en la base de datos.
                    datosContactoRepository.Update(datosContacto);
                    
                    respuesta = true;

                }
            }
            else
            {
               
                tblDatosContacto datosContacto = new tblDatosContacto();
                tblTelefono tblTelefono = new tblTelefono();

                tblTelefono.strTelefonoCasa = datosContactoDM.TelefonoCasa;
                tblTelefono.strTelefonoCelular = datosContactoDM.TelefonoCelular;
                tblTelefono.strTelefonoRecados = datosContactoDM.TelefonoRecados;

                datosContacto.tblTelefono.Add(tblTelefono);

                datosContacto.idPersonal = datosContactoDM.IdPersonal;
                datosContacto.strEmailPersonal1 = datosContactoDM.MailPersonal;
                datosContacto.strNombreFacebook = datosContactoDM.NombreFacebook;
                datosContacto.strNombreTwitter = datosContactoDM.NombreTwitter;
                datosContacto.strNombre = datosContactoDM.strNombre;
                datosContacto.strApellidoPaterno = datosContactoDM.strApellidoPaterno;
                datosContacto.strApellidoMaterno = datosContactoDM.strApellidoMaterno;
                datosContacto.strDireccion = datosContactoDM.strDireccion;
                datosContacto.bitContactoEmergencia = datosContactoDM.bitContactoEmergencia;

                ///insertamos en la entidad
                datosContactoRepository.Insert(datosContacto);
                respuesta = true;
            }
            return respuesta;
        }

        /// <summary>
        /// Este metodo se encarga de obtener los datos de contacto de una persona 
        /// </summary>
        /// <param name="idPersonal">recibe el identificador de una persona</param>
        /// <returns>regresa una entidad del tipo DatosContactoDomainModel</returns>
        public List<DatosContactoDomainModel> GetDatosDeContacto(int idPersonal)
        {
            Expression<Func<tblDatosContacto, bool>> predicado = p => p.idPersonal.Equals(idPersonal);
            List<DatosContactoDomainModel> listaDatosContacto = new List<DatosContactoDomainModel>();
            /////////tblDatosContacto TblDatosContacto = datosContactoRepository.SingleOrDefault(predicado);
            List<tblDatosContacto> TblDatosContacto = datosContactoRepository.GetAll(predicado).ToList();
            foreach (tblDatosContacto lista in TblDatosContacto)
            {
                DatosContactoDomainModel datosContactoDM = new DatosContactoDomainModel();
                datosContactoDM.IdDatosContacto = lista.idDatosContacto;
                datosContactoDM.IdPersonal = lista.idPersonal;
                datosContactoDM.MailPersonal = lista.strEmailPersonal1;
                datosContactoDM.NombreFacebook = lista.strNombreFacebook;
                datosContactoDM.NombreTwitter = lista.strNombreTwitter;
                datosContactoDM.strNombre = lista.strNombre;
                datosContactoDM.strApellidoPaterno = lista.strApellidoPaterno;
                datosContactoDM.strApellidoMaterno = lista.strApellidoMaterno;
                datosContactoDM.strDireccion = lista.strDireccion;
                datosContactoDM.bitContactoEmergencia = lista.bitContactoEmergencia.Value;
                foreach (tblTelefono t in lista.tblTelefono)
                {
                    datosContactoDM.TelefonoCelular = t.strTelefonoCelular;
                    datosContactoDM.TelefonoCasa = t.strTelefonoCasa;
                    datosContactoDM.TelefonoRecados = t.strTelefonoRecados;
                    datosContactoDM.IdTelefono = t.idTelefono;
                }
                listaDatosContacto.Add(datosContactoDM);
            }
            return listaDatosContacto;
        }

        /// <summary>
        /// este metodo se encarga de consultar los datos de contacto a una tabla
        /// </summary>
        /// <param name="idPersonal">recibe el identificador del personal</param>
        /// <returns>una entidad del tipo datoscontactodomainmodel</returns>
        public DatosContactoDomainModel GetDatosContacto(int id)
        {
            Expression<Func<tblDatosContacto, bool>> predicado = p => p.idDatosContacto.Equals(id);
            tblDatosContacto tblDatosContacto = datosContactoRepository.SingleOrDefault(predicado);
            DatosContactoDomainModel datosContactoDM = new DatosContactoDomainModel();
            datosContactoDM.IdDatosContacto = tblDatosContacto.idDatosContacto;
            datosContactoDM.IdPersonal = tblDatosContacto.idPersonal;
            datosContactoDM.MailPersonal = tblDatosContacto.strEmailPersonal1;
            datosContactoDM.NombreFacebook = tblDatosContacto.strNombreFacebook;
            datosContactoDM.NombreTwitter = tblDatosContacto.strNombreTwitter;
            datosContactoDM.strNombre = tblDatosContacto.strNombre;
            datosContactoDM.strApellidoPaterno = tblDatosContacto.strApellidoPaterno;
            datosContactoDM.strApellidoMaterno = tblDatosContacto.strApellidoMaterno;
            datosContactoDM.strDireccion = tblDatosContacto.strDireccion;
            datosContactoDM.bitContactoEmergencia = tblDatosContacto.bitContactoEmergencia.Value;
            foreach (tblTelefono t in tblDatosContacto.tblTelefono)
            {
                datosContactoDM.TelefonoCasa = t.strTelefonoCasa;
                datosContactoDM.TelefonoCelular = t.strTelefonoCelular;
                datosContactoDM.TelefonoRecados = t.strTelefonoRecados;
                datosContactoDM.IdTelefono = t.idTelefono;
            }
            return datosContactoDM;
        }


        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente un datos de contacto de la base de datos
        /// </summary>
        /// <param name="datosContactoDomainModel">recive una entidad del tipo DatosContactoDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        public bool DeleteDatosContactoDocente(DatosContactoDomainModel datosContactoDomainModel)
        {
            bool respuesta = false;
            Expression<Func<tblDatosContacto, bool>> predicado = p => p.idDatosContacto.Equals(datosContactoDomainModel.IdDatosContacto);
            datosContactoRepository.Delete(predicado);
            respuesta = true;
            return respuesta;
        }


    }
}
