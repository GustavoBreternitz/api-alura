﻿using System.ComponentModel.DataAnnotations;

namespace Primeira_API.Models;

public class Filme
{
    [Key]
    [Required]
    public int id { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string titulo { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string genero { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1, 120)]
    public int duracao { get; set; }
}
