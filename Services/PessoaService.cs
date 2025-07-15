using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<PessoaDto>> GetAllAsync()
        {
            return await _context.Pessoas
                .Select(p => new PessoaDto
                {
                    Id = p.id,
                    Nome = p.nome,
                    Email = p.email,
                    Cpf = p.cpf,
                    Senha = p.senha,
                    DataNascimento = p.data_nascimento,
                    Status = p.status,
                    EnderecoId = p.endereco,
                    CreatedAt = p.created_at,
                    UpdatedAt = p.updated_at
                })
                .ToListAsync();
        }

        public async Task<PessoaDto?> GetByIdAsync(int id)
        {
            var p = await _context.Pessoas.FindAsync(id);
            if (p == null) return null;

            return new PessoaDto
            {
                Id = p.id,
                Nome = p.nome,
                Email = p.email,
                Cpf = p.cpf,
                Senha = p.senha,
                DataNascimento = p.data_nascimento,
                Status = p.status,
                EnderecoId = p.endereco,
                CreatedAt = p.created_at,
                UpdatedAt = p.updated_at
            };
        }

        public async Task<PessoaDto> CreateAsync(PessoaDto dto)
        {
            var entity = new Pessoa
            {
                nome = dto.Nome,
                email = dto.Email,
                cpf = dto.Cpf,
                senha = dto.Senha,
                data_nascimento = dto.DataNascimento,
                status = dto.Status,
                endereco = dto.EnderecoId,
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow
            };

            _context.Pessoas.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.id;
            dto.CreatedAt = entity.created_at;
            dto.UpdatedAt = entity.updated_at;

            return dto;
        }

        public async Task<PessoaDto?> UpdateAsync(int id, PessoaDto dto)
        {
            var entity = await _context.Pessoas.FindAsync(id);
            if (entity == null) return null;

            entity.nome = dto.Nome;
            entity.email = dto.Email;
            entity.cpf = dto.Cpf;
            entity.senha = dto.Senha;
            entity.data_nascimento = dto.DataNascimento;
            entity.status = dto.Status;
            entity.endereco = dto.EnderecoId;
            entity.updated_at = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            dto.UpdatedAt = entity.updated_at;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Pessoas.FindAsync(id);
            if (entity == null) return false;

            _context.Pessoas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
