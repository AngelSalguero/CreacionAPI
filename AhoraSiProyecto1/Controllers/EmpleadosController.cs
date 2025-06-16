using AhoraSiProyecto1.Models;
using AhoraSiProyecto1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhoraSiProyecto1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosService _service;

        public EmpleadosController(IEmpleadosService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuario = await _service.AllUsers();
            return Ok(usuario);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> AgregarUsuario([FromBody] Empleado modelo)
        {
            if (modelo == null) return BadRequest("El modelo no puede ser nulo.");

            var filas = await _service.AddUser(modelo);

            if (filas > 0) return Ok(filas);

            return BadRequest("Error al agregar el usuario.");
        }

        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> ModificarUsuario([FromBody] Empleado modelo)
        {
            if (modelo == null) return BadRequest("El modelo no puede ser nulo.");
            var filas = await _service.UpdatseUser(modelo);
            if (filas > 0) return Ok(filas);
            return BadRequest("Error al modificar el usuario.");
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            if (id <= 0) return BadRequest("El ID debe ser mayor que cero.");
            var filas = await _service.DeleteUser(id);
            if (filas > 0) return Ok(filas);
            return NotFound("Usuario no encontrado o error al eliminar.");
        }
    }
}
