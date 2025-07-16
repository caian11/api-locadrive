using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_teste.Models
{
    [Table("locacao_veiculo")]
    public class LocacaoVeiculo
    {
        public int id { get; set; }

        public int locacao { get; set; }

        [ForeignKey("locacao")]
        [JsonIgnore]
        public Locacao Locacao { get; set; } = null!;

        public int veiculo { get; set; }

        [ForeignKey("veiculo")]
        [JsonIgnore]
        public Veiculo Veiculo { get; set; } = null!;

        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public decimal valor { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
