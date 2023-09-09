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
            return Ok(await _empleadoRepository.Getempleado());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getEmpleadoById(int id)
        {
            return Ok(await _empleadoRepository.GetempleadoById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertEmpleado([FromBody] empleado empleado)
        {
            if (empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _empleadoRepository.Insertempleado(empleado);
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
            var created = await _empleadoRepository.Insertempleado(empleado);
            return Ok(created);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmpleadoById(int id)
        {
            return Ok(await _empleadoRepository.Deleteempleado(id));
        }
    }
}
