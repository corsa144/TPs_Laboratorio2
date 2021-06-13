using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivos<T>
    {
        bool Guardar(string archivos, List<T> datos);
        bool Leer(string archivos, out List<T> datos);
    }
}
