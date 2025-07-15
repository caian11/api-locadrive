using System;
using System.ComponentModel.DataAnnotations;

namespace api_teste.Dtos
{
    public class LocacaoVeiculoDto
    {
        [Required]
        public int Veiculo { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}
