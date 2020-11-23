using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class Auxiliar
    {
        public static bool EsUnNombreValido(string nombre)
        {
            bool esValido = true;
            char[] cadena = nombre.ToCharArray();
            for(int i=0;i< cadena.Length; i++)
            {
                if(cadena[i] < 'a' || cadena[i] >'z' && cadena[i] < 'A' || cadena[i] > 'Z')
                {
                    esValido = false;
                    break;
                }
            }
            return esValido;
        }
    }
}
