using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace PruebaConsola
{
    class Test
    {
        static void Main(string[] args)
        {
            Celular celular = new Celular(1,"Motorola",20000,0);
            Computadora computadora = new Computadora(2,"Lenovo",40000,0);
            Venta venta = new Venta("Cristian", 2);
            List<Producto> prod = new List<Producto>();
            venta.Productos.Add(celular);
            venta.Productos.Add(computadora);
            foreach (Producto p in venta.Productos)
            {
                prod.Add(p);
            }
            Console.WriteLine(celular.ToString());
            Console.WriteLine(computadora.ToString());
            Console.WriteLine(venta.ToString());
            Console.ReadKey();
            venta.Guardar(venta);
            venta.Leer("Venta.txt",venta.ToString());

            foreach(Producto p in prod)
            {
                Console.WriteLine(p.ToString());
            }
            Console.ReadKey();
        }
    }
}
