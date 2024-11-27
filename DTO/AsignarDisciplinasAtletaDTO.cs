using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AsignarDisciplinasAtletaDTO
    {
        public ListadoAtletasDTO dtoAtleta {  get; set; }

        [Display(Name = "Asignar disciplina:")]
        public int IdDisciplina { get; set; }

    }
}
