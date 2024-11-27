using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.CU
{
    public class BuscarEventoPorNombre : IBuscarEventoPorNombre
    {
        public IRepositorioEventos Repo { get; set; }
        public IRepositorioDisciplinas RepoDisciplinas { get; set; }

        public BuscarEventoPorNombre(IRepositorioEventos repo, IRepositorioDisciplinas repoDisciplnas)
        {
            Repo = repo;
            RepoDisciplinas = repoDisciplnas;
        }

        public ListadoEventosDTO Buscar(string nombre)
        {
            IEnumerable<Evento> eventos = Repo.FindAll();

            foreach (Evento e in eventos)
            {
                if (e.NombrePrueba == nombre)
                {
                    e.Disciplina = RepoDisciplinas.FindById(e.DisciplinaId);
                    return EventoMapper.FromEvento(e);
                }
            }

            // Si no se encuentra el evento, retorna null o un objeto por defecto
            return null;
        }


    }

}



