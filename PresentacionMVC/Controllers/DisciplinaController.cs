using DTO;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentacionMVC.Controllers
{
    public class DisciplinaController : Controller
    {
        public IAltaDisciplina CUAlta {  get; set; }

        public IListadoDisciplinas CUListado { get; set; }

        public DisciplinaController(IAltaDisciplina cuAlta, IListadoDisciplinas cuListado)
        {
            CUAlta = cuAlta;
            CUListado = cuListado;  
        }
        // GET: DisciplinaController
        public ActionResult Index()
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Digitador")
            {
                IEnumerable<ListadoDisciplinasDTO> dtos = CUListado.ObtenerListado();
                return View(dtos);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }

        }

        // GET: DisciplinaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisciplinaController/Create
        public ActionResult Create()
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Digitador")
            {
                AltaDisciplinaDTO dto = new AltaDisciplinaDTO();
                return View(dto);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }

        }

        // POST: DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaDisciplinaDTO dto)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Digitador")
            {
                try
                {
                    CUAlta.Alta(dto);
                    TempData["Mensaje"] = "Disciplina agregada correctamente";
                    return RedirectToAction(nameof(Index));
                }
                catch (DisciplinaInvalidaException ex)
                {
                    TempData["Mensaje"] = ex.Message;
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Ocurrió un error y no se pudo realizar el alta del usuario";
                }

                AltaDisciplinaDTO nuevo = new AltaDisciplinaDTO();
                return View(nuevo);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Usuario");
            }
                
        }

        // GET: DisciplinaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisciplinaController/Edit/5
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

        // GET: DisciplinaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisciplinaController/Delete/5
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
