using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    resultado = numeroUno + numeroDos;
                    break;
                case "-":
                    resultado = numeroUno - numeroDos;
                    break;
                case "*":
                    resultado = numeroUno * numeroDos;
                    break;
                case "/":
                    resultado = numeroUno / numeroDos;
                    break;
            }
            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            if( operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }
            return operador;
        }
    }
}
