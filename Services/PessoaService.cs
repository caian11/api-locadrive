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
        private readonly TodoContext _context;

        public PessoaService(TodoContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetAllAsync()
        {
            try
            {
                return await _context.Pessoas
                    .Include(p => p.Endereco)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Pessoa?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Pessoas
                    .Include(p => p.Endereco)
                    .SingleOrDefaultAsync(p => p.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public bool EnderecoExists(int enderecoId)
        {
            try
            {
                return _context.Enderecos.Any(e => e.Id == enderecoId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Pessoa?> CreateAsync(PessoaDto dto)
        {
            try
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
            catch
            {
                throw;
            }
        }

        public async Task<Pessoa?> UpdateAsync(int id, PessoaDto dto)
        {
            try
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
            catch
            {
                throw;
            }
        }

        public async Task<Pessoa?> DeleteAsync(int id)
        {
            try
            {
                var existing = await GetByIdAsync(id);
                if (existing == null)
                    return null;

                _context.Pessoas.Remove(existing);
                await _context.SaveChangesAsync();
                return existing;
            }
            catch
            {
                throw;
            }
        }

        private async Task<bool> ExistsAsync(int id)
        {
            return await _context.Pessoas.AnyAsync(p => p.Id == id);
        }
    }
}
