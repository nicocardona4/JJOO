using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Rol(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Validar();
        }

        protected Rol()
        {
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre) || Nombre.Trim() == "")
            {
                throw new Exception("El nombre del Rol es requerido");
            }
        }
    }
}
