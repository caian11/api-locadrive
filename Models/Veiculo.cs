using System.Reflection.Metadata;

namespace api_teste.Models
{
    public class Veiculo
    {
        public int id {  get; set; }
        public  string modelo { get; set; }
        public  string? descricao{ get; set; }
        public string marca { get; set; }
        public string situacao { get; set; }
        public string placa { get; set; }
        public string renavam {  get; set; }
        public DateTime ano_fabricacao { get; set; }
        public string tipo { get; set; }
        public string chassi { get; set; }
        public int capacidade_passageiros { get; set; }
        public string potencia { get; set; }
        public string cor {  get; set; }
        public float valor_diaria { get; set; }

    }
}
