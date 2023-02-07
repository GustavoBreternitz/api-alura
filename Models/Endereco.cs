using System.ComponentModel.DataAnnotations;

namespace Primeira_API.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string rua { get; set; }
        [Required]
        [MaxLength(100)]
        public string bairro { get; set; }
        [Required]
        [MaxLength(9)]
        public string cep { get; set; }
        [Required]
        public int numero { get; set; }
    }
}
