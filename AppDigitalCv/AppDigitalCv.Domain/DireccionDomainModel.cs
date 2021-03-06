﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class DireccionDomainModel
    {
        public int IdDireccion { get; set; }
        public string StrCalle { get; set; }
        public string StrNumeroInterior { get; set; }
        public string StrNumeroExterior { get; set; }
        public int IdColonia { get; set; }
        public bool bitActual { get; set; }
        public int idPersonal { get; set; }

        //Objetos de las relaciones

        public ColoniaDomainModel Colonia { get; set; }
    }
}
