using System.ComponentModel.DataAnnotations;

namespace api_teste.Dtos
{
    public class SeguroDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3)]
        public string? Descricao { get; set; }

        [Required]
        [StringLength(100)]
        public string Seguradora { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; } = null!;

        [Required]
        [Range(0, 1000000, ErrorMessage = "Valor do seguro deve ser entre 0 e 1.000.000.")]
        public decimal ValorSeguro { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Valor da franquia deve ser entre 0 e 1.000.000.")]
        public decimal ValorFranquia { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }
    }
}
