using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DisciplinaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Anio {  get; set; }
        public int Codigo { get; set; }

        IEnumerable<string> Atletas { get; set; }
    }
}
