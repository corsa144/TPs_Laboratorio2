using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// realiza las operaciones de la calculadora
        /// </summary>
        /// <param name="numeroUno">recibe un numero</param>
        /// <param name="numeroDos">recibe un numero</param>
        /// <param name="operador">recibe un string que representara el operador</param>
        /// <returns>devuelve el resultado</returns>
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
        /// <summary>
        /// valida que el operador de la claculadora sea valido
        /// </summary>
        /// <param name="operador">recibe el operador a validar</param>
        /// <returns>devuelve el operador validado</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }
            return operador;
        }
        #endregion
    }
}
