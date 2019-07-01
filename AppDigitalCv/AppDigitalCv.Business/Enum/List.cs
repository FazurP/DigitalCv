﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Enum
{
    public class List
    {
        public List<string> fillDocuments()
        {
            List<string> documents = new List<string>();
            documents.Insert(0,"--Seleccionar--");
            documents.Insert(1,"Licencia de Manejo");
            documents.Insert(2,"Pasaporte");
            documents.Insert(3,"Visa de USA");
            documents.Insert(4,"Visa de Canada");
            documents.Insert(5,"Seguridad Social");
            documents.Insert(6,"Registro Prof, Estatal");
            documents.Insert(7,"Cartilla Militar");
            documents.Insert(8,"IFE");
            documents.Insert(9,"Comprobante de Domicilio");
            documents.Insert(10,"Solicitud de Empleo");

            return documents;
        }

        public List<string> FillEstado()
        {
            List<string> estados = new List<string>();
            estados.Insert(0,"--Seleccionar--");
            estados.Insert(1,"Aceptado");
            estados.Insert(2,"Publicado");

            return estados;
        }

        public List<string> FillProposito()
        {
            List<string> proposito = new List<string>();
            proposito.Insert(0,"--Seleccionar--");
            proposito.Insert(1,"Asimilación de Tecnologia");
            proposito.Insert(2,"Creación");
            proposito.Insert(3,"Desarrollo Tecnologico");
            proposito.Insert(4,"Difusión");
            proposito.Insert(5,"Generación de Conocimiento");
            proposito.Insert(6,"Investigación Aplicada");
            proposito.Insert(7,"Transferencia Tecnologica");

            return proposito;
        }
    }
}