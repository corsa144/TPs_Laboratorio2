using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AplicacionDeConsola
{
    class AplicacionDeConsola
    {
        static void Main(string[] args)
        {
            Numero num = new Numero();
            Numero num2 = new Numero(13);
            Console.WriteLine(num.BinarioDecimal("1100"));
            Console.WriteLine("Este es el numero 2: {0}",num2.DecimalBinario(13));

            Console.ReadKey();
        }
    }
}
