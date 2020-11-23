using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
        where T : new()
    {
        public bool Guardar(string archivo, T datos)
        {
            bool seGuardo = false;
            XmlTextWriter escritor = null;
            XmlSerializer serializador = null;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaCompleta = ruta + @"\" + archivo + ".xml";

            try
            {
                escritor = new XmlTextWriter(rutaCompleta,Encoding.UTF8);
                serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(escritor, datos);
            }
            finally
            {
                if(escritor != null)
                {
                    escritor.Close();
                }
            }
            return seGuardo;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool seLeyo = false;
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaCompleta = ruta + @"\" + archivo + ".xml";
            using (XmlTextReader lector = new XmlTextReader(rutaCompleta))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(lector);
                seLeyo = true;
            }
            return seLeyo;
        }
    }
}
