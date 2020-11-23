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
            Producto producto = new Producto(1, "Motorola", 20000, 0);
            Venta venta = new Venta("Cristian", 0, producto,1);
            Console.WriteLine(producto.ToString());
            Console.WriteLine(venta.ToString());
            Console.ReadKey();
            venta.Guardar(venta);
            List<Venta> ventas = venta.Leer("Venta.txt");
            foreach(Venta v in ventas)
            {
                Console.WriteLine(v.ToString());
            }
            Console.ReadKey();
        }
    }
}
