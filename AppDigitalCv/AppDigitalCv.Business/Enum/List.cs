using System;
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

        public List<string> FillTipoParticipacion()
        {
            List<string> list = new List<string>();

            list.Insert(0, "--Seleccionar--");
            list.Insert(1, "Autor");
            list.Insert(2, "Compilador");
            list.Insert(3, "Editor");
            list.Insert(4, "Coordinador");
            list.Insert(5, "Traductor");

            return list;
        }

        public List<string> FillTipoProductividadInnovador()
        {
            List<string> list = new List<string>();

            list.Insert(0, "--Seleccionar--");
            list.Insert(1, "Patente");
            list.Insert(2, "Modelo de Utilidad");
            list.Insert(3, "Marca");
            list.Insert(4, "Denominacion de Origen");

            return list;
        }

        public List<string> FillClasificacionInternacional()
        {
            List<string> list = new List<string>();

            list.Insert(0, "--Seleccionar--");
            list.Insert(1, "A. Necesidades Corrientes de la Vida");
            list.Insert(2, "B. Tecnicas Industriales Diversas: Transportes");
            list.Insert(3, "C. Química: Metalúrgica");
            list.Insert(4, "D. Texiles: Papel");
            list.Insert(5, "E. Construcciones fijas");
            list.Insert(6, "F. Mecanica: Iluminacion: Calefaccion: Armamento: Voladura");
            list.Insert(7, "G. Fisica");
            list.Insert(8, "H. Electricidad");

            return list;
        }

        public List<string> FillTipoPrototipo()
        {
            List<string> list = new List<string>();

            list.Insert(0, "--Seleccionar--");
            list.Insert(1, "Arquitectonico");
            list.Insert(2, "Programa de Computo");
            list.Insert(3, "Diseño Industrial");
            list.Insert(4, "Desarrollo Industrial");

            return list;
        }

        public List<string> FllTipoPatrocinador()
        {
            List<string> list = new List<string>();

            list.Insert(0, "--Seleccionar--");
            list.Insert(1, "Interno");
            list.Insert(2, "Externo");

            return list;
        }

        public List<string> FillEstadoDireccionIndividualizada()
        {
            List<string> list = new List<string>();

            list.Insert(0, "--Seleccionar--");
            list.Insert(1, "En Proceso");
            list.Insert(2, "Concluida");

            return list;
        }

        public List<string> FillEstadoEstadia()
        {
            List<string> list = new List<string>();

            list.Insert(0,"--Seleccionar--");
            list.Insert(1,"En Proceso");
            list.Insert(2,"Concluida");

            return list;
        }

        public List<string> FillTutoria()
        {
            List<string> list = new List<string>();

            list.Insert(0,"--Seleccionar--");
            list.Insert(1, "Individual");
            list.Insert(2, "Grupal");

            return list;
        }

        public List<string> FillTipoTutoria()
        {
            List<string> list = new List<string>();

            list.Insert(0,"--Seleccionar--");
            list.Insert(1,"Guia en el Media Universitario y Academico");
            list.Insert(2,"Apoyo Metodologico en la Disciplina, Especialidad o Area de Conocimiento");

            return list;
        }

        public List<string> FillEstadoTutoria()
        {
            List<string> list = new List<string>();

            list.Insert(0,"--Seleccionar--");
            list.Insert(1,"En Proceso");
            list.Insert(2,"Concluida");

            return list;
        }
    }
}
