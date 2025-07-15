using System.ComponentModel.DataAnnotations;

namespace api_teste.Dtos;

public class PessoaDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "Nome deve ter entre 2 e 255 caracteres.")]
    public string Nome { get; set; } = null!;

    [Required]
    [StringLength(255, ErrorMessage = "Email deve ter no máximo 255 caracteres.")]
    [EmailAddress(ErrorMessage = "E‑mail em formato inválido.")]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\d{11}$|^\d{3}\.\d{3}\.\d{3}-\d{2}$",
        ErrorMessage = "CPF deve estar no formato 12345678901 ou 123.456.789-01.")]
    public string Cpf { get; set; } = null!;

    [Required]
    [StringLength(255, MinimumLength = 6, ErrorMessage = "Senha deve ter entre 6 e 255 caracteres.")]
    public string Senha { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Required]
    public bool Status { get; set; }

    [Required]
    public int EnderecoId { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.Date)]
    public DateTime UpdatedAt { get; set; }
}
