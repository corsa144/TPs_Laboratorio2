using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class ArchivosTexto<T>
    {
        /// <summary>
        /// Guarda un listado de productos en la ruta del archivo indicado.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        public bool Guardar(string archivo,List<T> datos)
        {
            bool seGuardo;
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(archivo, false);
                foreach(T dato in datos)
                {
                    streamWriter.WriteLine(dato.ToString());
                }
                seGuardo = true;
            }catch(Exception ex)
            {
                seGuardo = false; 
            }
            finally
            {
                streamWriter.Close();
            }
            return seGuardo;
        }
        /// <summary>
        /// Lee un listado de productos en la ruta del archivo indicado.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out List<string> datos)
        {
            StreamReader streamReader = null;
            bool seLeyo = false;
            try
            {
                streamReader = new StreamReader(archivo);
                datos = new List<string>();
                string text = string.Empty;
                string newLine = streamReader.ReadLine();
                while (newLine != null)
                {
                    datos.Add(newLine);
                    newLine = streamReader.ReadLine();
                }
                seLeyo = true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error!", ex);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return seLeyo;
        }
    }
}