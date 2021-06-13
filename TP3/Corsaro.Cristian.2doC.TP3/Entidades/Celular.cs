using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Celular))]
    public class Celular:Producto
    {
        public enum SistemaOperativo
        {
            Android,
            IOS
        }
        private SistemaOperativo sistema;

        public SistemaOperativo Sistema { get
            {
                return this.sistema;
            }

            set
            {
                this.sistema = value;
            }
        }
        public Celular()
        {

        }

        public Celular(int codigo, string nombre, double costo, SistemaOperativo compania, bool controlCalidad)
            : base(codigo, nombre, costo, controlCalidad)
        {
            this.Sistema = compania;
        }
        /// <summary>
        /// sobreescribe el metodo ToString 
        /// devuelve la informacion de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append("Celular,");
            mensaje.AppendLine(base.ToString());
            mensaje.AppendLine($"{this.Sistema},");
            return mensaje.ToString();
        }
    }
}
