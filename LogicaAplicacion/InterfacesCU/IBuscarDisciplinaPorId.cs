using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IBuscarDisciplinaPorId
    {
        ListadoDisciplinasDTO Buscar(int id);

    }
}
