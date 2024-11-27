using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioRolesBD: IRepositorioRoles
    {
        public OlimpiadasContext Contexto { get; set; }

        public RepositorioRolesBD(OlimpiadasContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Rol obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> FindAll()
        {
            return Contexto.Roles.ToList();
        }

        public Rol FindById(int id)
        {
            return Contexto.Roles.Find(id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Rol obj)
        {
            throw new NotImplementedException();
        }
    }
}
