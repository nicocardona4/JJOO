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
    public class ListadoDisciplinas : IListadoDisciplinas
    {
        public IRepositorioDisciplinas Repo { get; set; }

        public ListadoDisciplinas(IRepositorioDisciplinas repo)
        {
            Repo = repo;
        }

        public IEnumerable<ListadoDisciplinasDTO> ObtenerListado()
        {
            IEnumerable<Disciplina> disciplinas = Repo.FindAll();
            return DisciplinaMapper.FromDisciplinas(disciplinas);
        }

    }
}
