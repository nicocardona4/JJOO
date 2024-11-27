using DTO;
using ExcepcionesPropias;
using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        public IBuscarEventosPorAtleta CUListadoEventos{ get; set; }

        public AtletaController(IBuscarEventosPorAtleta cuListadoEventos)
        {
            CUListadoEventos = cuListadoEventos;
        }

        // GET api/atleta/5/eventos
        [HttpGet("{id}/eventos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEventosPorAtleta(int id)
        {
            if (id <= 0) 
            { 
                return BadRequest("El id debe ser mayor a 0"); 
            }
            try
            {
                IEnumerable<ListadoEventosDTO> eventos = CUListadoEventos.Buscar(id);
                if (eventos == null)
                {
                    return NotFound("No se encontraron eventos para ese atleta");
                }
                return Ok(eventos);
            }
            catch (AtletaInvalidoException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }


        //// GET: api/<AtletaController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<AtletaController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<AtletaController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<AtletaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AtletaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
