using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Disciplina : IValidable, IEquatable<Disciplina>
    {
        public int Id { get; set; }
        public NombreDisciplina NombreDisciplina { get; set; }
        public Anio Anio { get; set; }
        public Codigo Codigo { get; set; }

        public IEnumerable<Atleta> _atletas { get; set; }

        public Disciplina(NombreDisciplina nombreDisciplina, Anio anio, Codigo codigo, IEnumerable<Atleta> atletas)
        {
            NombreDisciplina = nombreDisciplina;
            Anio = anio;
            Codigo = codigo;
            _atletas = atletas;
            Validar();
        }
        public Disciplina(NombreDisciplina nombreDisciplina, Anio anio, Codigo codigo)
        {
            NombreDisciplina = nombreDisciplina;
            Anio = anio;
            Codigo = codigo;
            Validar();
        }
        public Disciplina(int id) 
        {
            Id = id;
        }

        protected Disciplina() //LO AGREGAMOS PARA QUE EF PUEDA CREAR OBJETOS DISCIPLINA
        {
        }

        public void Validar()
        {
            NombreDisciplina.Validar();
            Anio.Validar();
            Codigo.Validar();
        }

        public bool Equals(Disciplina? other)
        {
            return other.Id == Id;
        }

        //public bool Equals(Usuario? other)
        //    //{
        //    //    return other.Email == Email;
        //    //}
    }
}
