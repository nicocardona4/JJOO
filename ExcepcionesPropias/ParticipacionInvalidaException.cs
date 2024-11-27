using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class ParticipacionInvalidaException: Exception
    {
        public ParticipacionInvalidaException() { }
        public ParticipacionInvalidaException(string mensaje) : base(mensaje) { }
        public ParticipacionInvalidaException(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}
