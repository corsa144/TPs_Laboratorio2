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
        private string SetNumero {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
            :this()
        {
            this.numero = numero;
        }

        public Numero( string strNumero)
            :this()
        {
            this.SetNumero = strNumero;
        }
        private double ValidarNumero(string strNumero)
        {
            double numeroValidado;
            if(double.TryParse(strNumero, out numeroValidado))
            {
                return numeroValidado;
            }

            return 0;
        }

  
        public string DecimalBinario(double numeroDecimal)
        {
            int numeroAux;
            numeroAux = (int)numeroDecimal * 2;
            string binarioAux = "";
            if(numeroDecimal >= 0)
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

        public string BinarioDecimal(string numeroBinario)
        {

            ulong enteroAux;
            ulong numeroDecimal = 0;
            ulong multiplicador = 1;
            char[] caracterActual;

            if (!(ulong.TryParse(numeroBinario,out enteroAux)))
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

        public static double operator +(Numero numeroUno,Numero numeroDos)
        {
            return numeroUno.numero + numeroDos.numero;
        }
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero - numeroDos.numero;
        }
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            if(numeroDos.numero == 0)
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
