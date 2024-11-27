using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.ValueObjects
{
    //ESTA CLASE EMAIL ES UN VALUE OBJECT
    [Owned]
    public class Email : IEquatable<Email>
    {
        //NO TIENE UN IDENTIFICADOR, TIENE UN VALOR (PUEDEN SER VARIOS ATRIBUTOS)
        public string Valor { get; private set; } //ES INMUTABLE

        public Email(string correo) //SOLAMENTE PUEDO SETEAR EL VALOR AL CONSTRUIRLO
        {
            Valor = correo;
            Validar(); //SE AUTOVALIDA
        }

        protected Email() //PARA EF
        {
        }

        private void Validar()
        {
            if (!SonArrobaYPuntosCorrectos())
            {
                throw new UsuarioInvalidoException("Ingrese un email con formato correcto");
            }

        }
        private bool SonArrobaYPuntosCorrectos()
        {
            int contadorArroba = 0;
            int contadorPuntos = 0;
            int ultimaPosicionArroba = -1;

            foreach (char c in this.Valor)
            {
                if (c == '@')
                {
                    contadorArroba++;
                    ultimaPosicionArroba = this.Valor.IndexOf('@');
                }
                else if (c == '.')
                {
                    contadorPuntos++;
                }
            }
            if (contadorArroba == 1 && contadorPuntos >= 1 && ultimaPosicionArroba < this.Valor.LastIndexOf('.'))
            {
                return true;
            }
            return false;
        }

        public bool Equals(Email? other)
        {
            if (other != null)
            {
                return this.Valor == other.Valor; //COMPARA ESTADO PORQUE NO TIENE IDENTIDAD
            }

            return false;
        }
    }
}
