using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionCosto
    {
        /// <summary>
        /// Convierte el valor indicado en un formato moneda.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string FormatearCosto(this Double valor)
        {
            return String.Format("${0:0.00}", valor);
        }
    }
}
