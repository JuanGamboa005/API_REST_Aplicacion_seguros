using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modelo;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly iClienteRepository? _clienteRepository;

        public ClienteController(iClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getCliente()
        {
            return Ok(await _clienteRepository.Getcliente());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getClienteById(int id)
        {
            return Ok(await _clienteRepository.GetclienteById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertCliente([FromBody] cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _clienteRepository.Insertcliente(cliente);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _clienteRepository.Insertcliente(cliente);
            return Ok(created);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClienteById(int id)
        {
            return Ok(await _clienteRepository.Deletecliente(id));
        }
    }
}
