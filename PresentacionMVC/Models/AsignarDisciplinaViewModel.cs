using DTO;
using System.ComponentModel;

namespace PresentacionMVC.Models
{
    public class AsignarDisciplinaViewModel
    {
        
        public AsignarDisciplinasAtletaDTO dto {  get; set; }
        public IEnumerable<ListadoDisciplinasDTO> ListadoDisciplinasDTO { get; set; }
    }
}
