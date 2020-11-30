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
        /*public enum ConceptoDePago
        {
            venta,
            reparacion
        }*/
        private List<Producto> productos;
        private string nombreCliente;
        //private ConceptoDePago concepto;
        private int codigo;
        private string nombreProducto;
        private double precioProducto;
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

        public Venta(string nombre, int codigo,string nombreProducto, double precioProducto)
             : this(nombre,codigo)
        {
            this.NombreProducto = nombreProducto;
            this.PrecioProducto = precioProducto;
        }

        public string NombreProducto
        { get
            {
                return this.nombreProducto;
            }
            set
            {
                this.nombreProducto = value;
            }
        }

        public double PrecioProducto {
            get
            {
                return this.precioProducto;
            }
            set
            {
                this.precioProducto = value;
            }
        }
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

        /// <summary>
        /// Llama a los métodos Guardar tanto para archivos de texto como para sql.
        /// </summary>
        public void Vender()
        {
            IArchivos<Venta> archivo = this;
            archivo.Guardar("Venta.txt",this);
            Guardar(this);
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
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>devuelve ventas</returns>
        public List<Venta> Leer(string ruta)
        {
            List<Venta> ventas = new List<Venta>();
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(ruta);

                string text = string.Empty;
                string newLine = streamReader.ReadLine();              

                while (newLine != null)
                {
                    string[] arr;
                    text += newLine + "\n";
                    
                    arr = text.Split(',');
                    string nombre = arr[0];                   
                    int codigo;
                    int.TryParse(arr[3], out codigo);
                    
                    Producto producto = new Producto();
                    /* int codigoProducto;
                     int.TryParse(arr[3], out codigoProducto);
                     producto.Codigo = codigoProducto;
                     */
                    string nombreProducto = arr[1];
                    double precioProducto;
                    double.TryParse(arr[2], out precioProducto);
                    Venta venta = new Venta(nombre, codigo,nombreProducto,precioProducto);
                    ventas.Add(venta);
                    newLine = streamReader.ReadLine();

                }
                return ventas;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
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
        bool IArchivos<Venta>.Leer(string nombreArchivo, out Venta venta)
        {
            ConexionSQL sql = new ConexionSQL();

            venta = sql.LeerVenta();
            return true;
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(String.Format($"Código: {this.Codigo}"));
            cadena.AppendLine(String.Format($"Nombre: {this.NombreCliente}"));
            cadena.AppendLine(String.Format($"Nombre del producto: {this.NombreProducto}"));
            cadena.AppendLine(String.Format($"Precio del producto: {this.PrecioProducto}"));

            return cadena.ToString();
        }
    }
}
