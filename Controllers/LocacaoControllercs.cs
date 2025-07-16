using System.Collections.Generic;
using System.Threading.Tasks;
using api_teste.Dtos;
using api_teste.Models;
using api_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_teste.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocacaoController : ControllerBase
    {
        private readonly LocacaoService _service;

        public LocacaoController(LocacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocacaoDto>>> GetAll()
        {
            var locacoes = await _service.GetAllAsync();
            return Ok(locacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocacaoDto>> GetById(int id)
        {
            var locacao = await _service.GetByIdAsync(id);
            if (locacao == null) return NotFound();
            return Ok(locacao);
        }

        [HttpPost]
        public async Task<ActionResult<LocacaoDto>> Post([FromBody] LocacaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nova = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nova.Id }, nova);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LocacaoDto>> Put(int id, [FromBody] LocacaoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var atualizada = await _service.UpdateAsync(id, dto);
            if (atualizada == null) return NotFound();
            return Ok(atualizada);
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
