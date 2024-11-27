using DTO;
using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IAsignarDisciplinaAtleta
    {
        Atleta AsignarDisciplina(AsignarDisciplinasAtletaDTO nuevo);

    }
}
