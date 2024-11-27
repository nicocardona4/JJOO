using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AltaEventoDTO
    {
        [Display(Name = "Disciplina")]
        public int DisciplinaId { get; set; }

        [Required(ErrorMessage = "El nombre es campo obligatorio"), Display(Name = "Nombre de prueba")]
        public string NombrePrueba { get; set; }//debe de ser unico

        [Required(ErrorMessage = "La fecha de inicio es campo obligatorio"), Display(Name = "Fecha de inicio")]
        public string FechaInicial { get; set; }

        [Required(ErrorMessage = "La fecha de finalización es campo obligatorio"), Display(Name = "Fecha de finalización")]
        public string FechaFinal { get; set; }

        [Display(Name = "Atletas")]
        public IEnumerable<int> IdAtletas { get; set; }//minimo deben de ser 3

    }
}
