using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_teste.Dtos;
using api_teste.Models;
using Microsoft.EntityFrameworkCore;

namespace api_teste.Services
{
    public class SeguroService
    {
        private readonly TodoContext _context;

        public SeguroService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SeguroDto>> GetAllAsync()
        {
            return await _context.Seguros
                .Select(s => new SeguroDto
                {
                    Id = s.id,
                    Descricao = s.descricao,
                    Seguradora = s.seguradora,
                    Tipo = s.tipo,
                    ValorSeguro = s.valor_seguro,
                    ValorFranquia = s.valor_franquia,
                    CreatedAt = s.created_at,
                    UpdatedAt = s.updated_at
                })
                .ToListAsync();
        }

        public async Task<SeguroDto?> GetByIdAsync(int id)
        {
            var s = await _context.Seguros.FindAsync(id);
            if (s == null) return null;

            return new SeguroDto
            {
                Id = s.id,
                Descricao = s.descricao,
                Seguradora = s.seguradora,
                Tipo = s.tipo,
                ValorSeguro = s.valor_seguro,
                ValorFranquia = s.valor_franquia,
                CreatedAt = s.created_at,
                UpdatedAt = s.updated_at
            };
        }

        public async Task<SeguroDto> CreateAsync(SeguroDto dto)
        {
            var entity = new Seguro
            {
                descricao = dto.Descricao ?? "",
                seguradora = dto.Seguradora,
                tipo = dto.Tipo,
                valor_seguro = dto.ValorSeguro,
                valor_franquia = dto.ValorFranquia,
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow
            };

            _context.Seguros.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.id;
            dto.CreatedAt = entity.created_at;
            dto.UpdatedAt = entity.updated_at;

            return dto;
        }

        public async Task<SeguroDto?> UpdateAsync(int id, SeguroDto dto)
        {
            var entity = await _context.Seguros.FindAsync(id);
            if (entity == null) return null;

            entity.descricao = dto.Descricao ?? "";
            entity.seguradora = dto.Seguradora;
            entity.tipo = dto.Tipo;
            entity.valor_seguro = dto.ValorSeguro;
            entity.valor_franquia = dto.ValorFranquia;
            entity.updated_at = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            dto.UpdatedAt = entity.updated_at;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Seguros.FindAsync(id);
            if (entity == null) return false;

            _context.Seguros.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
