using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    public class Producto
    {
        #region Atributos
        private bool pasoControlCalidad;
        private double costo;
        private int codigo;
        private string nombre;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor. Inicializa los atributos del producto. 
        /// </summary>
        /// <param name="codigo">Codigo único del producto en la base de datos.</param>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="costo">Costo del producto.</param>
        /// <param name="controCalidad">true si paso control de calidad sino false</param>

        public Producto(int codigo, string nombre, double costo, bool controlCalidad)
        {
            this.Codigo = codigo;
            this.Costo = costo;
            this.Nombre = nombre;
            this.pasoControlCalidad = controlCalidad;
        }
        public Producto()
        {

        }
        #endregion
        #region Propiedades
        /// <summary>
        /// Costo del producto. Debe ser mayor a 1. 
        /// </summary>
        
        public double Costo
        {
            get
            {
                return this.costo;
            }
            set
            {
                if (value >= 1)
                {
                    this.costo = value;
                }
            }
        }

        /// <summary>
        /// Nombre del producto. 
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = Producto.ValidarNombre(value);
            }
        }

        /// <summary>
        /// Código del producto en la base de datos. 
        /// </summary>
        public int Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }
        }

        public bool PasoControlCalidad
        {
            get
            {
                return this.pasoControlCalidad;
            }
            set
            {
                this.pasoControlCalidad = value;
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Devuelve un string con los datos de un producto: código, nombre, costo y concepto. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.Append(String.Format($"{this.Codigo}," ));
            cadena.Append(String.Format($"{this.Nombre}," ));
            cadena.Append(String.Format($"{this.Costo},"));
            cadena.Append(String.Format($"{this.PasoControlCalidad},"));

            return cadena.ToString();
        }

        /// <summary>
        /// Comprueba que el texto recibido sean solo letras. 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private static string ValidarNombre(string nombre)
        {

            bool esValido = true;
            char[] cadena = nombre.ToCharArray();
            for (int i = 0; i < cadena.Length; i++)
            {
                if (!char.IsLetter(cadena[i]))
                {
                    esValido = false;
                    break;
                }
            }
            if (esValido)
            {
                return nombre;
            }else
            {
                throw new NombreProductoExeption("Error. Nombre invalido!");
            }

        }

        public static bool operator ==(Producto p1, Producto p2)
        {
            return p1.Codigo == p2.Codigo;
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
