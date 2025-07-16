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
    public class LocacaoService
    {
        private readonly AppDbContext _context;

        public LocacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LocacaoDto>> GetAllAsync()
        {
            var locacoes = await _context.Locacoes
                .Include(l => l.veiculos)
                .Include(l => l.LocacaoSeguros)
                .ToListAsync();

            return locacoes.Select(loc => new LocacaoDto
            {
                Id = loc.id,
                Valor = loc.valor,
                FormaPagamento = loc.forma_pagamento,
                DataPedido = loc.data_pedido,
                Status = loc.status,
                Numero = loc.numero,
                Pessoa = loc.PessoaId,
                CreatedAt = loc.created_at,
                UpdatedAt = loc.updated_at,
                Veiculos = loc.veiculos.Select(v => new LocacaoVeiculoDto
                {
                    Veiculo = v.VeiculoId,
                    DataInicio = v.DataInicio,
                    DataFim = v.DataFim,
                    Valor = v.Valor
                }).ToList(),
                Seguros = loc.LocacaoSeguros.Select(s => s.SeguroId).ToList()
            });
        }

        public async Task<LocacaoDto?> GetByIdAsync(int id)
        {
            var loc = await _context.Locacoes
                .Include(l => l.veiculos)
                .Include(l => l.LocacaoSeguros)
                .FirstOrDefaultAsync(l => l.id == id);

            if (loc == null) return null;

            return new LocacaoDto
            {
                Id = loc.id,
                Valor = loc.valor,
                FormaPagamento = loc.forma_pagamento,
                DataPedido = loc.data_pedido,
                Status = loc.status,
                Numero = loc.numero,
                Pessoa = loc.PessoaId,
                CreatedAt = loc.created_at,
                UpdatedAt = loc.updated_at,
                Veiculos = loc.veiculos.Select(v => new LocacaoVeiculoDto
                {
                    Veiculo = v.VeiculoId,
                    DataInicio = v.DataInicio,
                    DataFim = v.DataFim,
                    Valor = v.Valor
                }).ToList(),
                Seguros = loc.LocacaoSeguros.Select(s => s.SeguroId).ToList()
            };
        }

        public async Task<LocacaoDto> CreateAsync(LocacaoDto dto)
        {
            var novaLocacao = new Locacao
            {
                valor = dto.Valor,
                forma_pagamento = dto.FormaPagamento,
                data_pedido = dto.DataPedido,
                status = dto.Status,
                numero = dto.Numero,
                PessoaId = dto.Pessoa,
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow,
                veiculos = dto.Veiculos.Select(v => new LocacaoVeiculo
                {
                    VeiculoId = v.Veiculo,
                    DataInicio = v.DataInicio,
                    DataFim = v.DataFim,
                    Valor = v.Valor,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }).ToList(),
                LocacaoSeguros = dto.Seguros.Select(sid => new LocacaoSeguro
                {
                    SeguroId = sid,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }).ToList()
            };

            _context.Locacoes.Add(novaLocacao);
            await _context.SaveChangesAsync();

            dto.Id = novaLocacao.id;
            dto.CreatedAt = novaLocacao.created_at;
            dto.UpdatedAt = novaLocacao.updated_at;
            return dto;
        }

        public async Task<LocacaoDto?> UpdateAsync(int id, LocacaoDto dto)
        {
            var loc = await _context.Locacoes
                .Include(l => l.veiculos)
                .Include(l => l.LocacaoSeguros)
                .FirstOrDefaultAsync(l => l.id == id);

            if (loc == null) return null;

            loc.valor = dto.Valor;
            loc.forma_pagamento = dto.FormaPagamento;
            loc.data_pedido = dto.DataPedido;
            loc.status = dto.Status;
            loc.numero = dto.Numero;
            loc.PessoaId = dto.Pessoa;
            loc.updated_at = DateTime.UtcNow;

            _context.LocacaoVeiculos.RemoveRange(loc.veiculos);
            _context.LocacaoSeguros.RemoveRange(loc.LocacaoSeguros);

            loc.veiculos = dto.Veiculos.Select(v => new LocacaoVeiculo
            {
                VeiculoId = v.Veiculo,
                DataInicio = v.DataInicio,
                DataFim = v.DataFim,
                Valor = v.Valor,
                CreatedAt = loc.created_at,
                UpdatedAt = DateTime.UtcNow
            }).ToList();

            loc.LocacaoSeguros = dto.Seguros.Select(sid => new LocacaoSeguro
            {
                SeguroId = sid,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }).ToList();

            await _context.SaveChangesAsync();

            dto.UpdatedAt = loc.updated_at;
            return dto;
        }
    }
}
