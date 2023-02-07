using System.ComponentModel.DataAnnotations;

namespace Primeira_API.Data.Dtos;

public class ReadFilmeDto
{
    public string id { get; set; }
    public string titulo { get; set; }
    public string genero { get; set; }
    public int duracao { get; set; }
    public DateTime horaDaConsulta { get; set; } = DateTime.Now;
}
