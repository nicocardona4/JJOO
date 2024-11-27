using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Participaciones
    {
        public int Id { get; set; }

        public int AtletaId { get; set; }
        public Atleta Atleta { get; set; }

        public string EventoId { get; set; }
        public Evento Evento { get; set; }

        public decimal Puntuacion { get; set; }
        public Participaciones(int atletaId, string eventoId, decimal puntuacion)
        {
            AtletaId = atletaId;
            EventoId = eventoId;
            Puntuacion = puntuacion;
        }
        public void Validar()
        {
            if (Puntuacion <= 0) throw new ParticipacionInvalidaException("Ingrese una puntuación válida");
            if (AtletaId <= 0) throw new ParticipacionInvalidaException("Atleta inválido");
            if (string.IsNullOrEmpty(EventoId)) throw new ParticipacionInvalidaException("Evento inválido");

        }
    }

}
