using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Computadora))]
    public class Computadora :Producto
    {
        public enum TipoComputadora
        {
            Escritorio,
            Notebook
        }

        public enum ESistemaOperativo
        {
            Windows,
            OSX,
            Linux,
            SinSistemaOperativo
        }
        private TipoComputadora tipo;
        private ESistemaOperativo sistemaOperativo;
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
        public ESistemaOperativo SistemaOperativo
        {
            get
            {
                return this.sistemaOperativo;
            }
            set
            {
                this.sistemaOperativo = value;
            }
        }
        public Computadora()
        {

        }

        public Computadora(int codigo, string nombre, double costo, TipoComputadora tipo, bool calidad)
            : this(codigo,nombre,costo,tipo,ESistemaOperativo.SinSistemaOperativo, calidad)
        {

        }

        public Computadora(int codigo, string nombre, double costo, TipoComputadora tipo,
            ESistemaOperativo sistema, bool controlCalidad)
            : base(codigo, nombre, costo, controlCalidad)
        {
            this.Tipo = tipo;
            this.SistemaOperativo = sistema;
        }
        /// <summary>
        /// sobreescribe el metodo ToString 
        /// </summary>
        /// <returns>devuelve la informacion de la clase</returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append("Computadora,");
            mensaje.Append(base.ToString());
            mensaje.Append($"{this.Tipo},");
            mensaje.Append($"{this.SistemaOperativo},");
            return mensaje.ToString();
        }
    }
}
