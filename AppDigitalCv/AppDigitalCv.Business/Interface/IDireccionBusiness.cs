﻿using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IDireccionBusiness
    {
        /// <summary>
        /// Este metodo se encarga de obtener la lista de paises
        /// </summary>
        /// <returns> regresa una lista de direcciones con el pais cargado </returns>
        List<PaisDomainModel> GetPais();
        /// <summary>
        /// Metodo que se encarga de obtener la lista de estados por medio de un pais.
        /// </summary>
        /// <param name="idPais"> Pide como parametro el id del pais </param>
        /// <returns> Regresa una lista de Estados </returns>
        List<EstadoDomainModel> GetEstadoByIdPais(int idPais);
        /// <summary>
        /// Metodo encargado de consultar los municipios por estado
        /// </summary>
        /// <param name="idEstado"> Pide el id del estado </param>
        /// <returns> Regresa una lista de municipios </returns>
        List<MunicipioDomainModel> GetMunicipioByIdEstado(int idEstado);
        /// <summary>
        /// Metodo encargado de consultar las colonias por medio de el municipio
        /// </summary>
        /// <param name="idMunicipio"> Pide el id del municipio </param>
        /// <returns> Regres auna lista de colonias </returns>
        List<ColoniaDomainModel> GetColoniaByMunicipio(int idMunicipio);
        /// <summary>
        /// Metodo para consultar el codigo postal por medio de la colonia
        /// </summary>
        /// <param name="idColonia"> Pide el id de la colonia </param>
        /// <returns> Regresa una cadena, que es el codigo postal </returns>
        string GetCodigoPostalByColonia(int idColonia);
        /// <summary>
        /// Metodo para actualizar e insertar una direccion
        /// </summary>
        /// <param name="direccionDM"> Pide un objeto de direccion de domain model </param>
        /// <returns> Regresa un valor booleano </returns>
        bool AddUpdateDireccion(DireccionDomainModel direccionDM);
        
        /// <summary>
        /// Metodo que se encarga de obtener los datos de la direccion
        /// </summary>
        /// <param name="idPersona"> Pide el parametro del id de persona </param>
        /// <returns> Regresa un objeto del tipo direccion </returns>
        List<DireccionDomainModel> GetDirecciones(int idPersonal);
        /// <summary>
        /// Este metodo se encarga de eliminar fisicamente una direccion  de la base de datos
        /// </summary>
        /// <param name="direccionDomainModel">recive una entidad del tipo direccionDomainModel</param>
        /// <returns>regresa una respuesta del tipo true o false</returns>
        bool DeleteDireccion(DireccionDomainModel direccionDomainModel);

        DireccionDomainModel GetDireccion(int _idDireccion);


    }
}
