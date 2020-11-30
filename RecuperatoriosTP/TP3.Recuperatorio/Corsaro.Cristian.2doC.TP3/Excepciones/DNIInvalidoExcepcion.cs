using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DNIInvalidoExcepcion:Exception
    {
        public DNIInvalidoExcepcion():base()
        {

        }

        public DNIInvalidoExcepcion(Exception e) : base("", e)
        {

        }
        public DNIInvalidoExcepcion(string message):base(message)
        {

        }
        public DNIInvalidoExcepcion(string message, Exception e): base(message, e)
        {

        }
    }
}
