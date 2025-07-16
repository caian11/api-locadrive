using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_teste.Models
{
    [Table("locacao_veiculo")]
    public class LocacaoVeiculo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("locacao_id")]
        public int LocacaoId { get; set; }

        [ForeignKey("LocacaoId")]
        [JsonIgnore]
        public Locacao Locacao { get; set; } = null!;

        [Column("veiculo_id")]
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        [JsonIgnore]
        public Veiculo Veiculo { get; set; } = null!;

        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime DataFim { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
