using DTO;
using DTO.Mappers;
using ExcepcionesPropias;
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
    public class AltaUsuario: IAltaUsuario
    {
        public IRepositorioUsuarios Repositorio { get; set; }
        public IRepositorioRoles RepositorioRoles { get; set; }

        public AltaUsuario(IRepositorioUsuarios repo, IRepositorioRoles repositorioRoles)
        {
            Repositorio = repo;
            RepositorioRoles = repositorioRoles;
        }

        public void Alta(AltaUsuarioDTO dto)
        {

            Usuario usu = UsuarioMapper.FromDTO(dto);
            Rol rol = RepositorioRoles.FindById(usu.RolId);
            if (rol == null)
            {
                throw new UsuarioInvalidoException("El rol seleccionado no existe");
            }
            usu.Rol = rol;
            Repositorio.Add(usu);
        }
    }
}
