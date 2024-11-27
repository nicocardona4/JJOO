using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class EventoInvalidoException: Exception
    {
        public EventoInvalidoException() { }
        public EventoInvalidoException(string mensaje) : base(mensaje) { }
        public EventoInvalidoException(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}
