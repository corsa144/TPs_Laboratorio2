using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(string mensaje) : base(mensaje)
        {

        }

        public ArchivosException(string mensaje, Exception innerException) 
            : base(mensaje, innerException)
        {

        }
    }
}
