using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivos<T>
    {
        bool Guardar(string archivos, T datos);
        bool Leer(string archivos, out T datos);
    }
}
