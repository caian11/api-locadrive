using api_teste.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("locacao_seguro")]
public class LocacaoSeguro
{
    [Column("id")]
    public int Id { get; set; }

    [Column("locacao_id")]
    public int LocacaoId { get; set; }

    [ForeignKey("LocacaoId")]
    [JsonIgnore]
    public Locacao Locacao { get; set; } = null!;

    [Column("seguro_id")]
    public int SeguroId { get; set; }

    [ForeignKey("SeguroId")]
    [JsonIgnore]
    public Seguro Seguro { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
