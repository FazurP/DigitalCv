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
    public class DireccionBusiness : IDireccionBusiness
    {
        // Creacion de los objetos del respositorio
        private readonly IUnitOfWork unitOfWork;
        private readonly PaisRepository paisRepository;
        private readonly EstadoRepository estadoRepository;
        private readonly MunicipioRepository municipioRepository;
        private readonly ColoniaRepository coloniaRepository;
        private readonly DireccionRepository direccionRepository;

        private readonly PersonalRepository personalRepository;

        public DireccionBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            paisRepository = new PaisRepository(unitOfWork);
            estadoRepository = new EstadoRepository(unitOfWork);
            municipioRepository = new MunicipioRepository(unitOfWork);
            coloniaRepository = new ColoniaRepository(unitOfWork);
            direccionRepository = new DireccionRepository(unitOfWork);
            personalRepository = new PersonalRepository(unitOfWork);
        }

        /// <summary>
        /// Metodo para obtener los paises 
        /// </summary>
        /// <returns> Regresa una lista de los paises </returns>
        public List<PaisDomainModel> GetPais()
        {
            ///creamos la lista de paises, se encuentra vacia
            List<PaisDomainModel> paises = null;

            //consultamos todos los paises y los almacenamos en la lista de paises
            paises = paisRepository.GetAll().Select(p => new PaisDomainModel { IdPais = p.id, StrValor = p.strValor }).ToList();
            PaisDomainModel inicial = new PaisDomainModel();
            inicial.IdPais = 0;
            inicial.StrValor = "-- Seleccionar --";
            paises.Insert(0, inicial);
            return paises;
        }

        /// <summary>
        /// Este metodo se encarga de consultar estados por el id del páis
        /// </summary>
        /// <param name="idPais"> Recibe el id del pais</param>
        /// <returns> Regresa una lista de estados que pertenecen a un pais </returns>
        public List<EstadoDomainModel> GetEstadoByIdPais(int idPais)
        {
            List<CatEstado> catEstados = null;
            Expression<Func<CatEstado, bool>> predicado = p => p.idPais.Equals(idPais);

            List<EstadoDomainModel> estadosDM = new List<EstadoDomainModel>();
            catEstados = estadoRepository.GetAll(predicado).ToList();

            foreach (CatEstado estados in catEstados)
            {
                EstadoDomainModel estadoDM = new EstadoDomainModel();
                estadoDM.IdEstado = estados.id;
                estadoDM.StrValor = estados.strValor;
                estadoDM.IdPais = estados.idPais;
                estadosDM.Add(estadoDM);
            }

            EstadoDomainModel estadoDomainModel = new EstadoDomainModel();

            estadoDomainModel.IdEstado = 0;
            estadoDomainModel.IdPais = 0;
            estadoDomainModel.StrValor = "Seleccionar";

            estadosDM.Insert(0, estadoDomainModel);

            return estadosDM;
        }

        /// <summary>
        /// Este metodo se encarga de consultar los municipios por el id del estado
        /// </summary>
        /// <param name="idEstado"> Requiere recibir el id del estado </param>
        /// <returns> Regresa una lista de los estados dependiendo el pais seleccionado </returns>
        public List<MunicipioDomainModel> GetMunicipioByIdEstado(int idEstado)
        {
            List<CatMunicipio> catMunicipios = null;
            Expression<Func<CatMunicipio, bool>> predicado = p => p.idEstado.Equals(idEstado);

            List<MunicipioDomainModel> municipiosDM = new List<MunicipioDomainModel>();
            catMunicipios = municipioRepository.GetAll(predicado).ToList();


            foreach (CatMunicipio municipios in catMunicipios)
            {
                MunicipioDomainModel municipioDM = new MunicipioDomainModel();
                municipioDM.IdMunicipio = municipios.id;
                municipioDM.StrValor = municipios.strValor;
                municipioDM.IdEstado = municipios.idEstado;
                municipiosDM.Add(municipioDM);
            }
            return municipiosDM;
        }

        /// <summary>
        /// Este metodo se encarga de consultar las colonias por medio del id del municipio
        /// </summary>
        /// <param name="idMunicipio"> Requere del id del municipio para realizar la consulta </param>
        /// <returns> Regresa una lista de colonias dependiendo del municipio seleccionado </returns>
        public List<ColoniaDomainModel> GetColoniaByMunicipio(int idMunicipio)
        {
            List<CatColonia> catColonias = null;
            Expression<Func<CatColonia, bool>> predicado = p => p.idMunicipio.Equals(idMunicipio);

            List<ColoniaDomainModel> coloniasDM = new List<ColoniaDomainModel>();
            catColonias = coloniaRepository.GetAll(predicado).ToList();

            foreach (CatColonia colonias in catColonias)
            {
                ColoniaDomainModel coloniaDM = new ColoniaDomainModel();
                coloniaDM.IdColonia = colonias.id;
                coloniaDM.StrValor = colonias.strValor;
                coloniaDM.IntCp = colonias.intCp;
                coloniaDM.IdMunicipio = colonias.idMunicipio;
                coloniasDM.Add(coloniaDM);
            }
            return coloniasDM;
        }

        /// <summary>
        /// Metodo para obtener el codigo postal por medio de la colonia
        /// </summary>
        /// <param name="idColonia"> Pide un parametro de tipo entero que es el id de la colonia </param>
        /// <returns> Regresa una cadena de texto, que es el codigo postal </returns>
        public string GetCodigoPostalByColonia(int idColonia)
        {
            string codigoPostal = string.Empty;
            List<CatColonia> catColonia = null;
            Expression<Func<CatColonia, bool>> predicado = p => p.id.Equals(idColonia);

            List<ColoniaDomainModel> colonias = new List<ColoniaDomainModel>();
            catColonia = coloniaRepository.GetAll(predicado).ToList();

            foreach (CatColonia col in catColonia)
            {
                codigoPostal = col.intCp.ToString();
            }

            return codigoPostal;
        }

        /// <summary>
        /// Método para agregar o editar un registro del contexto seleccionado
        /// </summary>
        /// <param name="direccionDM"> Pide un objeto de tipo direccion </param>
        /// <returns> Regresa un true o false </returns>
        public bool AddUpdateDireccion(DireccionDomainModel direccionDM)
        {
            bool respuesta = false;
            if (direccionDM.IdDireccion > 0)
            {
                catDireccion direccion = direccionRepository.SingleOrDefault(p => p.idDireccion == direccionDM.IdDireccion);

                if (direccion != null)
                {
                    direccion.strCalle = direccionDM.StrCalle;
                    direccion.strNumeroInterior = direccionDM.StrNumeroInterior;
                    direccion.strNumeroExterior = direccionDM.StrNumeroExterior;
                    direccion.idColonia = direccionDM.IdColonia;
                    direccion.idPersonal = direccionDM.idPersonal;
                    direccion.bitActual = direccionDM.bitActual;
                    direccionRepository.Update(direccion);
                    respuesta = true;
                }
            }
            else
            {
                catDireccion direccion = new catDireccion();
                direccion.strCalle = direccionDM.StrCalle;
                direccion.strNumeroInterior = direccionDM.StrNumeroInterior;
                direccion.strNumeroExterior = direccionDM.StrNumeroExterior;
                direccion.idColonia = direccionDM.IdColonia;
                direccion.idPersonal = direccionDM.idPersonal;
                direccion.bitActual = direccionDM.bitActual;
                direccionRepository.Insert(direccion);
                respuesta = true;
            }
            return respuesta;
        }

        /// <summary>
        /// Metodo que se encarga de obtener los datos de la direccion
        /// </summary>
        /// <param name="idPersona"> Pide el parametro del id de persona </param>
        /// <returns> Regresa un objeto del tipo direccion </returns>
        public List<DireccionDomainModel> GetDirecciones(int idPersonal)
        {
            List<DireccionDomainModel> direcciones = new List<DireccionDomainModel>();
            List<catDireccion> catDireccions = new List<catDireccion>();

            catDireccions = direccionRepository.GetAll().Where(p => p.idPersonal == idPersonal).ToList();

            foreach (catDireccion item in catDireccions)
            {
                DireccionDomainModel direccionDomainModel = new DireccionDomainModel();

                direccionDomainModel.IdColonia = item.idColonia;
                direccionDomainModel.IdDireccion = item.idDireccion;
                direccionDomainModel.Colonia = new ColoniaDomainModel { IdColonia = item.CatColonia.id, IdMunicipio = item.CatColonia.idMunicipio, IntCp = item.CatColonia.intCp, StrValor = item.CatColonia.strValor };
                direccionDomainModel.StrCalle = item.strCalle;
                direccionDomainModel.StrNumeroExterior = item.strNumeroExterior;
                direccionDomainModel.StrNumeroInterior = item.strNumeroInterior;

                direcciones.Add(direccionDomainModel);

            }
            return direcciones;
        }

        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente una direccion  de la base de datos
        /// </summary>
        /// <param name="direccionDomainModel">recive una entidad del tipo direccionDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        public bool DeleteDireccion(DireccionDomainModel direccionDomainModel)
        {
            bool respuesta = false;
            Expression<Func<catDireccion, bool>> predicado = p => p.idDireccion.Equals(direccionDomainModel.IdDireccion);
            direccionRepository.Delete(predicado);
            respuesta = true;
            return respuesta;
        }

        public DireccionDomainModel GetDireccion(int _idDireccion) 
        {
            DireccionDomainModel direccion = new DireccionDomainModel();

            catDireccion catDireccion = new catDireccion();

            catDireccion = direccionRepository.GetAll().Where(p => p.idDireccion == _idDireccion).FirstOrDefault();

            direccion.IdColonia = catDireccion.idColonia;
            direccion.IdDireccion = catDireccion.idDireccion;
            direccion.idPersonal = catDireccion.idPersonal.Value;
            direccion.StrCalle = catDireccion.strCalle;
            direccion.StrNumeroExterior = catDireccion.strNumeroExterior;
            direccion.StrNumeroInterior = catDireccion.strNumeroInterior;
            direccion.bitActual = catDireccion.bitActual.Value;
            direccion.Colonia = new ColoniaDomainModel { IdColonia = catDireccion.CatColonia.id, IdMunicipio = catDireccion.CatColonia.idMunicipio, IntCp = catDireccion.CatColonia.intCp,StrValor = catDireccion.CatColonia.strValor };

            return direccion;
        }

    }
}
