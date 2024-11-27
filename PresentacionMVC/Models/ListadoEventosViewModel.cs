using DTO;

namespace PresentacionMVC.Models
{
    public class ListadoEventosViewModel
    {
        public IEnumerable<ListadoEventosDTO> Eventos { get; set; }

        public EventoFchDTO EventoFch { get; set; }

        public bool cargado {  get; set; }
    }
}
