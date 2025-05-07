using System.Collections.Generic;
using System.Threading.Tasks;
using api_teste.Dtos;
using api_teste.Models;      // para a classe Veiculo
using api_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _service;

        public VeiculoController(VeiculoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoDto>>> GetVeiculos()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDto>> GetVeiculo(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoDto>> PostVeiculo(VeiculoDto dto)
        {
            var criado = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetVeiculo), new { id = criado.Id }, criado);
        }

        // 2) Alterado: retorna ActionResult<Veiculo> e devolve a entidade completa
        [HttpPut("{id}")]
        public async Task<ActionResult<Veiculo>> PutVeiculo(int id, VeiculoDto dto)
        {
            var atualizado = await _service.UpdateAsync(id, dto);
            if (atualizado == null)
                return NotFound();
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
