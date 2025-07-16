// Controller: LocacaoController.cs
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
        public async Task<ActionResult<IEnumerable<Locacao>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> GetById(int id)
        {
            var locacao = await _service.GetByIdAsync(id);
            if (locacao == null) return NotFound();
            return Ok(locacao);
        }

        [HttpPost]
        public async Task<ActionResult<Locacao>> Post([FromBody] LocacaoDto dto)
        {
            var locacao = await _service.CreateAsync(dto);
            if (locacao == null) return BadRequest("Pessoa ou veículos não encontrados.");

            return CreatedAtAction(nameof(GetById), new { id = locacao.Id }, locacao);
        }
    }
}
