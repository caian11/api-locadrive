using System.ComponentModel.DataAnnotations.Schema;

namespace api_teste.Models
{
    [Table("seguro")]
    public class Seguro
    {
        public int id { get; set; }
        public string descricao { get; set; } = null!;
        public string seguradora { get; set; } = null!;
        public string tipo { get; set; } = null!;
        public decimal valor_seguro { get; set; }
        public decimal valor_franquia { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
