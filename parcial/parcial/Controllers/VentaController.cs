using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modelo;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        public readonly iVentaRepository? _ventaRepository;

        public VentaController(iVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getVenta()
        {
            return Ok(await _ventaRepository.Getventa());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getVentaById(int id)
        {
            return Ok(await _ventaRepository.GetventaById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertVenta([FromBody] venta venta)
        {
            if (venta == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _ventaRepository.Insertventa(venta);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVenta([FromBody] venta venta)
        {
            if (venta == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _ventaRepository.Insertventa(venta);
            return Ok(created);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVentaById(int id)
        {
            return Ok(await _ventaRepository.Deleteventa(id));
        }
    }
}
