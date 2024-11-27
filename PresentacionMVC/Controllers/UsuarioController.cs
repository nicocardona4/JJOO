using DTO;
using ExcepcionesPropias;
using Humanizer;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentacionMVC.Models;

namespace PresentacionMVC.Controllers
{
    public class UsuarioController : Controller
    {

        public IAltaUsuario CUAlta { get; set; }
        public IListadoUsuarios CUListado { get; set; }
        public IListadoRoles CUListadoRoles { get; set; }
        public IBuscarUsuarioPorId CUBuscarUsuarioPorId { get; set; }
        public IModificarUsuario CUModificarUsuario { get; set; }
        public IBajaUsuario CUBajaUsuario { get; set; }
        public ILogin CULogin { get; set; }

        public UsuarioController
            (IAltaUsuario cuAlta, IListadoUsuarios cuListado, IListadoRoles cuListadoRoles,
            IBuscarUsuarioPorId cuBuscarUsuarioPorId, IModificarUsuario cuModificarUsuario,
            IBajaUsuario cuBajaUsuario, ILogin cuLogin)
        {
            CUAlta = cuAlta;
            CUListado = cuListado;
            CUListadoRoles = cuListadoRoles;
            CUBuscarUsuarioPorId = cuBuscarUsuarioPorId;
            CUModificarUsuario = cuModificarUsuario;
            CUBajaUsuario = cuBajaUsuario;
            CULogin = cuLogin;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                IEnumerable<ListadoUsuariosDTO> dtos = CUListado.ObtenerListado();
                return View(dtos);
            }
            else
            {
                return RedirectToAction(nameof(NoAutorizado));
            }

        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                UsuarioDTO dto = CUBuscarUsuarioPorId.Buscar(id);
                if (dto == null)
                {
                    ViewBag.ErrorMessage = "No se encontró el usuario";
                    IEnumerable<ListadoUsuariosDTO> dtos = CUListado.ObtenerListado();
                    return View("Index", dtos);
                }
                return View(dto);
            }
            else
            {
                return RedirectToAction(nameof(NoAutorizado));
            }

        }

        //GET: UsuarioController/Create
        public ActionResult Create()
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                AltaUsuarioViewModel vm = new AltaUsuarioViewModel();
                vm.DTOAltaUsuario = new AltaUsuarioDTO();
                vm.RolesDTO = CUListadoRoles.ObtenerListado();
                return View(vm);
            }
            else
            {
                return RedirectToAction(nameof(NoAutorizado));

            }
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaUsuarioViewModel vm)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                try
                {
                    vm.DTOAltaUsuario.Admin = HttpContext.Session.GetString("Admin");
                    vm.DTOAltaUsuario.FechaRegistro = DateTime.Now;
                    CUAlta.Alta(vm.DTOAltaUsuario);
                    return RedirectToAction(nameof(Index));
                }
                catch (UsuarioInvalidoException ex)
                {
                    ViewBag.Error = ex.Message;
                    AltaUsuarioViewModel nuevo = new AltaUsuarioViewModel();
                    nuevo.DTOAltaUsuario = new AltaUsuarioDTO();
                    nuevo.RolesDTO = CUListadoRoles.ObtenerListado();
                    return View(nuevo);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Ocurrió un error y no se pudo realizar el alta del usuario";
                    AltaUsuarioViewModel nuevo = new AltaUsuarioViewModel();
                    nuevo.DTOAltaUsuario = new AltaUsuarioDTO();
                    nuevo.RolesDTO = CUListadoRoles.ObtenerListado();
                    return View(nuevo);
                }
            }
            else
            {
                return RedirectToAction(nameof(NoAutorizado));
            }

        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                UsuarioDTO dto = CUBuscarUsuarioPorId.Buscar(id);
                if (dto == null)
                {
                    ViewBag.ErrorMessage = "No se encontró el usuario";
                    IEnumerable<ListadoUsuariosDTO> dtos = CUListado.ObtenerListado();
                    return View("Index", dtos);
                }
                return View(dto);
            }
            else
            {
                return RedirectToAction(nameof(NoAutorizado));
            }

        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioDTO dto)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                try
                {
                    CUModificarUsuario.Modificar(dto);
                    return RedirectToAction(nameof(Index));
                }
                catch (UsuarioInvalidoException ex)
                {
                    ViewBag.Error = ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Ocurrió un error y no se realizó la modificación.";
                }

                return View(dto);
            }
            else
            {
                return RedirectToAction(nameof(NoAutorizado));
            }

        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                UsuarioDTO dto = CUBuscarUsuarioPorId.Buscar(id);
                if (dto == null)
                {
                    ViewBag.ErrorMessage = "No se encontró el usuario";
                    IEnumerable<ListadoUsuariosDTO> dtos = CUListado.ObtenerListado();
                    return View("Index", dtos);
                }
                return View(dto);
            }
            else
            {
                return RedirectToAction(nameof(NoAutorizado));
            }

        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioDTO dto)
        {
            string rol = HttpContext.Session.GetString("Rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                try
                {
                    CUBajaUsuario.Borrar(dto.Id);
                    return RedirectToAction(nameof(Index));
                }
                catch (UsuarioInvalidoException ex)
                {
                    ViewBag.Error = ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Ocurrió un error y no se realizó el borrado";
                }
                return View(dto);
            }
            else
            {
                return RedirectToAction(nameof(NoAutorizado));
            }


        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO login)
        {
            try
            {
             ListadoUsuariosDTO usu = CULogin.Loguear(login);
                if (usu != null)
                {

                    HttpContext.Session.SetString("Rol", usu.NombreRol);
                    HttpContext.Session.SetString("Admin", usu.Email);
                    ViewBag.Mensaje = "Se ha logueado con exito!";
                    if (usu.NombreRol == "Administrador")
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else if (usu.NombreRol == "Digitador")
                    {
                        return RedirectToAction("Index", "Atleta");

                    }
                    else
                    {
                        return View();
                    }

                }
                else
                {
                    return View();
                }
            }
            catch (UsuarioInvalidoException ex)
            {
                ViewBag.Error = ex.Message;
                return View(login);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(login);
            }


        }
        [HttpGet]
        public ActionResult NoAutorizado()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }


    }
}
