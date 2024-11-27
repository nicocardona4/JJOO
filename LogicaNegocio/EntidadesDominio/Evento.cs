using ExcepcionesPropias;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Evento: IEquatable<Evento>, IValidable
    {
        public Disciplina Disciplina { get; set; }
        
        public int DisciplinaId { get; set; }
        [Key]
        public string NombrePrueba { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public IEnumerable<Atleta> Atletas { get; set; }
        public IEnumerable<Participaciones> Participaciones { get; set; }

        public Evento(Disciplina disciplina,string nombrePrueba, DateTime fechaInicial, DateTime fechaFinal)
        {
            Disciplina = disciplina;
            NombrePrueba = nombrePrueba;
            FechaInicial = fechaInicial;
            FechaFinal = fechaFinal;
        }
        public Evento(int disciplinaId, string nombrePrueba, DateTime fechaInicial, DateTime fechaFinal)
        {
            DisciplinaId = disciplinaId;
            NombrePrueba = nombrePrueba;
            FechaInicial = fechaInicial;
            FechaFinal = fechaFinal;
        }
        protected Evento() //LO AGREGAMOS PARA QUE EF PUEDA CREAR OBJETOS EVENTO
        {
        }
        public bool Equals(Evento? other)
        {
            throw new NotImplementedException();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NombrePrueba)) throw new EventoInvalidoException("El nombre es obligatorio");
            if (FechaFinal == null) throw new EventoInvalidoException("La fecha no puede ser nula");
            if (FechaInicial == null) throw new EventoInvalidoException("La fecha no puede ser nula");
        }
    }
}
