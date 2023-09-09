using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modelo;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public readonly iEmpleadoRepository? _empleadoRepository;

        public EmpleadoController(iEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getEmpleado()
        {
            return Ok(await _empleadoRepository.getEmpleado());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getEmpleadoById(int id)
        {
            return Ok(await _empleadoRepository.getEmpleadoById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] empleado empleado)
        {
            if (empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _empleadoRepository.insertEmpleado(empleado);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmpleado([FromBody] empleado empleado)
        {
            if (empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _empleadoRepository.insertEmpleado(empleado);
            return Ok(created);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClienteById(int id)
        {
            return Ok(await _empleadoRepository.deleteEmpleado(id));
        }
    }
}
