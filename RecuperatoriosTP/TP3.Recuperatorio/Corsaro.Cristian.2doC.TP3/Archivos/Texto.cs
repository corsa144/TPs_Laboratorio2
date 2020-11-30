using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        public bool Guardar(string archivos, string datos)
        {
            bool seGuardo = false;
            StreamWriter streamWriter = null;
            using(streamWriter = new StreamWriter(archivos, true))
            {
                streamWriter.Write(datos);
                seGuardo = true;
            }
            return seGuardo;
           /* bool seGuardo = false;
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(archivos, true);
                streamWriter.Write(datos);
                seGuardo = true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
            return seGuardo;*/
        }

        public bool Leer(string archivos, out string datos)
        {
            bool seLeyo = false;
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(archivos,Encoding.UTF8);

                //string text = string.Empty;
                datos = streamReader.ReadToEnd();

                if (datos != null)
                {
                    seLeyo = true;
                    // text += newLine + "\n";
                    //newLine = streamReader.ReadLine();
                }
                
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
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
