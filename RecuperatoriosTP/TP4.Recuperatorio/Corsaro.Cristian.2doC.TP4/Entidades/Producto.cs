using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{

    public class Producto
    {
        #region Atributos
        private double precio;
        private int codigo;
        private string nombre;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor. Inicializa los atributos del producto. 
        /// </summary>
        /// <param name="codigo">Codigo único del producto en la base de datos.</param>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="precio">Precio del producto.</param>

        public Producto(int codigo, string nombre, double precio)
        {
            this.codigo = codigo;
            this.Precio = precio;
            this.Nombre = nombre;
        }
        public Producto()
        {

        }
        #endregion
        #region Propiedades
        /// <summary>
        /// Precio del producto. Debe ser mayor a 1. 
        /// </summary>
        public double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                if (value >= 1)
                {
                    this.precio = value;
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
        #endregion
        #region Metodos
        /// <summary>
        /// Devuelve un string con los datos de un producto: código, nombre, precio y concepto. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();
            cadena.AppendLine(String.Format($"Código: {this.Codigo}" ));
            cadena.AppendLine(String.Format($"Nombre: {this.Nombre}" ));
            cadena.AppendLine(String.Format("Precio: ${0:0.00}", this.Precio));

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
                if (cadena[i] < 'a' && cadena[i] > 'z' || cadena[i] < 'A' && cadena[i] > 'Z')
                {
                    esValido = false;
                    break;
                }
            }
            if (esValido)
            {
                return nombre;
            }
            else
            {
                throw new NombreProductoExeption("Error. Nombre invalido!");
            }

        }
        #endregion
    }
}
