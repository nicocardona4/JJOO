using ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    [Owned]
    public class Contrasenia: IEquatable<Contrasenia>
    {
        public string Valor {  get; private set; }

        public Contrasenia(string pass)
        {
            Valor = pass;
            Validar();
        }
        protected Contrasenia() { }

        private void Validar()
        {
            //VALIDAR PARTE CONTRASENIA
            if (Valor == null) throw new UsuarioInvalidoException("La contraseña es obligatoria.");

            if (!ValidarContraseña(Valor))
            {
                throw new UsuarioInvalidoException("La contraseña no cumple con los requisitos obligatorios.");
            }
        }
        private static bool ValidarContraseña(string contraseña)
        {
            if (contraseña.Length < 6)
            {
                return false;
            }

            bool contieneMinuscula = contraseña.Any(char.IsLower);
            bool contieneMayuscula = contraseña.Any(char.IsUpper);
            bool contieneDigito = contraseña.Any(char.IsDigit);
            bool contienePuntuacion = contraseña.Any(c => char.IsPunctuation(c) && c != ' ');

            return contieneMinuscula && contieneMayuscula && contieneDigito && contienePuntuacion;
        }

        public bool Equals(Contrasenia? other)
        {
           if (other != null)
            {
                return Valor.Equals(other.Valor);
            }
           return false;
        }
    }
}