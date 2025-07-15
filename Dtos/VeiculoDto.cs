using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace api_teste.Dtos
{
    public class VeiculoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Modelo { get; set; } = null!;

        [StringLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [StringLength(50)]
        public string Marca { get; set; } = null!;

        [Required]
        [StringLength(30)]
        public string Situacao { get; set; } = null!;

        [Required]
        [PlacaBr]
        public string Placa { get; set; } = null!;

        [Required]
        [RenavamBr]
        public string Renavam { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime AnoFabricacao { get; set; }

        [Required]
        [StringLength(30)]
        public string Tipo { get; set; } = null!;

        [Required]
        [ChassiBr]
        public string Chassi { get; set; } = null!;

        [Required]
        [Range(1, 100)]
        public int CapacidadePassageiros { get; set; }

        [Required]
        [StringLength(20)]
        public string Potencia { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Cor { get; set; } = null!;

        [Required]
        [Range(1, 10000, ErrorMessage = "Valor da diária deve estar entre 1 e 10.000.")]
        public float ValorDiaria { get; set; } = 0!;
    }

    public class PlacaBrAttribute : RegularExpressionAttribute
    {
        private const string PlacaRegex = @"^([A-Z]{3}-\d{4}|[A-Z]{3}\d[A-Z]\d{2})$";
        public PlacaBrAttribute()
            : base(PlacaRegex)
        {
            ErrorMessage = "Placa inválida. Use ABC-1234 ou o padrão Mercosul (ABC1D23).";
        }
    }

    public class RenavamBrAttribute : ValidationAttribute
    {
        public RenavamBrAttribute()
        {
            ErrorMessage = "RENAVAM inválido.";
        }

        public override bool IsValid(object? value)
        {
            if (value is not string s) return false;
            s = Regex.Replace(s, @"\D", "").PadLeft(11, '0');
            if (s.Length != 11) return false;

            var dígitos = s.Select(c => c - '0').ToArray();
            int[] pesos = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3 };
            int soma = 0;
            for (int i = 0; i < 10; i++)
                soma += dígitos[i] * pesos[i];

            int resto = soma % 11;
            int dv = (resto < 2) ? 0 : 11 - resto;
            return dv == dígitos[10];
        }
    }

    public class ChassiBrAttribute : ValidationAttribute
    {
        private static readonly Regex _rx = new Regex("^[A-HJ-NPR-Z0-9]{17}$", RegexOptions.Compiled);
        public ChassiBrAttribute()
        {
            ErrorMessage = "Chassi inválido. Deve ter 17 caracteres alfanuméricos (sem I, O, Q).";
        }

        public override bool IsValid(object? value)
        {
            return value is string s && _rx.IsMatch(s.ToUpper());
        }
    }
}
