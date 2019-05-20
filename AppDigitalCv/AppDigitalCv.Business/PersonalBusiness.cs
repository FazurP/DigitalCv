using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///implementamos la libreria de expression para el delegado
using System.Linq.Expressions;
//caragmos la libreria io
using System.IO;

namespace AppDigitalCv.Business
{
    public class PersonalBusiness: IPersonalBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly PersonalRepository personalRepository;
        //puedes agregar otro repository de otra tabla  de la misma forma

        public PersonalBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            personalRepository = new PersonalRepository(unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de consulta una persona y actualiza el iddirecicon
        /// </summary>
        /// <param name="direccionDomainM">entidad el tipo direciconDM</param>
        /// <param name="idPersonal">el identificador de la persona</param>
        /// <returns>respuesta booleana</returns>
        public bool AddUpdatePersonalDireccion(DireccionDomainModel direccionDomainM,int idPersonal)
        {
            int IdPersonal = idPersonal;
            bool respuesta = false;
            if (direccionDomainM.IdDireccion > 0)
            {
                tblPersonal tblPersonal = personalRepository.SingleOrDefault(p => p.idPersonal.Equals(IdPersonal));
                tblPersonal.idDireccion = direccionDomainM.IdDireccion;
                personalRepository.Update(tblPersonal);
                respuesta = true;
            }
            return respuesta;
        }

        public string AddUpdatePersonalFamliar(PersonalDomainModel personalDM)
        {
            string resultado = string.Empty;
            if (personalDM.idPersonal > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblPersonal personal = personalRepository.SingleOrDefault(p => p.idPersonal == personalDM.idPersonal);
                if (personal != null)
                {
                    personal.idPersonal = personalDM.idPersonal;
                   /// personal.idFamiliar = personalDM.idFamiliar;
                    personalRepository.Update(personal);
                    resultado = "Se Actualizo correctamente";
                }
            }
            return resultado;
        }



        //este metodo sirve para agregar o editar un registro de el contexto seleccionado
        public string AddUpdatePersonal(PersonalDomainModel personalDM)
        {
            string resultado =string.Empty;
            if (personalDM.idPersonal > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblPersonal personal = personalRepository.SingleOrDefault(p => p.idPersonal == personalDM.idPersonal);
                if (personal != null)
                {
                    personal.strNombre = personalDM.Nombre;
                    personal.strApellidoPaterno = personalDM.ApellidoPaterno;
                    personal.strApellidoMaterno = personalDM.ApellidoMaterno;
                    personal.idEstadoCivil = personalDM.idEstadoCivil;
                    personal.strGenero = personalDM.strGenero;
                    personal.strCurp = personalDM.Curp;
                    personal.strRfc = personalDM.Rfc;
                    personal.strHomoclave = personalDM.Homoclave;
                    personal.strLogros = personalDM.strLogros;
                    personal.strUrlFoto = personalDM.strUrlFoto;
                    //actualizamos los datos en la base de datos.
                    personalRepository.Update(personal);
                    resultado = "Se Actualizo correctamente";

                }
            }
            else
            {
                tblPersonal personal = new tblPersonal();
                personal.strNombre = personalDM.Nombre;
                personal.strApellidoPaterno = personalDM.ApellidoPaterno;
                personal.strApellidoMaterno = personalDM.ApellidoMaterno;
                personal.idEstadoCivil = personalDM.idEstadoCivil;
                personal.strGenero = personalDM.strGenero;
                personal.strCurp = personalDM.Curp;
                personal.strRfc= personalDM.Rfc;
                personal.strUrlRfc = personalDM.strUrlRfc;
                personal.strUrlCurp = personalDM.strUrlCurp;
                personal.strLogros = personalDM.strLogros;
                personal.strUrlFoto = personalDM.strUrlFoto;
                
                /***********/ personal.archivoRfc = "archivo temporal"; /*********************/

                personal.strHomoclave = personalDM.Homoclave;
                var record = personalRepository.Insert(personal);
                resultado = "Se insertaron correctamente los valores";
            }
            return resultado;
        }

        /// <summary>
        /// Este metodo se encarga de Agregar o Actualizar el tipo de sangre del personal
        /// </summary>
        /// <param name="personalDM">una entidad del tipo personalDomain con el tipo de sangre</param>
        /// <returns>regresa una cadena de confirmación</returns>
        public string AddUpdateTipoSangre(PersonalDomainModel personalDM)
        {
            string resultado = string.Empty;
            if (personalDM.idTipoSangre > 0)
            {
                //buscamos por id y lo almacenamos en nuestra entidad de entityframework
                tblPersonal personal = personalRepository.SingleOrDefault(p => p.idPersonal == personalDM.idPersonal);
                if (personal != null)
                {
                    personal.idTipoSangre = personalDM.idTipoSangre;
                    //actualizamos los datos en la base de datos.
                    personalRepository.Update(personal);
                    resultado = "Se Actualizo correctamente";

                }
            }
           
            return resultado;
        }

        public List<PersonalDomainModel> GetEmpleado() {
            List<PersonalDomainModel> lista = null; 
            lista =personalRepository.GetAll().Select(p=> new PersonalDomainModel {Nombre = p.strNombre, ApellidoPaterno = p.strApellidoPaterno
            , ApellidoMaterno= p.strApellidoMaterno,Curp=p.strCurp,Rfc=p.strRfc,idPersonal =p.idPersonal}).ToList();
            return lista;
        }

        public List<PersonalDomainModel> GetEmpleadoDocumentos(int idPersonal)
        {
            List<PersonalDomainModel> lista = null;
            lista =personalRepository.GetAll().Select(p => new PersonalDomainModel
            {
                Nombre = p.strNombre,
                ApellidoPaterno = p.strApellidoPaterno,
                ApellidoMaterno = p.strApellidoMaterno,
                Curp = p.strCurp,
                Rfc = p.strRfc,
                idPersonal = p.idPersonal,
                strUrlRfc = p.strUrlRfc,
                strUrlCurp = p.strUrlCurp

            }).Where(P=>P.idPersonal==idPersonal).OrderBy(p=>p.Nombre).ToList();
            return lista;
        }


        /// <summary>
        /// este metodo se encarga de buscar a una persona por su id
        /// </summary>
        /// <param name="idPersonal">el identificador de la persona</param>
        /// <returns>regresa una persona en la capa de dominio</returns>
        public PersonalDomainModel GetPersonalById(int idPersonal)
        {
            Expression<Func<tblPersonal, bool>> predicado = p=> p.idPersonal.Equals(idPersonal);
            PersonalDomainModel personalDM = new PersonalDomainModel();

            tblPersonal TblPersonal= personalRepository.SingleOrDefault(predicado);
            personalDM.idPersonal = TblPersonal.idPersonal;
            personalDM.Nombre = TblPersonal.strNombre;
            personalDM.ApellidoPaterno = TblPersonal.strApellidoPaterno;
            personalDM.ApellidoMaterno = TblPersonal.strApellidoMaterno;
            personalDM.Curp = TblPersonal.strCurp;
            personalDM.Rfc = TblPersonal.strRfc;
            personalDM.Homoclave = TblPersonal.strHomoclave;
            personalDM.strLogros = TblPersonal.strLogros;
            //validamos que contenga el tipo de sangre
            if (TblPersonal.idTipoSangre > 0)
            {
                ///construimos el objeto del tipo de sangre
                TipoSangreDomainModel tipoSangreDomainModel = new TipoSangreDomainModel();
                tipoSangreDomainModel.IdTipoSangre = TblPersonal.catTipoSangre.idTipoSangre;
                tipoSangreDomainModel.StrDescripcion = TblPersonal.catTipoSangre.strDescripcion;
                personalDM.TipoSangreDomainModel = tipoSangreDomainModel; ///asocio el objeto.
            }
            return personalDM;
        }

        /// <summary>
        /// Este metodo se encargará de eliminar la url del curp
        /// </summary>
        /// <param name="idPersonal">el identificador del personal</param>
        /// <returns>regresa una respues en boolean para identificar el proceso</returns>
        public bool DeleteFileCurp(int idPersonal)
        {
            Expression<Func<tblPersonal, bool>> predicate = p => p.idPersonal == idPersonal;
            tblPersonal  personal=  personalRepository.SingleOrDefault(predicate);
            personal.strUrlCurp = string.Empty;
            personalRepository.Update(personal);
            return true;
        }
        /// <summary>
        /// Este metodo se encargará de eliminar la url del rfc
        /// </summary>
        /// <param name="idPersonal">el identificador del personal</param>
        /// <returns>retorna una respuesta booleana dependiendo la acción</returns>
        public bool DeleteFileRfc(int idPersonal)
        {
            Expression<Func<tblPersonal, bool>> predicate = p => p.idPersonal == idPersonal;
            tblPersonal personal = personalRepository.SingleOrDefault(predicate);
            personal.strUrlRfc = string.Empty;
            personalRepository.Update(personal);
            return true;
        }
               
        /// <summary>
        /// Este metodo se encarga de consultar la url de los documentos del personal
        /// </summary>
        /// <param name="idPersonal">el identificador del personal</param>
        /// <returns>regresa una lista con los documentos del personal</returns>
        public DocumentoPersonalDomainModel GetDocumentoPersonal(int idPersonal)
        {
            //List<DocumentoPersonalDomainModel> documentosPersonales = new List<DocumentoPersonalDomainModel>();
            Expression<Func<tblPersonal, bool>> predicate = p => p.idPersonal == idPersonal;
            var documentosPersonal = personalRepository.GetAll(predicate).ToList();
            DocumentoPersonalDomainModel documentoMD = new DocumentoPersonalDomainModel();

            foreach (var d in documentosPersonal)
            {
                if (d.idPersonal > 0)
                {
                    
                    documentoMD.IdPersonal = d.idPersonal;
                    documentoMD.UrlCurp = d.strUrlCurp;
                    documentoMD.UrlRfc = d.strUrlRfc;
              
                }
            }
            return documentoMD;
        }

        /// <summary>
        /// Este metodo se encarga de establecer un idDireccion de la tabla personal en null
        /// </summary>
        /// <param name="idPersonal">el identificador del personal</param>
        /// <returns>un valor true o false</returns>
        public bool UpdateCampoDireccionId(int idPersonal)
        {
            bool respuesta = false;
            tblPersonal personal = personalRepository.SingleOrDefault(p => p.idPersonal == idPersonal);
            if (personal != null)
            {
                personal.idDireccion = null;
                personalRepository.Update(personal);
                respuesta = true;
            }
            return respuesta;
        }
       

    }
}
