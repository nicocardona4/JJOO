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
    public class RepositorioUsuariosBD : IRepositorioUsuarios
    {
        public OlimpiadasContext Contexto { get; set; }

        public RepositorioUsuariosBD(OlimpiadasContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Usuario obj)
        {
            if (obj != null)
            {
                obj.Validar();
                Usuario u = BuscarPorMail(obj.Email.Valor);
                if (u != null) 
                {
                    throw new UsuarioInvalidoException("Ya existe un usuario con ese mail");
                }
                Contexto.Usuarios.Add(obj);
                Contexto.SaveChanges();
            }
            else
            {
                throw new Exception("No se pudo completar el alta");
            }
        }

        public Usuario BuscarPorMail(string mail)
        {
            //ESTA CONSULTA LINQ, TRAE EL USUARIO CON SU ROL
            return Contexto.Usuarios
                    .Include(usu => usu.Rol)
                    .Where(usu => usu.Email.Valor == mail)
                    .SingleOrDefault();
        }

        public IEnumerable<Usuario> FindAll()
        {
            //AGREGAMOS EL INCLUDE PARA QUE EF TRAIGA EL OBJETO ROL RELACIONADO CON CADA USUARIO
            //DE LO CONTRARIO NO LO TRAERÍA POR DEFECTO Y SERÍA NULL
            return Contexto.Usuarios.Include(usu => usu.Rol).ToList();
        }

        public Usuario FindById(int id)
        {
            //ESTA CONSULTA LINQ, TRAE EL USUARIO CON SU ROL
            return Contexto.Usuarios
                    .Include(usu => usu.Rol)
                    .Where(usu => usu.Id == id)
                    .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Usuario buscado = Contexto.Usuarios.Find(id);
            if (buscado == null)
            {
                throw new UsuarioInvalidoException("El usuario con el id " + id + " no existe");

            }
            else
            {
                Contexto.Usuarios.Remove(buscado);
                Contexto.SaveChanges();
            }
        }

        public void Update(Usuario obj)
        {
             
            if (obj != null)
            {
                obj.Validar();

                Usuario u = FindById(obj.Id);
                u.Email = obj.Email;

                Contexto.Usuarios.Update(u);
                Contexto.SaveChanges();
            }
            else
            {
                //ERROR
            }
        }

        public Usuario Login(Usuario usu)
        {
            var resultado = Contexto.Usuarios.Where(u => u.Email.Valor == usu.Email.Valor
                && u.Contrasenia.Valor == usu.Contrasenia.Valor).SingleOrDefault();
            return resultado;
        }
    }
}
