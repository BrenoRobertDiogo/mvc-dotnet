using Microsoft.AspNetCore.Mvc;
using Models.Clientes;
using Servicos.Clientes;

namespace mvc_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.ObterTodosAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _service.ObterPorIdAsync(id);
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetById(string nome)
        {
            var cliente = (await _service.ObterTodosAsync()).Where(x => x.Equals(nome));
            return cliente is null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            await _service.AdicionarAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPost("contar")]
        public async Task<IActionResult> Contar()
        {
            return CreatedAtAction(nameof(GetById), (await _service.ObterTodosAsync()).Count());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            await _service.AtualizarAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoverAsync(id);
            return NoContent();
        }
    }

}
