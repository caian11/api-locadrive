using api_teste.DataContexts;
using api_teste.Dtos;
using api_teste.Models;
using Microsoft.EntityFrameworkCore;

namespace api_teste.Services
{
    public class EnderecoService
    {
        private readonly AppDbContext _context;

        public EnderecoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Endereco>> GetAllAsync()
        {
            return await _context.Enderecos
                .Include(e => e.Cidade)
                .ToListAsync();
        }

        public async Task<Endereco?> GetByIdAsync(int id)
        {
            return await _context.Enderecos
                .Include(e => e.Cidade)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public bool CidadeExists(int cidadeId)
        {
            return _context.Cidades.Any(c => c.Id == cidadeId);
        }

        public async Task<Endereco?> CreateAsync(EnderecoDto dto)
        {
            if (!CidadeExists(dto.CidadeId))
                return null;

            var newEndereco = new Endereco
            {
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cep = dto.Cep,
                CidadeId = dto.CidadeId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Enderecos.AddAsync(newEndereco);
            await _context.SaveChangesAsync();
            return newEndereco;
        }

        public async Task<Endereco?> UpdateAsync(int id, EnderecoDto dto)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null)
                return null;

            existing.Logradouro = dto.Logradouro;
            existing.Numero = dto.Numero;
            existing.Complemento = dto.Complemento;
            existing.Bairro = dto.Bairro;
            existing.Cep = dto.Cep;
            existing.CidadeId = dto.CidadeId;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.Enderecos.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
