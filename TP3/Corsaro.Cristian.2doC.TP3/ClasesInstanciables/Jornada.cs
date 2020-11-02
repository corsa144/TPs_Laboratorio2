using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;


namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clases;
        private Profesor instructor;
        /// <summary>
        /// constructores
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.clases = clase;
            this.instructor = instructor;
        }
        /// <summary>
        /// propiedades
        /// </summary>
        public List<Alumno> Alumnos { get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clases;
            }

            set
            {
                this.clases = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool estaIncluido = false;
            if (!ReferenceEquals(j.Alumnos, null))
            {
                foreach(Alumno alumno in j.Alumnos)
                {
                    if(alumno == a)
                    {
                        estaIncluido = true;
                        break;
                    }
                }
            }
            return estaIncluido;
        }
        /// <summary>
        /// operadores
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }
        /// <summary>
        /// metodos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            if (!ReferenceEquals(this.Alumnos, null))
            {
                foreach(Alumno alumno in this.Alumnos)
                {
                    mensaje.AppendLine($"Alumno: {alumno.Apellido}");
                }
            }
            mensaje.AppendLine($"Clases: {this.Clase}");
            mensaje.AppendLine($"Profesor: {this.instructor}");
            return mensaje.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            return t.Guardar("Jornada", jornada.ToString());
        }

        public string Leer()
        {
            Texto t = new Texto();
            if (t.Leer("Jornada", out string datos))
            {
                return datos;
            }
            return "";
        }
    }
}
