using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IListadoAtletas
    {
        IEnumerable<ListadoAtletasDTO> ObtenerListado();
        IEnumerable<ListadoAtletasDTO> ObtenerAtletasPorId(IEnumerable<int> ids);


    }
}
