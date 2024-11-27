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
    public class BuscarUsuarioPorId : IBuscarUsuarioPorId
    {
        public IRepositorioUsuarios Repo { get; set; }

        public BuscarUsuarioPorId(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public UsuarioDTO Buscar(int id)
        {
            return UsuarioMapper.ToDTO(Repo.FindById(id));
        }

        public void Borrar(int id)
        {
            Repo.Remove(id);
        }
    }
}
