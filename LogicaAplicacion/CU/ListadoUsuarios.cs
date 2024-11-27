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
    public class ListadoUsuarios : IListadoUsuarios
    {
        public IRepositorioUsuarios Repositorio { get; set; }

        public ListadoUsuarios(IRepositorioUsuarios repo)
        {
            Repositorio = repo;
        }

        public IEnumerable<ListadoUsuariosDTO> ObtenerListado ()
        {            
            IEnumerable<Usuario> usuarios = Repositorio.FindAll();          
            return UsuarioMapper.FromUsuarios(usuarios);
        }
    }
}
