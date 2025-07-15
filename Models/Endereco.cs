using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_teste.Models
{
    [Table("endereco")]

    public class Endereco
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; } = null!;

        [Column("numero")]
        public int Numero { get; set; }

        [Column("complemento")]
        public string? Complemento { get; set; }

        [Column("bairro")]
        public string? Bairro { get; set; }

        [Column("cep")]
        public string? Cep { get; set; }


        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        [Column("cidade_id")]
        public int CidadeId { get; set; }
        
        [ForeignKey("CidadeId")]
        public Cidade? Cidade { get; set; }
    }
}
