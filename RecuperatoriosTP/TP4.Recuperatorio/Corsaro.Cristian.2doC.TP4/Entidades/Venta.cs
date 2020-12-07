using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Entidades
{
    public class Venta : IArchivos<Venta>
    {
        #region Atributos
        private List<Producto> productos;
        private string nombreCliente;
        private int codigo;
        #endregion
        #region Constructores
        public Venta()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="concepto"></param>
        public Venta(string nombre, int codigo)
            :this()
        {
            this.Codigo = codigo;
            this.NombreCliente = nombre;
        }
        #endregion
        #region Propiedades
        public int Codigo { get
            {
                return this.codigo;
            } set
            {
                this.codigo = value;
            }
        }
        /// <summary>
        /// propiedad de lectura y escritura del Nombre del cliente
        /// </summary>
        public string NombreCliente {
            get
            {
                return this.nombreCliente;
            }
            set
            {
                this.nombreCliente = value;
            }
        }

        public List<Producto> Productos
        {
            get
            {
                return this.productos;
            }
            set
            {
                this.productos = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Llama a los métodos Guardar tanto para archivos de texto como para sql.
        /// </summary>
        public void Vender()
        {
            IArchivos<Venta> archivo = this;
            archivo.Guardar("Venta.txt",this);
            Guardar(this);
            //GuardarProducto()
        }


        /// <summary>
        /// Implementacion que serializa el Venta pasado por parametro, dejando su informacion guardada en writer 
        /// </summary>
        /// <param name="info">La venta a convertir a texto </param>
        public void Guardar(Venta info)
        {
            StreamWriter streamWriter = null;
            string ruta = Directory.GetCurrentDirectory() + @"\Venta.txt";
            try
            {
                streamWriter = new StreamWriter(ruta, true);
                streamWriter.Write(info.NombreCliente + ",");
                foreach(Producto prod in info.Productos)
                {
                    streamWriter.Write(prod.Nombre + ",");
                    streamWriter.Write(prod.Precio + ",");
                }
                streamWriter.Write(info.Codigo + "\n");
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al guardar archivo!",ex);
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
        /// Implementacion explicita que se encarga de insertar en la tabla llamando al metodo correspondiente
        /// </summary>
        /// <param name="info">Recibe la informacion a guardar</param>
        void IArchivos<Venta>.Guardar(string archivo,Venta venta)
        {
            ConexionSQL sql = new ConexionSQL();
            
            sql.GuardarVenta(venta);
        }

        /// <summary>
        /// Lee la tabla de venta 
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="venta"></param>
        /// <returns></returns>
        Venta IArchivos<Venta>.Leer(string nombreArchivo,  Venta venta)
        {
            ConexionSQL sql = new ConexionSQL();

            venta = sql.LeerVenta();
            return venta;
            //return true;
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(String.Format($"Código: {this.Codigo}"));
            cadena.AppendLine(String.Format($"Nombre: {this.NombreCliente}"));
            foreach(Producto prod in this.Productos)
            {
                cadena.AppendLine($"nombre del poducto: {prod.Nombre}");
                cadena.AppendLine($"precio del producto: {prod.Precio}");
            }
            //cadena.AppendLine(String.Format($"Nombre del producto: {this.NombreProducto}"));
            //cadena.AppendLine(String.Format($"Precio del producto: {this.PrecioProducto}"));

            return cadena.ToString();
        }
        /// <summary>
        /// Lee una cadena de caracteres de un archivo de texto
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public string Leer(string nombreArchivo, string datos)
        {
            ArchivoTexto texto = new ArchivoTexto();
            texto.Leer(nombreArchivo, datos);
            return datos;
        }
        #endregion
    }
}
