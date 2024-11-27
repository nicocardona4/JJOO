using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class ListadoEventos: IListadoEventos
    {
        public IRepositorioEventos Repositorio { get; set; }
        public IRepositorioDisciplinas RepoDisciplinas { get; set; }

        public ListadoEventos(IRepositorioEventos repo, IRepositorioDisciplinas repoDisciplinas)
        {
            Repositorio = repo;
            RepoDisciplinas = repoDisciplinas;
        }

        public IEnumerable<ListadoEventosDTO> ObtenerListado(EventoFchDTO FechaDTO)
        {
            List<Evento> evs = new List<Evento>();
            string Fecha = FechaDTO.Fecha;
            if (!DateTime.TryParse(Fecha, out DateTime fecha))
            {
                throw new EventoInvalidoException("La fecha no se pudo ingresar.");
            }
            IEnumerable<Evento> eventos = Repositorio.FindAll();
            foreach (Evento evento in eventos)
            {
                

                if (evento.FechaInicial <= fecha && evento.FechaFinal>= fecha)
                {
                    evento.Disciplina = RepoDisciplinas.FindById(evento.DisciplinaId);
                    evs.Add(evento);
                }
            }
            return EventoMapper.FromEventos(evs);
        }
    }
}
