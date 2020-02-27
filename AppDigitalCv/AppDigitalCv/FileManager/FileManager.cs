using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AppDigitalCv.FileManager
{
    public static class FileManager
    {
        /// <summary>
        /// Elimina un archivo del servidor.
        /// </summary>
        /// <param name="path">Ruta del Archivo</param>
        /// <returns>True o False</returns>
        public static bool DeleteFileFromServer(string path) 
        {

            bool respuesta = false;

            try
            {
                File.Delete(path);
                respuesta = true;
            }
            catch (FileNotFoundException ex)
            {

                string e = ex.Message + ex.FileName;
            }

            return respuesta;
        }

        /// <summary>
        /// Este Metodo Verifica antes de guardar un archivo, si ya existe un archivo con el mismo nombre le agrega un caracter para
        /// diferenciar los archivos, de ser el caso contrario conserva su nombre original.
        /// </summary>
        /// <param name="path">Ruta donde se guadara el fichero</param>
        /// <param name="documentosVM">Fichero a manipular</param>
        /// <returns>Regresa un arreglo con los resultados de la manipulacion del fichero.</returns>
        public static Object[] CheckFileIfExist(string path, DocumentosVM documentosVM) 
        {
            Object[] tupla = new Object[2];

            string [] nuevoNombre = Directory.GetFiles(path);

            int cantidadArchivos = nuevoNombre.Length;

            string nombre = documentosVM.DocumentoFile.FileName.Remove(documentosVM.DocumentoFile.FileName.Length - 4, 4);
            string fullPath = Path.Combine(path + "\\" + documentosVM.DocumentoFile.FileName);

            if (File.Exists(fullPath))
            {

                string newPath = path + "\\" + nombre + cantidadArchivos + ".pdf";

                documentosVM.DocumentoFile.SaveAs(newPath);

                tupla[0] = true;
                tupla[1] = nombre + cantidadArchivos + ".pdf";
            }
            else
            {
                documentosVM.DocumentoFile.SaveAs(fullPath);
                tupla[0] = true;
                tupla[1] = documentosVM.DocumentoFile.FileName;
            };

           

            return tupla;
        }    
    }
}