using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class DisciplinaInvalidaException: Exception
    {
        public DisciplinaInvalidaException() { }
        public DisciplinaInvalidaException(string mensaje) : base(mensaje) { }
        public DisciplinaInvalidaException(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}
