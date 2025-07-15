using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_teste.DataContexts;
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
                    Id = v.id,
                    Modelo = v.modelo,
                    Descricao = v.descricao,
                    Marca = v.marca,
                    Situacao = v.situacao,
                    Placa = v.placa,
                    Renavam = v.renavam,
                    AnoFabricacao = v.ano_fabricacao,
                    Tipo = v.tipo,
                    Chassi = v.chassi,
                    CapacidadePassageiros = v.capacidade_passageiros,
                    Potencia = v.potencia,
                    Cor = v.cor,
                    ValorDiaria = v.valor_diaria
                })
                .ToListAsync();
        }

        public async Task<VeiculoDto> GetByIdAsync(int id)
        {
            var v = await _context.Veiculo.FindAsync(id);
            if (v == null) return null;

            return new VeiculoDto
            {
                Id = v.id,
                Modelo = v.modelo,
                Descricao = v.descricao,
                Marca = v.marca,
                Situacao = v.situacao,
                Placa = v.placa,
                Renavam = v.renavam,
                AnoFabricacao = v.ano_fabricacao,
                Tipo = v.tipo,
                Chassi = v.chassi,
                CapacidadePassageiros = v.capacidade_passageiros,
                Potencia = v.potencia,
                Cor = v.cor,
                ValorDiaria = v.valor_diaria
            };
        }

        public async Task<VeiculoDto> CreateAsync(VeiculoDto dto)
        {
            var entity = new Veiculo
            {
                modelo = dto.Modelo,
                descricao = dto.Descricao,
                marca = dto.Marca,
                situacao = dto.Situacao,
                placa = dto.Placa,
                renavam = dto.Renavam,
                ano_fabricacao = dto.AnoFabricacao,
                tipo = dto.Tipo,
                chassi = dto.Chassi,
                capacidade_passageiros = dto.CapacidadePassageiros,
                potencia = dto.Potencia,
                cor = dto.Cor,
                valor_diaria = dto.ValorDiaria
            };

            _context.Veiculo.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.id;
            return dto;
        }

        public async Task<VeiculoDto> UpdateAsync(int id, VeiculoDto dto)
        {
            var v = await _context.Veiculo.FindAsync(id);
            if (v == null) return null;

            v.modelo = dto.Modelo;
            v.descricao = dto.Descricao;
            v.marca = dto.Marca;
            v.situacao = dto.Situacao;
            v.placa = dto.Placa;
            v.renavam = dto.Renavam;
            v.ano_fabricacao = dto.AnoFabricacao;
            v.tipo = dto.Tipo;
            v.chassi = dto.Chassi;
            v.capacidade_passageiros = dto.CapacidadePassageiros;
            v.potencia = dto.Potencia;
            v.cor = dto.Cor;
            v.valor_diaria = dto.ValorDiaria;

            _context.Entry(v).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new VeiculoDto
            {
                Id = v.id,
                Modelo = v.modelo,
                Descricao = v.descricao,
                Marca = v.marca,
                Situacao = v.situacao,
                Placa = v.placa,
                Renavam = v.renavam,
                AnoFabricacao = v.ano_fabricacao,
                Tipo = v.tipo,
                Chassi = v.chassi,
                CapacidadePassageiros = v.capacidade_passageiros,
                Potencia = v.potencia,
                Cor = v.cor,
                ValorDiaria = v.valor_diaria
            };
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
