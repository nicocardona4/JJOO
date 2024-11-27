using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class UsuarioInvalidoException: Exception
    {
        public UsuarioInvalidoException() { }
        public UsuarioInvalidoException(string mensaje) : base(mensaje) { }
        public UsuarioInvalidoException(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}
