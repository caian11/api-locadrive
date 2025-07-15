using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_teste.Models
{
    [Table("cidade")]
    public class Cidade
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        [Column("uf_id")]
        public int UfId { get; set; }
        [ForeignKey("UfId")]
        public Estado? Uf { get; set; }
    }
}
