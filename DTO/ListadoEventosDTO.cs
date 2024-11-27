using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ListadoEventosDTO
    {
        public int DisciplinaId { get; set; }

        public string NombrePrueba { get; set; }//debe de ser unico

        public string FechaInicial { get; set; }

        public string FechaFinal { get; set; }

        public IEnumerable<int> IdAtletas { get; set; }//minimo deben de ser 3

        public string Disciplina { get; set; }
    }
}
