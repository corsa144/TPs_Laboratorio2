using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion, 
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        /// <summary>
        /// constructor
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        /// <summary>
        /// propiedades
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// indexador
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                /* return the specified index here */
                return this.jornada[i];
            }
            set
            {
                /* set the specified index to value here */
                this.jornada[i] = value;
            }
        }
        /// <summary>
        /// propiedades
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool estaIncluido = false;
            if(!ReferenceEquals(g.alumnos, null))
            {
                foreach(Alumno alumno in g.alumnos)
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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool estaIncluido = false;
            if (!ReferenceEquals(g.profesores, null))
            {
                foreach (Profesor profesor in g.profesores)
                {
                    if (profesor == i)
                    {
                        estaIncluido = true;
                        break;
                    }
                }
            }
            return estaIncluido;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor P)
        {
            if (u != P)
            {
                u.Instructores.Add(P);
            }
            return u;
        }

        public static Universidad operator +(Universidad g, EClases c)
        {
            Jornada jornada = null;
            if (!ReferenceEquals(g.Instructores, null))
            {
                foreach (Profesor profesor in g.Instructores)
                {
                    if (profesor == c)
                    {
                        jornada = new Jornada(c, profesor);
                    }
                }
                if (ReferenceEquals(jornada, null))
                {
                    throw new SinProfesorException();
                }
                g.Jornadas.Add(jornada);
            }

            return g;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            if (!ReferenceEquals(u.Jornadas, null) )
            {
                foreach(Jornada jornada in u.Jornadas)
                {
                    if(jornada.Clase == clase)
                    {
                        return jornada.Instructor;
                    }
                }
            }
            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            if (!ReferenceEquals(u.Jornadas, null))
            {
                foreach(Jornada jornada in u.Jornadas)
                {
                    if(jornada.Clase != clase)
                    {
                        return jornada.Instructor;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// metodos
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        private string MostrarDatos(Universidad u)
        {
            StringBuilder mensaje = new StringBuilder();
            if (!ReferenceEquals(u.Alumnos, null))
            {
                foreach(Alumno alu in u.Alumnos)
                {
                    mensaje.AppendLine($"Alumno: {alu.ToString()}");
                }
            }
            if (!ReferenceEquals(u.Instructores, null))
            {
                foreach (Profesor profe in u.Instructores)
                {
                    mensaje.AppendLine($"Alumno: {profe.ToString()}");
                }
            }
            if (!ReferenceEquals(u.Jornadas, null))
            {
                foreach (Jornada jor in u.Jornadas)
                {
                    mensaje.AppendLine($"Alumno: {jor.ToString()}");
                }
            }

            return mensaje.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public static bool Guardar(Universidad universidad)
        {
            Texto t = new Texto();
            return t.Guardar("Universidad", universidad.ToString());
        }

        public string Leer()
        {
            Texto t = new Texto();
            if(t.Leer("Universidad", out string datos))
            {
                return datos;
            }
            return "";

        }
    }
}
