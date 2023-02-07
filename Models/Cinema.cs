using System.ComponentModel.DataAnnotations;

namespace Primeira_API.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string nome_cinema { get; set; }
    }
}
