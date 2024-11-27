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
    public class AltaDisciplina: IAltaDisciplina
    {
        public IRepositorioDisciplinas Repositorio { get; set; }

        public AltaDisciplina(IRepositorioDisciplinas repo)
        {
            Repositorio = repo;
        }

        public void Alta(AltaDisciplinaDTO dto)
        {

            Disciplina dis = DisciplinaMapper.FromDTO(dto);
            Repositorio.Add(dis);
        }
    }
}
