using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Threading;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        /// <summary>
        /// constructores
        /// </summary>
        static Profesor()
        {
            random = new Random();

        }

        private Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        /// <summary>
        /// metodos
        /// </summary>
        private void _randomClases()
        {
            Array values = Enum.GetValues(typeof(Universidad.EClases));

            Universidad.EClases clase = (Universidad.EClases)values.GetValue(random.Next(values.Length));
            Thread.Sleep(500);
            this.clasesDelDia.Enqueue(clase);
        }

        protected override string MostrarDatos()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine(base.MostrarDatos());
            mensaje.AppendLine($"{this.ParticiparEnClase()}");
            return mensaje.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendFormat("CLASES DEL DÍA: \n");
            if (!ReferenceEquals(this.clasesDelDia, null))
            {
                foreach (Universidad.EClases clase in this.clasesDelDia)
                {
                    mensaje.AppendLine($"Clases del dia: {clase}");
                }
            }
            return mensaje.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// operadores
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool estaIncluida = false;
            if (!ReferenceEquals(i, null))
            {
                foreach(Universidad.EClases eClase in i.clasesDelDia)
                {
                    if (eClase == clase)
                    {
                        estaIncluida = true;
                    }
                }
            }

            return estaIncluida;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
