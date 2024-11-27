using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AltaDisciplinaDTO
    {
        [Required(ErrorMessage = "El nombre de la disciplina es campo obligatorio"),Display(Name = "Nombre de la Disciplina")]
        public string NombreDisciplina { get; set; }
        public int Codigo { get; set; }

        [Display(Name = "Año de ingreso a los JJOO")]
        public int Anio {  get; set; }
        
    }
}
