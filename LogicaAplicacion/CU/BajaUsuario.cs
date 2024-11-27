using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class BajaUsuario : IBajaUsuario
    {
        public IRepositorioUsuarios Repo { get; set; }

        public BajaUsuario(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }

        public void Borrar(int id)
        {
            Repo.Remove(id);
        }
    }
}
