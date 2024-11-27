using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EventoDeMapperACUDTO
    {
        public Evento evento {  get; set; }
        public IEnumerable<int> idAtletas { get; set; }
    }
}
