using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Numero num = new Numero();

            Console.WriteLine(num.BinarioDecimal("1100"));

            Console.ReadKey();
        }
    }
}
