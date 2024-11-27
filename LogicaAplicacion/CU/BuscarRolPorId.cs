using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class BuscarRolPorId: IBuscarRolPorId
    {
        public BuscarRolPorId(IRepositorioRoles repo)
        {
            Repo = repo;
        }

        public IRepositorioRoles Repo { get; set; }

        public RolDTO Buscar(int id)
        {
           return RolMapper.ToDTO(Repo.FindById(id));
        }
    }

}
