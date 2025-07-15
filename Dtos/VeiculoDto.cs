using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using api_teste.Validations;

namespace api_teste.Dtos
{
    public class VeiculoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Modelo { get; set; } = null!;

        [StringLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [StringLength(50)]
        public string Marca { get; set; } = null!;

        [Required]
        [StringLength(30)]
        public string Situacao { get; set; } = null!;

        [Required]
        [PlacaBr]
        public string Placa { get; set; } = null!;

        [Required]
        [RenavamBr]
        public string Renavam { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime AnoFabricacao { get; set; }

        [Required]
        [StringLength(30)]
        public string Tipo { get; set; } = null!;

        [Required]
        [ChassiBr]
        public string Chassi { get; set; } = null!;

        [Required]
        [Range(1, 100)]
        public int CapacidadePassageiros { get; set; }

        [Required]
        [StringLength(20)]
        public string Potencia { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Cor { get; set; } = null!;

        [Required]
        [Range(1, 10000, ErrorMessage = "Valor da diária deve estar entre 1 e 10.000.")]
        public float ValorDiaria { get; set; } = 0!;
    }
}
