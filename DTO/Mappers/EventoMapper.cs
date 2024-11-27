using LogicaNegocio.EntidadesDominio;
using DTO;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesPropias;

namespace DTO.Mappers
{
    public class EventoMapper
    {
        public static EventoDeMapperACUDTO FromDTO(AltaEventoDTO dto)
        {
            if (dto != null)
            {
                Disciplina disciplina = new Disciplina(dto.DisciplinaId);
                string NombrePrueba = new string(dto.NombrePrueba);
                if (!DateTime.TryParse(dto.FechaInicial, out DateTime fechaInicial))
                {
                    throw new EventoInvalidoException("La fecha inicial no tiene un formato válido.");
                }

                if (!DateTime.TryParse(dto.FechaFinal, out DateTime fechaFinal))
                {
                    throw new EventoInvalidoException("La fecha final no tiene un formato válido.");
                }

                if (fechaInicial > fechaFinal)
                {
                    throw new EventoInvalidoException("La fecha inicial no puede ser posterior a la fecha final.");
                }
                if (fechaInicial < DateTime.Today || fechaFinal < DateTime.Today)
                {
                    throw new EventoInvalidoException("Los eventos deben ser programados antes de empezar.");
                }
                IEnumerable<int> atletas = dto.IdAtletas;
                Evento eve = new Evento(disciplina, NombrePrueba, fechaInicial, fechaFinal);
                EventoDeMapperACUDTO even = new EventoDeMapperACUDTO
                {
                    evento = eve,
                    idAtletas = atletas
                };
                return even;
            }
            else
            {
                throw new Exception("Ocurrió un error al enviar los datos");
            }
        }

        public static ListadoEventosDTO FromEvento(Evento e)
        {
            string FechaI = e.FechaInicial.ToShortDateString();
            string FechaF = e.FechaFinal.ToShortDateString();
            ListadoEventosDTO dto = new ListadoEventosDTO
            {
                DisciplinaId = e.DisciplinaId,
                FechaInicial = FechaI,
                FechaFinal = FechaF,
                NombrePrueba = e.NombrePrueba,
                IdAtletas = e.Atletas.Select(a=>a.Id).ToList(),
                Disciplina = e.Disciplina.NombreDisciplina.Valor
            };

            return dto;
        }
        public static IEnumerable<ListadoEventosDTO> FromEventos(IEnumerable<Evento> eventos)
        {
            List<ListadoEventosDTO> dtos = new List<ListadoEventosDTO>();

            foreach (Evento eve in eventos)
            {
                dtos.Add(FromEvento(eve));
            }

            return dtos;
        }
        public static Evento fromAltaEvento(EventoDeMapperACUDTO dto)
        {
            Evento e = new Evento(dto.evento.Disciplina.Id, dto.evento.NombrePrueba, dto.evento.FechaInicial, dto.evento.FechaFinal);
            e.Atletas = dto.evento.Atletas;
            return e;

        }


    }
}
