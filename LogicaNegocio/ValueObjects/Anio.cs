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
    public class Anio
    { 
        public int Valor { get; private set; }

        public Anio(int valor) //SOLAMENTE PUEDO SETEAR EL VALOR AL CONSTRUIRLO
        {
            Valor = valor;
        }

        protected Anio() //PARA EF
        {
        }

        public void Validar()
        {
            if (Valor == 0 || Valor < 1800 || Valor > 2024) throw new DisciplinaInvalidaException("Ingrese un año válido");
        }
    }
}
