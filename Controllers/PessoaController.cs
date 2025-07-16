using api_teste.DataContexts;
using api_teste.Dtos;
using api_teste.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var lista = await _service.GetAllAsync();
                return Ok(lista);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaDto>> GetPessoa(int id)
        {
            try
            {
                var pessoa = await _service.GetByIdAsync(id);

                if (pessoa == null) return NotFound("Pessoa não encontada");
             
                return Ok(pessoa);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PessoaDto>> Post([FromBody] PessoaDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var criado = await _service.CreateAsync(dto);

                if (criado == null) return NotFound("Endereço não encontrado");

                return CreatedAtAction(nameof(GetPessoa), new { id = criado.Id }, criado);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaDto>> Put(int id, [FromBody] PessoaDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var atualizado = await _service.UpdateAsync(id, dto);

                if (atualizado == null) return NotFound("Pessoa não encontrada!");

                return Ok(atualizado);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pessoaRemovida = await _service.DeleteAsync(id);
                
                if (pessoaRemovida == null) return NotFound("Pessoa não encontrada!");
                
                return Ok("Pessoa removida com sucesso!");

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
