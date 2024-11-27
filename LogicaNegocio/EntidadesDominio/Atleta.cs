using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Atleta: IEquatable<Atleta>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public Pais Pais { get; set; }//Entidad de dominio
        public IEnumerable<Disciplina> _disciplinas { get; set; }
        public IEnumerable<Evento> _eventos { get; set; }

        public Atleta(string nombre, string apellido, string sexo, Pais pais, IEnumerable<Disciplina> disc)
        {
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            Pais = pais;
            _disciplinas = disc;
        }
        protected Atleta() //LO AGREGAMOS PARA QUE EF PUEDA CREAR OBJETOS ATLETA
        {
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new AtletaInvalidoException("El nombre es requerido");
            if (string.IsNullOrEmpty(Apellido)) throw new AtletaInvalidoException("El Apellido es requerido");
            if (string.IsNullOrEmpty(Sexo)) throw new AtletaInvalidoException("El Sexo es requerido");
            if (Pais == null) throw new AtletaInvalidoException("El país es requerido");
        }
        public int CompareTo(Atleta? other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Atleta? other)
        {
            throw new NotImplementedException();
        }
    }
}
