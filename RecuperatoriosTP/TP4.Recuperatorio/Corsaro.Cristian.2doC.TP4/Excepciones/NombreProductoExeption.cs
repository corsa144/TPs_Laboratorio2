using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NombreProductoExeption : Exception
    {
        public NombreProductoExeption(string mensaje) : base(mensaje)
        {

        }

        public NombreProductoExeption(string mensaje, Exception innerException) : base(mensaje, innerException)
        {

        }

    }
}
