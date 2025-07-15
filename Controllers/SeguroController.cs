using System.Collections.Generic;
using System.Threading.Tasks;
using api_teste.Dtos;
using api_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguroController : ControllerBase
    {
        private readonly SeguroService _service;

        public SeguroController(SeguroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeguroDto>>> GetSeguros()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeguroDto>> GetSeguro(int id)
        {
            var seguro = await _service.GetByIdAsync(id);
            if (seguro == null) return NotFound();
            return Ok(seguro);
        }

        [HttpPost]
        public async Task<ActionResult<SeguroDto>> Post([FromBody] SeguroDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var criado = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetSeguro), new { id = criado.Id }, criado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SeguroDto>> Put(int id, [FromBody] SeguroDto dto)
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
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
