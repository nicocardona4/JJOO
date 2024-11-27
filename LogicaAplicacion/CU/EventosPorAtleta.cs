using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class EventosPorAtleta : IBuscarEventosPorAtleta
    {
        public IRepositorioAtletas Repo { get; set; }

        public EventosPorAtleta(IRepositorioAtletas repo)
        {
            Repo = repo;
        }
        public IEnumerable<ListadoEventosDTO> Buscar(int id)
        {
            var a = Repo.FindById(id);
            
                if (a == null)
                {
                throw new AtletaInvalidoException("No se encontró atleta con este Id");
                }
            
            IEnumerable <ListadoEventosDTO> eves = EventoMapper.FromEventos(a._eventos);
            if (eves == null || eves.Count() == 0)
            {
                throw new AtletaInvalidoException("No se encontraron eventos para el atleta");

            }
            return eves.OrderBy(e=> e.Disciplina);
        }
    }
}
