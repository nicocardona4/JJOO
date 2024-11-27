using ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class Codigo : IEquatable<Codigo>
    {
        public int Valor { get; private set; }

        public Codigo(int valor) //SOLAMENTE PUEDO SETEAR EL VALOR AL CONSTRUIRLO
        {
            Valor = valor;
        }

        protected Codigo() //PARA EF
        {
        }
        public bool Equals(Codigo? other)
        {
            return other.Valor == Valor;
        }

        public void Validar()
        {
            if (Valor == null || Valor == 0)
            {
                throw new DisciplinaInvalidaException("El código de disciplina no es válido");
            }
        }
    }
}
