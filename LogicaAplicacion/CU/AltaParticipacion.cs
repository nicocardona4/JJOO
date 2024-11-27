using DTO;
using DTO.Mappers;
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
    public class AltaParticipacion : IAltaParticipacion
    {
        public IRepositorioParticipaciones Repo { get; set; }
        public IRepositorioDisciplinas RepoDisciplinas { get; set; }
        public IRepositorioEventos RepositorioEventos { get; set; }

        public AltaParticipacion(IRepositorioParticipaciones repo, IRepositorioDisciplinas repoDisciplinas, IRepositorioEventos repositorioEventos)
        {
            Repo = repo;
            RepoDisciplinas = repoDisciplinas;
            RepositorioEventos = repositorioEventos;
        }
        public void Alta(ParticipacionDTO dTO)
        {
            Evento e = RepositorioEventos.BuscarPorNombre(dTO.nombrePrueba);
            Disciplina d = RepoDisciplinas.FindById(e.DisciplinaId);
            if (d != null)
            {
                foreach (Atleta a in d._atletas)
                {
                    if (dTO.idAtleta == a.Id)
                    {
                        Repo.Add(ParticipacionesMapper.FromDTO(dTO));
                        
                    }
                }
            }
        }
    }
}
