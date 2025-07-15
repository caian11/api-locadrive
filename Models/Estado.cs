using System.ComponentModel.DataAnnotations.Schema;

namespace api_teste.Models
{
    [Table("uf")]
    public class Estado
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = null!;

        [Column("sigla")]
        public string Sigla { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public ICollection<Cidade>? Cidades { get; set; }
    }
}
