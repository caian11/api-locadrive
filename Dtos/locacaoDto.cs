using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_teste.Dtos
{
    public class LocacaoDto
    {
        public int Id { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public string FormaPagamento { get; set; } = null!;

        [Required]
        public DateTime DataPedido { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public string Numero { get; set; } = null!;

        [Required]
        public int Pessoa { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required]
        public List<LocacaoVeiculoDto> Veiculos { get; set; } = new();
        public List<int> Seguros { get; set; } = new(); 
    }
}
