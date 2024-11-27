using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ListadoDisciplinasDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Anio { get; set; }
        public int Codigo { get; set; }

        public IEnumerable<string> Atletas { get; set; }


    }
}
