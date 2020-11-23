using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivoTexto : IArchivos<List<Producto>>
    {
        /// <summary>
        /// Guarda un listado de productos en la ruta del archivo indicado.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        public void Guardar(string archivo, List<Producto> datos)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(archivo, false);
                foreach (Producto producto in datos)
                {
                    streamWriter.Write(producto.Codigo + ",");
                    streamWriter.Write(producto.Nombre + ",");
                    streamWriter.Write(producto.Precio + ",");
                    streamWriter.Write(producto.Tipo + "\n");
                }

            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
                    
            }
        }
        /// <summary>
        /// Lee un listado de productos en la ruta del archivo indicado.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out List<Producto> datos)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(archivo);

                string text = string.Empty;
                string newLine = streamReader.ReadLine();

                datos = new List<Producto>();

                while (newLine != null)
                {
                    string[] arr;
                    text += newLine + "\n";
                    newLine = streamReader.ReadLine();
                    arr = newLine.Split(',');
                    int codigo;
                    int.TryParse(arr[0], out codigo);
                    double precio;
                    double.TryParse(arr[2], out precio);
                    Tipo tipo = (Tipo)Enum.Parse(typeof(Tipo), arr[3]);
                    Producto producto = new Producto(codigo,arr[1], precio,tipo);                    
                    datos.Add(producto);

                }
                return true;

            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
        }
    }
}
