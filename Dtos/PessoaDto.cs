using System.ComponentModel.DataAnnotations;

namespace api_teste.Dtos

public class PessoaDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = null!;

    [Required]
    [StringLength(150)]
    [EmailAddress(ErrorMessage = "E‑mail em formato inválido.")]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 dígitos numéricos.")]
    public string Cpf { get; set; } = null!;

    [Required]
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
