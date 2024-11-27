using DTO.Mappers;
using DTO;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class BuscarDisciplinaPorId: IBuscarDisciplinaPorId
    {
        public IRepositorioDisciplinas Repo { get; set; }

        public BuscarDisciplinaPorId(IRepositorioDisciplinas repo)
        {
            Repo = repo;
        }

        public ListadoDisciplinasDTO Buscar(int id)
        {
            var result = DisciplinaMapper.FromDisciplina(Repo.FindById(id));
            return result;
        }
    }
}
