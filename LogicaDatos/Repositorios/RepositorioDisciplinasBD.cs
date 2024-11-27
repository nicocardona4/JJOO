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
    public class RepositorioDisciplinasBD : IRepositorioDisciplinas
    {
        public OlimpiadasContext Contexto { get; set; }

        public RepositorioDisciplinasBD(OlimpiadasContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Disciplina obj)
        {
            if (obj != null)
            {
                obj.Validar();
                Disciplina dis = BuscarPorNombre(obj.NombreDisciplina.Valor);
                if (dis != null) 
                {
                    throw new DisciplinaInvalidaException("Ya existe una disciplina con ese nombre");
                }
                dis = BuscarPorCodigo(obj.Codigo.Valor);
                 if (dis != null)
                {
                    throw new DisciplinaInvalidaException("Ya existe una disciplina con ese codigo");
                }

                Contexto.Disciplinas.Add(obj);
                    Contexto.SaveChanges();
                }
                else
                {
                throw new Exception("Error al enviar datos de disciplina");
                }
        }

        public IEnumerable<Disciplina> FindAll()
        {
            return Contexto.Disciplinas.Include(d => d._atletas)
                .OrderBy(d => d.NombreDisciplina.Valor).ToList();
        }

        public Disciplina FindById(int id)
        {
            return Contexto.Disciplinas.Where(d => d.Id == id).Include(d=>d._atletas).SingleOrDefault();
        }
        public Disciplina AtletasPorDisciplina(int IdDisciplina)
        {
            var resultado = Contexto.Disciplinas.Where(d => d.Id == IdDisciplina).Include(d => d._atletas).SingleOrDefault();
            return resultado;
        }

        public void Remove(int id)
        {
            //Disciplina buscado = Contexto.Disciplinas.Find(id);
            //if (buscado != null)
            //{
            //    Contexto.Disciplinas.Remove(buscado);
            //    Contexto.SaveChanges();
            //}
            //else
            //{
            //    throw new DisciplinaInvalidaException("La disciplina con el id " + id + " no existe");
            //}
        }

        public void Update(Disciplina obj)
        {
            //if (obj != null)
            //{
            //    obj.Validar();
            //    Contexto.Disciplinas.Update(obj);
            //    Contexto.SaveChanges();
            //}
            //else
            //{
            //    //ERROR
            //}
        }

        public Disciplina BuscarPorNombre(string nombre)
        {
            return Contexto.Disciplinas.Where(d => d.NombreDisciplina.Valor == nombre).Include(d => d.NombreDisciplina).SingleOrDefault(); 
        }

        public Disciplina BuscarPorCodigo(int codigo)
        {
            return Contexto.Disciplinas.Where(d => d.Codigo.Valor == codigo).SingleOrDefault();
        }
    }
}
