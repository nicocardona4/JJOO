using DTO;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using DTO.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.InterfacesCU;
using ExcepcionesPropias;

namespace LogicaAplicacion.CU
{
    public class AltaEvento: IAltaEvento
    {
        public IRepositorioEventos RepositorioEventos { get; set; }
        public IRepositorioAtletas RepositorioAtletas { get; set; }

        public IRepositorioDisciplinas RepositorioDisciplinas {get; set; }

        public AltaEvento(IRepositorioEventos repoEventos, IRepositorioAtletas repoAtletas, IRepositorioDisciplinas repositorioDisciplinas)
        {
            RepositorioEventos = repoEventos;
            RepositorioAtletas = repoAtletas;
            RepositorioDisciplinas = repositorioDisciplinas;
        }

        public void Alta(AltaEventoDTO dto, IEnumerable<int> idAtletas)
        {
            List<Atleta> atletas = new List<Atleta>();
            EventoDeMapperACUDTO eve = EventoMapper.FromDTO(dto);
            if (eve != null)
            {
                bool sinDisciplina = false;
                var idDis = eve.evento.Disciplina.Id;
                var lista = eve.idAtletas.ToList();
                foreach (var id in lista)
                {
                    Atleta atleta = RepositorioAtletas.FindById(id);//BUSCO ATLETA 
                    foreach (var i in atleta._disciplinas)// RECORRO SUS DISCIPLINAS
                    {
                        if (i.Id == idDis)// SI UNA ES IGUAL YA ENTRA
                        {
                            sinDisciplina = true;
                        }
                    }
                    if (!sinDisciplina) { throw new EventoInvalidoException("Los atletas no están inscriptos en la disciplina"); }
                    if (atleta != null) atletas.Add(atleta);//AGREGO ATLETA
                    sinDisciplina = false ;//VUELVE A FALSE PARA EL SIGUIENTE ATLETA
                }
                if (atletas.Count < 3) 
                {
                    throw new EventoInvalidoException("Debe ingresar al menos 3 atletas al evento");
                }
                eve.evento.Atletas = atletas;
                Evento e = EventoMapper.fromAltaEvento(eve);
                var nombre = RepositorioEventos.BuscarPorNombre(eve.evento.NombrePrueba);
                if (nombre == null)
                {
                    RepositorioEventos.Add(e);
                }
                else
                {
                    throw new EventoInvalidoException("Ya existe un evento con ese nombre de prueba");
                }
            }
        }
    }
}
