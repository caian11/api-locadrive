using api_teste.Dtos;
using api_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoDto>>> GetEnderecos()
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
        public async Task<ActionResult<EnderecoDto>> GetEndereco(int id)
        {
            try
            {
                var endereco = await _service.GetByIdAsync(id);
                if (endereco == null)
                    return NotFound("Endereço não encontrado");

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoDto>> Post([FromBody] EnderecoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var criado = await _service.CreateAsync(dto);
                if (criado == null)
                    return NotFound("Cidade não encontrada");

                return CreatedAtAction(nameof(GetEndereco), new { id = criado.Id }, criado);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EnderecoDto>> Put(int id, [FromBody] EnderecoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var atualizado = await _service.UpdateAsync(id, dto);
                if (atualizado == null)
                    return NotFound("Endereço não encontrado");

                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
