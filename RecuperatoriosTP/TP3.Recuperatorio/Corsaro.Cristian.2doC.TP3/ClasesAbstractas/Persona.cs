using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        /// <summary>
        /// constructores
        /// </summary>
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,dni.ToString(),nacionalidad)
        {

        }

        public Persona(string nombre, string apellido,string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        /// <summary>
        /// propiedades
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = Persona.ValidarNombreApellido(value);

            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = Persona.ValidarDNI(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = Persona.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDNI(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// muestra los datos de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder mensaje = new StringBuilder();
            mensaje.AppendLine($"Nombre: {this.Nombre}");
            mensaje.AppendLine($"Apellido: {this.Apellido}");
            mensaje.AppendLine($"DNI: {this.DNI}");
            mensaje.AppendLine($"Nacionalidad: {this.Nacionalidad}");
            return mensaje.ToString();
        }


        /// <summary>
        /// Metodo privado estatico que valida que el numero de DNI proporcionado se encuentre dentro del rango admitido para la nacionalidad de la Persona.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {

            if (nacionalidad == Persona.ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("El numero de DNI no corresponde a una persona argentina");
                }
                
            }
            else
            {
                if (dato >= 90000000 && dato <= 99999999)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("El numero de DNI no corresponde a una persona extranjera");
                }
              
            }
        }

        /// <summary>
        /// Comprueba que el String dato sea un numero, de no poder lanza la Exception DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Length == 8)
            {
                Char[] arrChar = dato.ToArray();
                foreach (Char c in arrChar)
                {
                    if (!Char.IsDigit(c))
                    {
                        throw new DNIInvalidoExcepcion();
                    }
                }

                int.TryParse(dato, out int dniNumerico);
                return dniNumerico;
            }
            else
            {
                throw new DNIInvalidoExcepcion();
            }
        }

        /// <summary>
        /// Comprueba que el texto recibido sean solo letras. 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato)
        {
            bool esValido = true;
            char[] cadena = dato.ToCharArray();
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] < 'a' && cadena[i] > 'z' || cadena[i] < 'A' && cadena[i] > 'Z')
                {
                    esValido = false;
                    break;
                }
            }
            if (esValido)
            {
                return dato;
            }

            return string.Empty;
        }
    }
}
