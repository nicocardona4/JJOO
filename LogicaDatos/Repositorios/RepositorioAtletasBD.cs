using DTO;
using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioAtletasBD : IRepositorioAtletas
    {
        public OlimpiadasContext Contexto { get; set; }

        public RepositorioAtletasBD(OlimpiadasContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Atleta obj)
        {

        }

        public IEnumerable<Atleta> FindAll()
        {
            return Contexto.Atletas.Include(atl => atl.Pais)
                                   .Include(atl => atl._disciplinas)
                                   .Include(atl=>atl._eventos)
                                   .OrderBy(atl => atl.Pais.Nombre)
                                   .ThenBy(atl => atl.Apellido)
                                   .ThenBy(atl => atl.Nombre)
                                   .ToList();
        }


        public Atleta FindById(int id)
        {
            return Contexto.Atletas.Include(atl => atl.Pais).Include(atl => atl._disciplinas)
                .Include(atl => atl._eventos)
                .Where(atl => atl.Id == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
        }

        public void Update(Atleta obj)
        {
        }

        public Atleta AsignarDiscplina(int idAtleta, int idDisciplina)
        {
            var atleta = Contexto.Atletas.Include(a => a._disciplinas).SingleOrDefault(a => a.Id == idAtleta);
            var disciplina = Contexto.Disciplinas.SingleOrDefault(d => d.Id == idDisciplina);

            if (atleta == null || disciplina == null)
                throw new Exception("Atleta o Disciplina no encontrados.");

            var disciplinasLista = atleta._disciplinas.ToList();
            if (!disciplinasLista.Contains(disciplina))
            {
                disciplinasLista.Add(disciplina);
                atleta._disciplinas = disciplinasLista;
                Contexto.SaveChanges();
            }
            else
            {
                throw new DisciplinaInvalidaException("La disciplina ya está asignada.");
            }
            return atleta;
        }

    }
}
