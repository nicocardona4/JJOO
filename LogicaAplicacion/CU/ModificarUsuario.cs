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
    public class ModificarUsuario : IModificarUsuario
    {
        public IRepositorioUsuarios Repo { get; set; }

        public ModificarUsuario(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public void Modificar(UsuarioDTO dto)
        {
            Repo.Update(UsuarioMapper.ToUsuario(dto));
        }
    }
}
