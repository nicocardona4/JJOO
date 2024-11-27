using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioParticipacionesBD: IRepositorioParticipaciones
    {
        public OlimpiadasContext Contexto { get; set; }

        public RepositorioParticipacionesBD(OlimpiadasContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Participaciones obj)
        {
            obj.Validar();
            Contexto.Participaciones.Add(obj);
            Contexto.SaveChanges();
        }

        public void Update(Participaciones obj)
        {
            throw new NotImplementedException();
        }

        public Participaciones FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participaciones> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
