using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAtletas: IRepositorio<Atleta>
    {
       Atleta AsignarDiscplina(int idAtleta, int idDisciplina);
        //IEnumerable<Atleta> BuscarAtletasPorEvento(string nombre);
    }
}
