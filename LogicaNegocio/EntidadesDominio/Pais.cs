using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Pais
    {
        [Key]
        public string Nombre { get; set; }
        public int cantHabitantes { get; set; }
        public int telDelegado { get; set; }
    }
}
