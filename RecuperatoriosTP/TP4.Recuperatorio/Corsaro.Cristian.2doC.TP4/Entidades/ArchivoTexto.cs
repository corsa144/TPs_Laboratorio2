using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class ArchivoTexto : IArchivos<string>
    {
        /// <summary>
        /// Guarda un listado de productos en la ruta del archivo indicado.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        public void Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            using (streamWriter = new StreamWriter(archivo, true))
            {
                streamWriter.Write(datos);
            }

        }
        /// <summary>
        /// Lee un listado de productos en la ruta del archivo indicado.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public string Leer(string archivo,  string datos)
        {
            StreamReader streamReader = null;
            try
            {
                string ruta = archivo + ".txt";
                streamReader = new StreamReader(archivo);

                string text = string.Empty;
                string newLine = streamReader.ReadLine();
                while (newLine != null)
                {
                    text += newLine + "\n";
                    newLine = streamReader.ReadLine();
                }

                datos = text;
                return datos;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error!",ex);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }
    }
}
