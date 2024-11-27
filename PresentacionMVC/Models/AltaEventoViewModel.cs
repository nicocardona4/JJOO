using DTO;

namespace PresentacionMVC.Models
{
    public class AltaEventoViewModel
    {
        public AltaEventoDTO EventoDTO { get; set; }
        public IEnumerable<ListadoAtletasDTO> atletas { get; set; }
        public IEnumerable<ListadoDisciplinasDTO> ListadoDisciplinasDTO { get; set; }
    }
}
