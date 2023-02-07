﻿using System.ComponentModel.DataAnnotations;

namespace Primeira_API.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string nome_cinema { get; set; }
    }
}
