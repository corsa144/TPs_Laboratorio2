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
    [Serializable]
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
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
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
                return this.Jornadas[i];
            }
            set
            {
                /* set the specified index to value here */
                this.Jornadas[i] = value;
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
            if(!ReferenceEquals(g, null))
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
            if (!ReferenceEquals(g, null))
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

        public static Universidad operator +(Universidad g, Universidad.EClases c)
        {
            Profesor profesorAgregar = g == c;
            Jornada jornadaAgregar = new Jornada(c, profesorAgregar);
            //g.Jornadas[g.Jornadas.Count];
            List<Alumno> alumnosParaLaClase = new List<Alumno>();

            //Agrega aquellos alumnos de la Universidad que Tomen la clase que se quiere agregar.
            foreach (Alumno alumnoEnUniversidad in g.Alumnos)
            {
                if (alumnoEnUniversidad.ClasesQueToma == c)
                {
                    alumnosParaLaClase.Add(alumnoEnUniversidad);
                }
            }

            jornadaAgregar.Alumnos = alumnosParaLaClase;
            g.Jornadas.Add(jornadaAgregar);
            jornadaAgregar = g[0];

            return g;
        }

        public static Profesor operator ==(Universidad u, Universidad.EClases clase)
        {
            if (!ReferenceEquals(u, null) )
            {
                foreach (Profesor profesor in u.Instructores)
                {
                    if (profesor == clase)
                    {
                        return profesor;
                    }
                }
            }
            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad u, Universidad.EClases clase)
        {
            if (!ReferenceEquals(u, null))
            {
                foreach(Profesor profesor in u.Instructores)
                {
                    if(profesor != clase)
                    {
                        return profesor;
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
            mensaje.AppendLine("JORNADA: ");
            foreach (Jornada jornada in u.Jornadas)
            {
                mensaje.AppendLine(jornada.ToString());
            }
            return mensaje.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public static bool Guardar(Universidad universidad)
        {
            string ruta = Directory.GetCurrentDirectory() + @"\Universidad.xml";
            Xml<Universidad> universidadXml = new Xml<Universidad>();

            if (universidadXml.Guardar(ruta, universidad))
            {
                return true;
            }

            return false;
        }

        public Universidad Leer()
        {
            string ruta = Directory.GetCurrentDirectory() + @"\Universidad.xml";
            Universidad universidad = new Universidad();
            Xml<Universidad> archivoXml = new Xml<Universidad>();
            archivoXml.Leer(ruta, out universidad);

            return universidad;

        }
    }
}
