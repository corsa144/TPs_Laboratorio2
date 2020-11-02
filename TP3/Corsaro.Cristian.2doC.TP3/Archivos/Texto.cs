using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto
    {
        public bool Guardar(string archivo, string datos)
        {
            bool seGuardo = false;
            StreamWriter streamWriter = null;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            try
            {
                string rutaCompleta = ruta + @"\" + archivo + ".txt";
                streamWriter = new StreamWriter(rutaCompleta, true);
                streamWriter.WriteLine(datos);
                seGuardo = true;
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
            return seGuardo;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool seLeyo = false;
            StreamReader streamReader = null;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                string rutaCompleta = ruta + @"\" + archivo + ".txt";
                streamReader = new StreamReader(rutaCompleta);

                string text = string.Empty;
                string newLine = streamReader.ReadLine();

                while (newLine != null)
                {
                    text += newLine + "\n";
                    newLine = streamReader.ReadLine();
                }
                datos = text;
                seLeyo = true;
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
