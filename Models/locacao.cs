using api_teste.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_teste.Models
{
    [Table("locacao")]
    public class Locacao
    {
        public int id { get; set; }
        public decimal valor { get; set; }
        public string forma_pagamento { get; set; } = null!;
        public DateTime data_pedido { get; set; }
        public string status { get; set; } = null!;
        public string numero { get; set; } = null!;

        public int pessoa { get; set; }

        [ForeignKey("pessoa")]
        public Pessoa Pessoa { get; set; } = null!;

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public List<LocacaoVeiculo> veiculos { get; set; } = new();
    }
}
