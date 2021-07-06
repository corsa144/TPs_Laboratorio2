using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;

namespace PruebaConsola
{
    class Test
    {
        static void Main(string[] args)
        {

            //List<Producto> prod = new List<Producto>();
            try
            {
                Celular celular2 = new Celular(1, "Mot(orola", 20000, 0, true);
                Computadora computadora2 = new Computadora(2, "Lenovo", 40000, 0, Computadora.ESistemaOperativo.Linux, false);
                Fabrica fabrica2 = new Fabrica(1000);
                fabrica2.Productos.Add(celular2);
                fabrica2.Productos.Add(computadora2);
            }catch(NombreProductoExeption ex)
            {
                Console.WriteLine("{0}",ex.Message);
            }
            Celular celular = new Celular(1, "Motorola", 20000, 0, true);
            Computadora computadora = new Computadora(2, "Lenovo", 40000, 0, Computadora.ESistemaOperativo.Linux, false);
            Fabrica fabrica = new Fabrica(1000);
            fabrica.Productos.Add(celular);
            fabrica.Productos.Add(computadora);
            Console.WriteLine(celular.ToString());
            Console.WriteLine(computadora.ToString());
            Console.WriteLine(fabrica.ToString());
            Console.ReadKey();
            //fabrica.Guardar(fabrica);
            //fabrica.Leer("Fabrica.txt",fabrica.ToString());

            foreach(Producto p in fabrica.Productos)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine(fabrica.MostrarProductos()); 
            Console.ReadKey();
        }
    }
}
