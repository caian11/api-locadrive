using System.Collections.Generic;
using System.Threading.Tasks;
using api_teste.Dtos;
using api_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _service;

        public PessoaController(PessoaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaDto>>> GetPessoas()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaDto>> GetPessoa(int id)
        {
            var pessoa = await _service.GetByIdAsync(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaDto>> Post([FromBody] PessoaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var criado = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetPessoa), new { id = criado.Id }, criado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaDto>> Put(int id, [FromBody] PessoaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var atualizado = await _service.UpdateAsync(id, dto);
            if (atualizado == null) return NotFound();
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pessoaRemovida = await _service.DeleteAsync(id);
            if (pessoaRemovida == null) return NotFound();
            return NoContent();
        }
    }
}
