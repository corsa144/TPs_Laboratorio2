using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    public class Fabrica 
    {
        #region Atributos
        private List<Producto> productos;
        private List<Producto> stock;
        private List<Producto> taller;
        private UInt32 almacenDeProductos;
        private static Fabrica fabrica;
        #endregion
        #region Constructores
        public Fabrica()
        {
            this.productos = new List<Producto>();
            this.stock = new List<Producto>();
            this.taller = new List<Producto>();
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="concepto"></param>
        public Fabrica(UInt32 almacenamiento)
            :this()
        {
            this.AlmacenDeProductos = almacenamiento;
        }
        #endregion
        #region Propiedades

        /// <summary>
        /// propiedad de lectura y escritura del Nombre del cliente
        /// </summary>
        public UInt32 AlmacenDeProductos {
            get
            {
                return this.almacenDeProductos;
            }
            set
            {
                if(this.almacenDeProductos == 0 || ReferenceEquals(this.almacenDeProductos,null))
                {
                    this.almacenDeProductos = 1;
                }
                else
                {
                    this.almacenDeProductos = value;
                }
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
       
        public List<Producto> Stock { get { return this.stock; } set { this.stock = value; } }

        public List<Producto> Taller { get { return this.taller; } set { this.taller = value; } }
        #endregion
        #region Metodos
        /// <summary>
        /// patron singleton para la clase
        /// </summary>
        /// <returns>Devuelve una fabrica</returns>
        public static Fabrica GetFabrica(UInt32 capacidad)
        {
            if (ReferenceEquals(null, fabrica))
            {
                fabrica = new Fabrica(capacidad);
            }
            else
            {
                fabrica.AlmacenDeProductos = capacidad;
            }
            return fabrica;
        }

        /// <summary>
        /// Implementacion que guarda en formato de texto la lista de productos, dejando su informacion guardada en writer 
        /// </summary>
        /// <param name="info">La lista a convertir a texto </param>
        public void Guardar()
        {
            List<Computadora> computadoras = new List<Computadora>();
            foreach(Producto p in this.Productos)
            {
                if(p is Computadora)
                {
                    computadoras.Add((Computadora)p);
                }
            }
            string ruta = Directory.GetCurrentDirectory() + @"\Computadoras.txt";
            ArchivosTexto<Computadora> texto = new ArchivosTexto<Computadora>();
            texto.Guardar(ruta, computadoras);
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(String.Format($"Espacio ocupado: {this.AlmacenDeProductos}"));
            foreach(Producto prod in this.Productos)
            {
                cadena.AppendLine($"Código: {prod.Codigo}");
                cadena.AppendLine($"nombre del poducto: {prod.Nombre}");
                cadena.AppendLine($"costo del producto: {prod.Costo}");
            }

            return cadena.ToString();
        }
        /// <summary>
        /// Lee una cadena de caracteres de un archivo de texto
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public Fabrica LeerTexto()
        {
            string ruta = Directory.GetCurrentDirectory() + @"\Computadoras.txt";
            List<string> productos = new List<string>();
            Fabrica fabrica = GetFabrica(this.AlmacenDeProductos);
            ArchivosTexto<Producto> texto = new ArchivosTexto<Producto>();
            texto.Leer(ruta,out productos);
            foreach(string producto in productos.ToArray())
            {
                string[] campos = producto.Split(',');
                if(campos[0] == "Computadora")
                {
                    Computadora.TipoComputadora tipo;
                    Computadora.ESistemaOperativo eSistema;
                    if(campos[5] == "0")
                    {
                        tipo = Computadora.TipoComputadora.Escritorio;
                    }
                    else
                    {
                        tipo = Computadora.TipoComputadora.Notebook;
                    }
                    switch (campos[6])
                    {
                        case "0":
                            eSistema = Computadora.ESistemaOperativo.Windows;
                            break;
                        case "1":
                            eSistema = Computadora.ESistemaOperativo.OSX;
                            break;
                        case "2":
                            eSistema = Computadora.ESistemaOperativo.Linux;
                            break;
                        default:
                            eSistema = Computadora.ESistemaOperativo.SinSistemaOperativo;
                            break;                        
                    }
                    Computadora computadora = new Computadora(int.Parse(campos[1]), campos[2], double.Parse(campos[3]),
                        tipo, eSistema, bool.Parse(campos[4]));
                    fabrica.Productos.Add(computadora);
                }
            }
            return fabrica;
        }
        /// <summary>
        /// guarda en xml
        /// </summary>
        /// <returns></returns>
        public bool GuardarXml()
        {
            List<Celular> celulares = new List<Celular>();
            foreach(Producto p in this.Productos)
            {
                if(p is Celular)
                {
                    celulares.Add((Celular)p);
                }
            }
            string ruta = Directory.GetCurrentDirectory() + @"\Celulares.xml";
            ArchivosXml<List<Celular>> stockXml = new ArchivosXml<List<Celular>>();

            if (stockXml.Guardar(ruta, celulares))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// lee un archivo xml
        /// </summary>
        /// <returns></returns>
        public Fabrica LeerXml()
        {
            string ruta = Directory.GetCurrentDirectory() + @"\Celulares.xml";
            List<Celular> celulares = new List<Celular>();
            //List<Producto> productos = new List<Producto>();
            Fabrica fabrica = GetFabrica(this.AlmacenDeProductos);
            ArchivosXml<List<Celular>> archivoXml = new ArchivosXml<List<Celular>>();
            archivoXml.Leer(ruta,out celulares);
            foreach(Celular c in celulares)
            {
                fabrica.Productos.Add(c);
            }

            return fabrica;

        }

        public static bool ControlDeCalidad(Producto p)
        {
            return p.PasoControlCalidad;
        }
        /// <summary>
        /// Envía el producto al stock o al taller según corresponda
        /// </summary>
        /// <param name="productos">Lista de productos</param>
        /// <returns>Devuelve la clase</returns>
        public void DerivarProductos()
        {
            if(!ReferenceEquals(null, this.Productos))
            {
                this.Stock.Clear();
                this.Taller.Clear();
                foreach(Producto p in this.Productos)
                {
                    if (ControlDeCalidad(p))
                    {
                        this.Stock.Add(p);
                    }
                    else
                    {
                        this.Taller.Add(p);
                    }
                }
            }
        }
        /// <summary>
        /// Muestra los productos separando stock de taller
        /// </summary>
        /// <returns></returns>
        public string MostrarProductos()
        {
            StringBuilder mensaje = new StringBuilder();
            if(!ReferenceEquals(this, null))
            {
                DerivarProductos();
                mensaje.Append("*** En stock ***\n");
                foreach (Producto p in this.Stock)
                {
                    mensaje.Append(MostrarUnProducto(p));
                }
                mensaje.Append("*** En taller ***\n");
                foreach( Producto prod in this.Taller)
                {
                    mensaje.Append(MostrarUnProducto(prod));
                }
            }
            else
            {
                mensaje.Append("Cargue los datos!");
            }
            return mensaje.ToString();
        }
        /// <summary>
        /// muestra un solo producto sea computadora o celular
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string MostrarUnProducto(Producto p)
        {
            StringBuilder mensaje = new StringBuilder();
            if (p is Computadora)
            {
                mensaje.Append("*** Computadora ***\n");
            }
            else if (p is Celular)
            {
                mensaje.Append("*** Celular ***\n");
            }
            mensaje.AppendLine($"{p.ToString()}");
            return mensaje.ToString();
        }
        #endregion
    }
}
