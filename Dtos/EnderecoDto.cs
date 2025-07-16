using System.ComponentModel.DataAnnotations;

namespace api_teste.Dtos
{
    public class EnderecoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Logradouro deve ter entre 3 e 255 caracteres.")]
        public string Logradouro { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Número deve ser maior que zero.")]
        public int Numero { get; set; }

        [StringLength(255, ErrorMessage = "Complemento deve ter no máximo 255 caracteres.")]
        public string? Complemento { get; set; }

        [StringLength(100, ErrorMessage = "Bairro deve ter no máximo 100 caracteres.")]
        public string? Bairro { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP deve estar no formato 12345-678.")]
        public string Cep { get; set; } = null!;

        [Required]
        public int CidadeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }
    }
}
