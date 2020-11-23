using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        /// <summary>
        /// constructores
        /// </summary>
        public Universitario()
            :this(0,"","","",ENacionalidad.Argentino)
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// metodos
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine(base.ToString());
            mensaje.AppendLine($"Legajo: {this.legajo}");
            return mensaje.ToString();
        }

        public override bool Equals(object obj)
        {
            bool sonIguales = false;
            if(obj is Universitario)
            {
                sonIguales = true;
            }
            return sonIguales;
        }
        /// <summary>
        /// operadores
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool sonIguales = false;
            if((pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI) && pg1.Equals(pg2))
            {
                sonIguales = true;
            }
            return sonIguales;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

    }
}
