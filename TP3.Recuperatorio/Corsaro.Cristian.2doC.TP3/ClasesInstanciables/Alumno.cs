using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;
        /// <summary>
        /// constructores
        /// </summary>
        public Alumno()
        {

        }


        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni,ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido, dni, nacionalidad,claseQueToma)
        {

            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// metodos
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine(base.MostrarDatos());
            mensaje.AppendLine(this.ParticiparEnClase());
            mensaje.AppendLine($"Estado cuenta: {this.estadoCuenta}");
            return mensaje.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine($"TOMA CLASE DE {this.clasesQueToma}");
            return mensaje.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// operadores
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool noPertenece = true;
            if(a.clasesQueToma == clase)
            {
                noPertenece = false;
            }
            return noPertenece;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool pertenece = false;
            if(!(a != clase) && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                pertenece = true;
            }
            return pertenece;
        }
    }
}
