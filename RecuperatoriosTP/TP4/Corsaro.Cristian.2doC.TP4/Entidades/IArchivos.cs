using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IArchivos<T>
    {
        void Guardar(string nombreArchivo, T datos);
        bool Leer(string nombreArchivo, out T datos);
    }
}
