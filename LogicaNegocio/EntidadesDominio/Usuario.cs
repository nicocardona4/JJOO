using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObject;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.EntidadesDominio
{
    public class Usuario: IValidable
    {
        //private Email Email;
       

        public int Id { get; set; }

        public Rol Rol { get; set; } //Entidad de dominio
        public int RolId { get; set; }
        public Email Email { get; set; } //Value Object
        public Contrasenia Contrasenia { get; set; }

        public string Admin {  get; set; }

        public DateTime FechaRegistro { get; set; }

        public Usuario(Email email, Contrasenia pass, Rol rol)
        {
            Email = email;
            Contrasenia = pass;
            Rol = rol;
            Validar();
        }

        public Usuario(Email email, Contrasenia pass, int idRol, string admin, DateTime fechaRegistro)
        {
            Email = email;
            Contrasenia = pass;
            RolId = idRol;
            Admin = admin;
            FechaRegistro = fechaRegistro;
            Validar();
        }
        public Usuario(Email mail, int idRol)
        {
            this.Email = mail;
            this.RolId = idRol;
        }
        public Usuario(int id, int rolId, Email email, Contrasenia contrasenia)
        {
            Id = id;
            RolId = rolId;
            Email = email;
            Contrasenia = contrasenia;

        }

        protected Usuario() //LO AGREGAMOS PARA QUE EF PUEDA CREAR OBJETOS USUARIO
        {
        }


        public void Validar()
        {
            if (Email == null) throw new UsuarioInvalidoException("El email es obligatorio");
            if (Contrasenia == null) throw new UsuarioInvalidoException("La contraseña es obligatoria");
        }



        

        //public bool Equals(Usuario? other)
        //{
        //    return other != null && string.Equals(other.Email, this.Email, StringComparison.OrdinalIgnoreCase);
        //    // StringComparison.OrdinalIgnoreCase HACE UNA COMPARACION DE CADENAS SIN IMPORTAR MAY Y MIN, PORQUE LOS EMAILS NO SON CASE SENSITIVES
        //    //SI NO CONVENCE, DEJAR ASI:
        //    //public bool Equals(Usuario? other)
        //    //{
        //    //    return other.Email == Email;
        //    //}
        //}
    }
}
