using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Computadora :Producto
    {
        public enum TipoComputadora
        {
            Escritorio,
            Notebook
        }
        private TipoComputadora tipo;

        public TipoComputadora Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }

        public Computadora()
        {

        }

        public Computadora(int codigo, string nombre, double precio, TipoComputadora tipo)
            : base(codigo,nombre,precio)
        {
            this.Tipo = tipo;
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
            mensaje.AppendLine($"Esta computadora es de tipo{this.Tipo}");
            return mensaje.ToString();
        }
    }
}
