using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
            : this()
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
            : this()
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// comprueba que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero">un string que deberia contener un valor numerico</param>
        /// <returns>0 en caso de que no sea numerico y un double en caso de que si sea un valor numerico</returns>
        private double ValidarNumero(string strNumero)
        {
            double numeroValidado;
            if (double.TryParse(strNumero, out numeroValidado))
            {
                return numeroValidado;
            }

            return 0;
        }
        /// <summary>
        /// valida que el string este compuesto solo de 0 y 1
        /// </summary>
        /// <param name="binario">recibe un string</param>
        /// <returns>retorna verdadero si son solo 0 y 1 caso contrario retorna falso</returns>
        private bool EsBinario(string binario)
        {
            bool EsBinario = true;
            char[] charArray = binario.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] != '0' && charArray[i] != '1')
                {
                    EsBinario = false;
                    break;
                }
            }

            return EsBinario;
        }
        /// <summary>
        /// convierte un numero decimal a binario
        /// </summary>
        /// <param name="numeroDecimal">recibe un numero decimal</param>
        /// <returns>retorna un numero binario en caso de que se pueda sino un mensaje de error</returns>
        public string DecimalBinario(double numeroDecimal)
        {
            int numeroAux;
            numeroAux = (int)numeroDecimal * 2;
            string binarioAux = "";
            if (numeroDecimal >= 0)
            {
                do
                {
                    numeroAux = numeroAux / 2;
                    if (numeroAux % 2 == 0)
                    {
                        binarioAux = "0" + binarioAux;
                    }
                    if (numeroAux % 2 == 1)
                    {
                        binarioAux = "1" + binarioAux;
                    }

                } while (numeroAux > 1);
            }
            else
            {
                binarioAux = "Valor invalido!";
            }


            return binarioAux;
        }
        /// <summary>
        /// convierte de numero binario a decimal
        /// </summary>
        /// <param name="numeroBinario">recibe un string que representa el numero binario</param>
        /// <returns>devuelve un string con el numero en caso de exito o con un mensaje de error</returns>
        public string BinarioDecimal(string numeroBinario)
        {

            ulong enteroAux;
            ulong numeroDecimal = 0;
            ulong multiplicador = 1;
            char[] caracterActual;

            if (!(EsBinario(numeroBinario)) || !(ulong.TryParse(numeroBinario, out enteroAux)))
            {
                return "Valor invalido!";
            }
            caracterActual = numeroBinario.ToCharArray();

            for (int i = caracterActual.Length - 1; i >= 0; i--)
            {
                if (caracterActual[i] == '1')
                {
                    numeroDecimal += multiplicador;
                }
                multiplicador = multiplicador * 2;

            }
            return numeroDecimal.ToString();

        }

        public string DecimalBinario(string numeroDecimal)
        {
            double numeroDecimalAux = 0;
            double.TryParse(numeroDecimal, out numeroDecimalAux);

            return DecimalBinario(numeroDecimalAux);
        }

        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero + numeroDos.numero;
        }
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero - numeroDos.numero;
        }
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            if (numeroDos.numero == 0)
            {
                return double.MinValue;
            }
            return numeroUno.numero / numeroDos.numero;
        }
        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero * numeroDos.numero;
        }


    }
}
