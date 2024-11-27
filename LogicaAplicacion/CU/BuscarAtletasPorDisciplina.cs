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
    public class BuscarAtletasPorDisciplina : IBuscarAtletasPorDisciplina
    {
        public IRepositorioAtletas Repo;
        public BuscarAtletasPorDisciplina(IRepositorioAtletas repo)
        {
            Repo = repo;
        }
        //public IEnumerable<ListadoAtletasDTO> BuscarAtletas(ListadoDisciplinasDTO dis)
        //{
        //    Disciplina d = DisciplinaMapper.FromListado(dis);
        //    return AtletaMapper.FromAtletas(Repo.BuscarAtletas(d));
        //}


    }
}
