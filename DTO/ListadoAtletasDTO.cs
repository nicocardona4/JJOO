using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ListadoAtletasDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Pais{ get; set; }

        public string Sexo { get; set; }


        public IEnumerable<string> Disciplinas { get; set; }

        [Display(Name = "Disciplinas actuales")]
        public string DisciplinasComaSeparadas => string.Join(", ", Disciplinas);

    }
}
