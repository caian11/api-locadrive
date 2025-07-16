using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_teste.DataContexts;
using api_teste.Dtos;
using api_teste.Models;
using Microsoft.EntityFrameworkCore;

namespace api_teste.Services
{
    public class PessoaService
    {
        private readonly AppDbContext _context;

        public PessoaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetAllAsync()
        {
            return await _context.Pessoas
                    .Include(p => p.Endereco)
                    .ToListAsync();
        }

        public async Task<Pessoa?> GetByIdAsync(int id)
        {
            return await _context.Pessoas
                    .Include(p => p.Endereco)
                    .SingleOrDefaultAsync(p => p.Id == id);
        }

        public bool EnderecoExists(int enderecoId)
        {
            return _context.Enderecos.Any(e => e.Id == enderecoId);
        }

        public async Task<Pessoa?> CreateAsync(PessoaDto dto)
        {
            if (!EnderecoExists(dto.EnderecoId))
                return null;

            var newPessoa = new Pessoa
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Cpf = dto.Cpf,
                Senha = dto.Senha,
                DataNascimento = dto.DataNascimento,
                Status = dto.Status,
                EnderecoId = dto.EnderecoId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Pessoas.AddAsync(newPessoa);
            await _context.SaveChangesAsync();
            return newPessoa;
        }

        public async Task<Pessoa?> UpdateAsync(int id, PessoaDto dto)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null)
                return null;

            existing.Nome = dto.Nome;
            existing.Email = dto.Email;
            existing.Cpf = dto.Cpf;
            existing.Senha = dto.Senha;
            existing.DataNascimento = dto.DataNascimento;
            existing.Status = dto.Status;
            existing.EnderecoId = dto.EnderecoId;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.Pessoas.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Pessoa?> DeleteAsync(int id)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null)
                return null;

            _context.Pessoas.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        private async Task<bool> ExistsAsync(int id)
        {
            return await _context.Pessoas.AnyAsync(p => p.Id == id);
        }
    }
}
