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
    public class Login: ILogin
    {
        public IRepositorioUsuarios Repo { get; set; }

        public Login(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public ListadoUsuariosDTO Loguear(LoginDTO dto)
        {
            Usuario usuario = UsuarioMapper.FromLogin(dto);
            Usuario aux = Repo.BuscarPorMail(dto.Email);
            if (aux == null)
            {
                throw new UsuarioInvalidoException("No se encontró el usuario");
            }
                usuario.Rol = aux.Rol;
                usuario.Id = aux.Id;

                if (usuario != null)
                {
                    usuario.Validar();
                    usuario = Repo.Login(usuario);
                if (usuario == null)
                {
                    throw new UsuarioInvalidoException("La contraseña no es correcta");

                }
                return UsuarioMapper.FromUsuario(usuario);
                }

            

            return null;
        }
    }
}
