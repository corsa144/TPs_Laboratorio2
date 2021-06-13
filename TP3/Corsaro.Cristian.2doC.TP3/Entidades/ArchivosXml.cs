using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace Entidades
{
    public class ArchivosXml<Producto> : IArchivos<Producto>
    {
          public bool Guardar(string archivo, List<Producto> datos)
          {
            bool seGuardo = false;
            using (XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
                escritor.Formatting = Formatting.Indented;
                serializer.Serialize(escritor, datos);
                seGuardo = true;
            }
            return seGuardo;
        }

         public bool Leer(string archivo, out List<Producto> datos)
         {
            bool seLeyo = false;
            using (XmlTextReader lector = new XmlTextReader(archivo))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
                datos = (List<Producto>) serializer.Deserialize(lector);
                seLeyo = true;
            }
            return seLeyo;
         }
    }
}
