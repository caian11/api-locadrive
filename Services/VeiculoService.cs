using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_teste.Dtos;
using api_teste.Models;
using Microsoft.EntityFrameworkCore;

namespace api_teste.Services
{
    public class VeiculoService
    {
        private readonly TodoContext _context;

        public VeiculoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VeiculoDto>> GetAllAsync()
        {
            return await _context.Veiculo
                .Select(v => new VeiculoDto
                {
                    id = v.id,
                    modelo = v.modelo,
                    descricao = v.descricao,
                    marca = v.marca
                })
                .ToListAsync();
        }

        public async Task<VeiculoDto> GetByIdAsync(int id)
        {
            var v = await _context.Veiculo.FindAsync(id);
            if (v == null) return null;
            return new VeiculoDto
            {
                id = v.id,
                modelo = v.modelo,
                descricao = v.descricao,
                marca = v.marca
            };
        }

        public async Task<VeiculoDto> CreateAsync(VeiculoDto dto)
        {
            var entity = new Veiculo
            {
                modelo = dto.modelo,
                descricao = dto.descricao,
                marca = dto.marca
            };
            _context.Veiculo.Add(entity);
            await _context.SaveChangesAsync();
            dto.id = entity.id;
            return dto;
        }

        // 1) Alterado: agora retorna Veiculo
        public async Task<Veiculo> UpdateAsync(int id, VeiculoDto dto)
        {
            var v = await _context.Veiculo.FindAsync(id);
            if (v == null) return null;

            v.modelo = dto.modelo;
            v.descricao = dto.descricao;
            v.marca = dto.marca;

            _context.Entry(v).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Retorna a entidade completa
            return v;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var v = await _context.Veiculo.FindAsync(id);
            if (v == null) return false;
            _context.Veiculo.Remove(v);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
