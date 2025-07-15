using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_teste.Models
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = null!;

        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("cpf")]
        public string Cpf { get; set; } = null!;

        [Column("senha")]
        public string Senha { get; set; } = null!;

        [Column("data_nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonIgnore]
        [Column("endereco_id")]
        public int EnderecoId { get; set; }

        [ForeignKey("EnderecoId")]
        public Endereco? Endereco { get; set; }

        public List<Locacao> locacoes { get; set; } = new();
    }
}
