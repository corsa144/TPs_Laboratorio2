using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    [Serializable]
    public class Venta : IArchivos<Venta>
    {
        public enum ConceptoDePago
        {
            venta,
            reparacion
        }
        private Producto producto;
        private string nombreCliente;
        private ConceptoDePago concepto;
        private int codigo;
        public Venta()
        {

        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="concepto"></param>
        public Venta(string nombre, ConceptoDePago concepto, Producto producto, int codigo)
            :this(nombre, concepto, producto)
        {
            this.Codigo = codigo;
        }

        public Venta(string nombre, ConceptoDePago concepto, Producto producto)
            
        {
            this.NombreCliente = nombre;
            this.concepto = concepto;
            this.Producto = producto;
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
        /// Concepto de cobro. Debe ser alguna de las dos opciones(venta o repacion). 
        /// </summary>
        public ConceptoDePago Concepto
        {
            get
            {
                if (concepto == ConceptoDePago.reparacion || concepto == ConceptoDePago.venta)
                {
                    return this.concepto;
                }
                return ConceptoDePago.venta;
            }
            set
            {
                this.concepto = value;
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

        public Producto Producto
        {
            get
            {
                return this.producto;
            }
            set
            {
                this.producto = value;
            }
        }

        /// <summary>
        /// Llama a los métodos Guardar tanto para archivos de texto como para sql.
        /// </summary>
        /// <param name="bomberoIndex"></param>
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
            try
            {
                streamWriter = new StreamWriter("Venta.txt", false);
                streamWriter.Write(info.Codigo + ",");
                streamWriter.Write(info.NombreCliente + ",");
                streamWriter.Write(info.producto.Codigo + ",");
                streamWriter.Write(info.Concepto +"\n");


            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
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

                //string text = string.Empty;
                string newLine = streamReader.ReadLine();              

                while (newLine != null)
                {
                    string[] arr;
                    //text += newLine + "\n";
                    
                    arr = newLine.Split(',');
                    Console.WriteLine(newLine);
                    
                    string nombre = arr[1];
                    ConceptoDePago concepto = (ConceptoDePago)Enum.Parse(typeof(ConceptoDePago), arr[3]);
                    int codigo;
                    int.TryParse(arr[0], out codigo);
                    
                    Producto producto = new Producto();
                    int codigoProducto;
                    int.TryParse(arr[2], out codigoProducto);
                    producto.Codigo = codigoProducto;



                    Venta venta = new Venta(nombre, concepto, producto, codigo);
                    ventas.Add(venta);
                    newLine = streamReader.ReadLine();

                }
                return ventas;
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
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
            cadena.AppendLine(String.Format("Producto: {0}", this.producto.Nombre));
            cadena.AppendLine(String.Format($"Concepto de venta:{this.Concepto}"));

            return cadena.ToString();
        }
    }
}
