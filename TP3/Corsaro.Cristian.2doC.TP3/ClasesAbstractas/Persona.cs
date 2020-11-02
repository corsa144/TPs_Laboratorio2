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
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,dni.ToString(),nacionalidad)
        {

        }

        public Persona(string nombre, string apellido,string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            int.TryParse(dni, out int dniNumerico);
            this.dni = dniNumerico;
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
                if (Auxiliar.EsUnNombreValido(value))
                {
                    this.apellido = value;
                }

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
                if(this.nacionalidad == ENacionalidad.Argentino)
                {
                    if(value >= 1 && value <= 89999999)
                    {
                        this.dni = value;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("DNI argentino invalido");
                    }
                }
                else 
                {
                    if(value >= 90000000 && value <= 99999999)
                    {
                        this.dni = value;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("DNI extranjero invalido");
                    }
                }
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
                this.nombre = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                if(value.Length == 8)
                {
                    Char[] arrChar = value.ToArray();
                    foreach(Char c in arrChar)
                    {
                        if(!Char.IsDigit(c))
                        {
                            throw new DNIInvalidoExcepcion();
                        }
                    }

                    int.TryParse(value, out int dniNumerico);
                    this.DNI = dniNumerico;
                }
                else
                {
                    throw new DNIInvalidoExcepcion();
                }
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
    }
}
