using DTO;
using ExcepcionesPropias;
using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentacionMVC.Models;

namespace PresentacionMVC.Controllers
{
    public class EventoController : Controller
    {
        public IListadoAtletas CUListadoAtletas { get; set; }
        public IListadoDisciplinas CUListadoDisciplinas { get; set; }
        public IAltaEvento CUAltaEvento { get; set; }
        public IBuscarDisciplinaPorId CUBuscarDisciplina { get; set; }
        public IBuscarAtletasPorDisciplina CUBuscarAtletasPorDisciplina { get; set; }
        public IListadoEventos CUListadoEventos { get; set; }
        public IBuscarEventoPorNombre CUBuscarEventoPorNombre { get; set; }
        public IAltaParticipacion CUAltaParticipacion { get; set; }

        public EventoController(IListadoAtletas cuListadoAtleas, IListadoDisciplinas cuListadoDisciplinas, IAltaEvento cuAltaEvento, IBuscarDisciplinaPorId cUBuscarDisciplina, IBuscarAtletasPorDisciplina cuBuscarAtletasPorDisciplina, IListadoEventos cuListadoEventos, IBuscarEventoPorNombre cuBuscarEventoPorNombre, IBuscarAtletaPorId cUBuscarAtletaPorId, IAltaParticipacion cuAltaParticipacion)
        {
            CUListadoAtletas = cuListadoAtleas;
            CUListadoDisciplinas = cuListadoDisciplinas;
            CUAltaEvento = cuAltaEvento;
            CUBuscarDisciplina = cUBuscarDisciplina;
            CUBuscarAtletasPorDisciplina = cuBuscarAtletasPorDisciplina;
            CUListadoEventos = cuListadoEventos;
            CUBuscarEventoPorNombre = cuBuscarEventoPorNombre;
            CUAltaParticipacion = cuAltaParticipacion;
        }

        //// GET: EventoController
        //public ActionResult Index(EventoFchDTO dto)
        //{
        //    IEnumerable<ListadoEventosDTO> DTO = CUListadoEventos.ObtenerListado(dto);
        //    return View("Index", vm);

        //}

        // GET: EventoController/Details/5
        //public ActionResult ListadoEventos(EventoFchDTO dto)
        //{
        //    return View();
        //}

        // GET: EventoController/Create
        public ActionResult Create()
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol))
            {
                AltaEventoViewModel vm = new AltaEventoViewModel();
                vm.EventoDTO = new AltaEventoDTO();
                vm.atletas = CUListadoAtletas.ObtenerListado();
                vm.ListadoDisciplinasDTO = CUListadoDisciplinas.ObtenerListado();
                return View(vm);
            }
            else
            {
                return RedirectToAction("NoAutorizado","Usuario");
            }

        }

        // POST: EventoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaEventoViewModel vm)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol))
            {
                try
                {
                    ViewBag.Mensaje = null;
                    CUAltaEvento.Alta(vm.EventoDTO, vm.EventoDTO.IdAtletas);
                    ViewBag.Mensaje = "Evento creado correctamente";
                    AltaEventoViewModel nuevo = new AltaEventoViewModel();
                    nuevo.EventoDTO = new AltaEventoDTO();
                    nuevo.EventoDTO.NombrePrueba = "";
                    nuevo.atletas = CUListadoAtletas.ObtenerListado();
                    nuevo.ListadoDisciplinasDTO = CUListadoDisciplinas.ObtenerListado();
                    return View(nuevo);
                }
                catch (EventoInvalidoException ex)
                {
                    ViewBag.Mensaje = $"Error al crear el evento: {ex.Message}";
                    AltaEventoViewModel nuevo = new AltaEventoViewModel();
                    nuevo.EventoDTO = new AltaEventoDTO();
                    nuevo.atletas = CUListadoAtletas.ObtenerListado();
                    nuevo.ListadoDisciplinasDTO = CUListadoDisciplinas.ObtenerListado();
                    return View(nuevo);
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = $"Error al crear el evento: {ex.Message}";
                    AltaEventoViewModel nuevo = new AltaEventoViewModel();
                    nuevo.EventoDTO = new AltaEventoDTO();
                    nuevo.atletas = CUListadoAtletas.ObtenerListado();
                    nuevo.ListadoDisciplinasDTO = CUListadoDisciplinas.ObtenerListado();
                    return View(nuevo);
                }
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }
               
        }



        // GET: EventoController/ListadoEventos
        [HttpGet]
        public ActionResult ListadoEventos()
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol))
            {
                var model = new ListadoEventosViewModel
                {
                    EventoFch = new EventoFchDTO(),
                    Eventos = new List<ListadoEventosDTO>()
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListadoEventos(ListadoEventosViewModel vm)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol))
            {
                try
                {
                    // Lógica para obtener los eventos según la fecha ingresada
                    var eventos = CUListadoEventos.ObtenerListado(vm.EventoFch);

                    // Actualiza el modelo con los eventos encontrados
                    vm.Eventos = eventos;
                    vm.cargado = true;

                    return View(vm);  // Devuelve la vista con los resultados
                }
                catch (Exception ex)
                {
                    // Maneja errores y regresa a la vista
                    ModelState.AddModelError("", ex.Message);
                    return View(vm);
                }
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }

                
        }

        // GET: EventoController/VerAtletas?nombrePrueba=Posta%20100metros
        public ActionResult VerAtletas(string nombrePrueba)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol))
            {
                ListadoEventosDTO e = CUBuscarEventoPorNombre.Buscar(nombrePrueba);
                IEnumerable<ListadoAtletasDTO> atletas = CUListadoAtletas.ObtenerAtletasPorId(e.IdAtletas);
                ViewBag.NombrePrueba = nombrePrueba;
                return View(atletas);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }
                
        }

        // GET: EventoController/AgregarParticipacion?atletaId=1&nombrePrueba=Posta%20400%20metros
        public ActionResult AgregarParticipacion(int idAtleta, string nombrePrueba)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol))
            {
                ParticipacionDTO dto = new ParticipacionDTO();
                dto.idAtleta = idAtleta;
                dto.nombrePrueba = nombrePrueba;
                return View(dto);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }

        }
        [HttpPost]
        public ActionResult AgregarParticipacion(ParticipacionDTO dto)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol))
            {
                try
                {
                    ViewBag.Mensaje = null;
                    CUAltaParticipacion.Alta(dto);
                    ViewBag.Mensaje = "Puntuación añadida con éxito";
                    return View(dto);
                }
                catch (ParticipacionInvalidaException ex)
                {
                    ViewBag.Mensaje = ex.Message;
                    return View(dto);
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                    return View(dto);
                }
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }
               
        }

        // GET: EventoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
