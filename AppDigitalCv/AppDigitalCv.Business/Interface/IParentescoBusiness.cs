﻿using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IParentescoBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar todos los parentescos posibles dentro del catalogo de base de datos
        /// </summary>
        /// <returns>retorna una lista de parentescos</returns>
        List<ParentescoDomainModel> GetParentescos();

        /// <summary>
        /// Este metodo se encarga de consultar un aprentesco en particular
        /// </summary>
        /// <param name="idParentesco">recibe como parametro el identificador del parentesco</param>
        /// <returns>
        /// retorna  el parentesco del dato de contacto de emergencia de la persona
        /// </returns>
        List<ParentescoDomainModel> GetParentescoById(int idParentesco);
    }
}
