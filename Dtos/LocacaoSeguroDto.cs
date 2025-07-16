using System;
using System.ComponentModel.DataAnnotations;

namespace api_teste.Dtos
{
    public class LocacaoSeguroDto
    {
        [Required]
        public int LocacaoId { get; set; }

        [Required]
        public int SeguroId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
