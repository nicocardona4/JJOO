using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class AtletaInvalidoException: Exception
    {
        public AtletaInvalidoException() { }
        public AtletaInvalidoException(string mensaje) : base(mensaje) { }
        public AtletaInvalidoException(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}
