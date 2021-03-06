﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class ProduccionesArtisticasDomainModel
    {
        public int id { get; set; }
        public int idPais { get; set; }
        public int idPersonal { get; set; }
        public int idDocumento { get; set; }
        public int idProduccionesArtisticas { get; set; }
        public DocumentosDomainModel documentos { get; set; }
        public string strAutor { get; set; }
        public string strNombreObra { get; set; }
        public string strDescripcion { get; set; }
        public string strImpactoInvestigacion { get; set; }
        public string strImpactoMetodologia { get; set; }
        public string strImpactoDiseño { get; set; }
        public string strImpactoInnovacion { get; set; }
        public string dteFechaPublicacion { get; set; }
        public string strLugarPresento{ get; set; }
        public string strProposito { get; set; }

        //Objetos de las relaciones

        public ProduccionArtisticaDomainModel ProduccionArtistica { get; set; }
    }
}
