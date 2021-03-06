﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Domain
{
    public class CapituloLibroDomainModel
    {
        public int id { get; set; }
        public int idPersonal { get; set; }
        public string strAutor { get; set; }
        public string strTitulo { get; set; }
        public string enumEstadoActual { get; set; }
        public int idPais { get; set; }
        public string strEditorial { get; set; }
        public string strEdicion { get; set; }
        public string dteFechaPublicacion { get; set; }
        public string strTiraje { get; set; }
        public string strISBN { get; set; }
        public string enumProposito { get; set; }
        public string strTituloCapitulo { get; set; }
        public string strAutores { get; set; }
        public int paginaInicio { get; set; }
        public int paginaTermino { get; set; }
    }
}
