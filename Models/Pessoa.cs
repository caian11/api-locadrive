using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_teste.Models
{
    [Table("pessoa")]
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; } = null!;
        public string email { get; set; } = null!;
        public string cpf { get; set; } = null!;
        public string senha { get; set; } = null!;

        public DateTime data_nascimento { get; set; }

        public bool status { get; set; }

        public int endereco { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

         [ForeignKey("endereco")]
        public Endereco? EnderecoNavigation { get; set; }
    }
}
