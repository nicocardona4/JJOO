using DTO;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio;
using PresentacionMVC.Models;
using LogicaAplicacion.CU;

namespace PresentacionMVC.Controllers
{
    public class AtletaController : Controller
    {
        public IListadoAtletas CUListado { get; set; }
        public IAsignarDisciplinaAtleta CUAsignarDisciplinaAtleta { get; set; }

        public IListadoDisciplinas CUListadoDisciplinas { get; set; }

        public IBuscarAtletaPorId CUBuscarAtletaPorId { get; set; }
        public AtletaController(IListadoAtletas cuListado, IAsignarDisciplinaAtleta cuAsignarDisciplinaAtleta, IBuscarAtletaPorId cuBuscarAtletaPorId, IListadoDisciplinas cuListadoDisciplinas)
        {
            CUListado = cuListado;
            CUAsignarDisciplinaAtleta = cuAsignarDisciplinaAtleta;
            CUBuscarAtletaPorId = cuBuscarAtletaPorId;
            CUListadoDisciplinas = cuListadoDisciplinas;
        }

        // GET: AtletaController
        public ActionResult Index()
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Digitador")
            {
                IEnumerable<ListadoAtletasDTO> dtos = CUListado.ObtenerListado();
                return View(dtos);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }

        }

        // GET: AtletaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AtletaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AtletaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        [HttpGet]
        public ActionResult AsignarDisciplina(int id)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol))
            {
                AsignarDisciplinaViewModel vm = new AsignarDisciplinaViewModel();
                vm.dto = new AsignarDisciplinasAtletaDTO();
                ListadoAtletasDTO dto = CUBuscarAtletaPorId.Buscar(id);
                if (dto != null)
                {
                    vm.dto.dtoAtleta = dto;
                    vm.ListadoDisciplinasDTO = CUListadoDisciplinas.ObtenerListado();
                    return View(vm);
                }
                else
                {
                    ViewBag.ErrorMessage = "No se encontró el atleta";
                    IEnumerable<ListadoAtletasDTO> dtos = CUListado.ObtenerListado();
                    return View("Index", dtos);
                }
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }
               
        }

        [HttpPost]
        public ActionResult AsignarDisciplina(AsignarDisciplinaViewModel vm)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Digitador")
            {
                try
                {
                    if (vm.dto == null)
                    {
                        throw new ArgumentNullException("El ViewModel o el DTO no pueden ser nulos.");
                    }

                    var atleta = CUAsignarDisciplinaAtleta.AsignarDisciplina(vm.dto);

                    return RedirectToAction(nameof(Index));
                    ;
                }
                catch (ArgumentNullException ex)
                {
                    ViewBag.ErrorMessage = $"Argumento nulo: {ex.Message}";
                }
                catch (ArgumentException ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
                catch (InvalidOperationException ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = $"Ocurrió un error: {ex.Message}";
                }
                IEnumerable<ListadoAtletasDTO> dtos = CUListado.ObtenerListado();
                return View("Index", dtos);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }
                
        }


        //// GET: AtletaController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AtletaController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //// GET: AtletaController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AtletaController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
