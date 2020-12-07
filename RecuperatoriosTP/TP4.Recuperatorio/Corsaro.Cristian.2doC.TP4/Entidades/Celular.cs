using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Celular:Producto
    {
        public enum Compania
        {
            Movistar,
            Personal,
            Claro,
            Libre
        }
        private Compania compania;

        public Compania CompaniaCelular { get
            {
                return this.compania;
            }

            set
            {
                this.compania = value;
            }
        }
        public Celular()
        {

        }

        public Celular(int codigo, string nombre, double precio, Compania compania)
            : base(codigo, nombre, precio)
        {
            this.CompaniaCelular = compania;
        }
        /// <summary>
        /// sobreescribe el metodo ToString 
        /// devuelve la informacion de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine(base.ToString());
            mensaje.AppendLine($"Este celular es {this.CompaniaCelular}");
            return mensaje.ToString();
        }
    }
}
