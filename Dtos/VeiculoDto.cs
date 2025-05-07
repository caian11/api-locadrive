namespace api_teste.Dtos
{
    public class VeiculoDto
    {
        public int id { get; set; }
        public required string modelo { get; set; }
        public string? descricao { get; set; }
        public required string marca { get; set; }
    }
}
